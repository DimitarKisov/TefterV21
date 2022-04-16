namespace Tefter
{
    using System;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Windows.Forms;
    using Tefter.DbEntities;
    using Tefter.DbEntities.Helper;
    using Tefter.Helpers;
    using System.Text;
    using System.Collections.Generic;
    using System.Data;
    using System.Text.RegularExpressions;

    public partial class SearchServiceBookFormTwo : Form
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Logger logger;

        public SearchServiceBookFormTwo(Car car, ApplicationDbContext dbContext, Logger logger)
        {
            InitializeComponent();

            this.dbContext = dbContext;
            this.logger = logger;

            this.Car = car;
        }

        public Car Car { get; set; }

        private void SearchServiceBookFormTwo_Load(object sender, EventArgs e)
        {
            try
            {
                this.Car.OilAndFilters = this.dbContext
                    .OilAndFilters
                    .Where(x => x.CarId == Car.Id)
                    .ToList();
            }
            catch (Exception ex)
            {
                this.logger.WriteLine($"SearchServiceBookFormTwo.SearchServiceBookFormTwo_Load: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }

            OilAndFiltersDataGridView.Columns["Id"].Visible = false;

            for (int i = 0; i < Car.OilAndFilters.Count(); i++)
            {
                if (Car.OilAndFilters.Count() - 1 >= i)
                {
                    OilAndFiltersDataGridView.Rows.Add();
                }

                var parsedJson = Car.OilAndFilters[i].ParseData<OilAndFiltersJsonData>();
                OilAndFiltersDataGridView.Rows[i].Cells[0].Value = Car.OilAndFilters[i].Id;
                OilAndFiltersDataGridView.Rows[i].Cells[1].Value = parsedJson.Date;
                OilAndFiltersDataGridView.Rows[i].Cells[2].Value = parsedJson.Kilometers;
                OilAndFiltersDataGridView.Rows[i].Cells[3].Value = parsedJson.Oil;
                OilAndFiltersDataGridView.Rows[i].Cells[4].Value = parsedJson.NextChange;
                OilAndFiltersDataGridView.Rows[i].Cells[5].Value = parsedJson.OilFilter;
                OilAndFiltersDataGridView.Rows[i].Cells[6].Value = parsedJson.FuelFilter;
                OilAndFiltersDataGridView.Rows[i].Cells[7].Value = parsedJson.AirFilter;
                OilAndFiltersDataGridView.Rows[i].Cells[8].Value = parsedJson.CoupeFilter;
            }
        }

        private void Search_BackButton_Click(object sender, EventArgs e)
        {
            var searchServiceBookFirstPage = new SearchServiceBookFormOne(Car, dbContext, logger);
            this.Close();
            searchServiceBookFirstPage.Show();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addOilAndFiltersForm = new AddOilAndFiltersForm(Car, OilAndFiltersDataGridView, dbContext, logger);
            addOilAndFiltersForm.Show();
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            var emptyOrWrongFields = new List<string>();

            for (int i = 0; i < Car.OilAndFilters.Count(); i++)
            {
                var id = (int)OilAndFiltersDataGridView.Rows[i].Cells[0].Value;
                var date = ((string)OilAndFiltersDataGridView.Rows[i].Cells[1].Value);
                var kilometers = (string)OilAndFiltersDataGridView.Rows[i].Cells[2].Value;
                var oil = (string)OilAndFiltersDataGridView.Rows[i].Cells[3].Value;
                var nextChange = (string)OilAndFiltersDataGridView.Rows[i].Cells[4].Value;
                var oilFilter = (string)OilAndFiltersDataGridView.Rows[i].Cells[5].Value;
                var fuelFilter = (string)OilAndFiltersDataGridView.Rows[i].Cells[6].Value;
                var airFilter = (string)OilAndFiltersDataGridView.Rows[i].Cells[7].Value;
                var coupeFilter = (string)OilAndFiltersDataGridView.Rows[i].Cells[8].Value;

                if (string.IsNullOrWhiteSpace(date))
                {
                    emptyOrWrongFields.Add("Дата");
                }

                if (string.IsNullOrWhiteSpace(oil))
                {
                    emptyOrWrongFields.Add("Масло");
                }

                if (string.IsNullOrWhiteSpace(kilometers))
                {
                    emptyOrWrongFields.Add("Км");
                }

                if (string.IsNullOrWhiteSpace(nextChange))
                {
                    emptyOrWrongFields.Add("Следваща смяна на (км)");
                }

                if (emptyOrWrongFields.Count() > 0)
                {
                    sb.AppendLine("Моля попълнете следните полета: ");
                    sb.AppendLine(string.Join(", ", emptyOrWrongFields.Select(x => x)));

                    MessageBox.Show(sb.ToString());
                    return;
                }

                var dateTimeMadeChanges = new Regex(@"^([1-9]|([012][0-9])|(3[01]))\.([0]{0,1}[1-9]|1[012])\.\d\d\d\d (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$");
                var currentKilometersRegex = new Regex("^([0-9]*)$|^([0-9]* [0-9]*)$");
                var nextOilChangeKilometersRegex = new Regex("^([0-9]*)$|^([0-9]* [0-9]*)$");

                if (!dateTimeMadeChanges.IsMatch(date))
                {
                    emptyOrWrongFields.Add("Дата");
                }

                if (!currentKilometersRegex.IsMatch(kilometers))
                {
                    emptyOrWrongFields.Add("Км");
                }

                if (!nextOilChangeKilometersRegex.IsMatch(nextChange))
                {
                    emptyOrWrongFields.Add("Следваща смяна на (км)");
                }

                if (emptyOrWrongFields.Count() > 0)
                {
                    sb.AppendLine("Моля въведете коректни данни за следните полета: ");
                    sb.AppendLine(string.Join(", ", emptyOrWrongFields.Select(x => x)));

                    MessageBox.Show(sb.ToString());
                    return;
                }

                var oilAndFilters = new OilAndFiltersJsonData(date, kilometers, oil, nextChange, oilFilter, fuelFilter, airFilter, coupeFilter);
                var parsedJson = JsonConvert.SerializeObject(oilAndFilters);

                this.Car.OilAndFilters.FirstOrDefault(x => x.Id == id).Data = parsedJson;
            }

            try
            {
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.WriteLine($"SearchServiceBookFormTwo.SaveChangesButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }

            MessageBox.Show("Успешно направени промени.");
        }

        private void DeleteRecordButton_Click(object sender, EventArgs e)
        {
            var selectedRows = OilAndFiltersDataGridView.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                var id = (int)row.Cells["Id"].Value;
                var itemForRemove = this.Car.OilAndFilters.FirstOrDefault(x => x.Id == id);

                this.Car.OilAndFilters.Remove(itemForRemove);
                OilAndFiltersDataGridView.Rows.Remove(row);
            }

            try
            {
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.WriteLine($"SearchServiceBookFormTwo.DeleteRecordButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }

            MessageBox.Show("Успешно изтрит запис.");
        }

        private void SearchServiceBookFormTwo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var cell = OilAndFiltersDataGridView[e.ColumnIndex, e.RowIndex];
                OilAndFiltersDataGridView.CurrentCell = cell;
                OilAndFiltersDataGridView.BeginEdit(true);
            }
        }
    }
}
