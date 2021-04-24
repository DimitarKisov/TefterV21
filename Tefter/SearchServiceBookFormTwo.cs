namespace Tefter
{
    using System;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Windows.Forms;
    using Tefter.DbEntities;
    using Tefter.DbEntities.Helper;
    using Tefter.Helpers;

    public partial class SearchServiceBookFormTwo : Form
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Logger logger;

        public SearchServiceBookFormTwo(Car car, ApplicationDbContext dbContext, Logger logger)
        {
            InitializeComponent();

            this.dbContext = dbContext;
            this.logger = logger;

            Car = car;
        }

        public Car Car { get; set; }

        private void SearchServiceBookFormTwo_Load(object sender, EventArgs e)
        {
            try
            {
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
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormTwo_Load: {ex}");
            }
        }

        private void Search_BackButton_Click(object sender, EventArgs e)
        {
            try
            {
                var searchServiceBookFirstPage = new SearchServiceBookFormOne(Car, dbContext, logger);
                this.Close();
                searchServiceBookFirstPage.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Search_BackButton_Click: {ex}");
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                var addOilAndFiltersForm = new AddOilAndFiltersForm(Car, OilAndFiltersDataGridView, dbContext);
                this.Close();
                addOilAndFiltersForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"AddButton_Click: {ex}");
            }
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < Car.OilAndFilters.Count(); i++)
                {
                    var id = (int)OilAndFiltersDataGridView.Rows[i].Cells[0].Value;
                    var date = (DateTime)OilAndFiltersDataGridView.Rows[i].Cells[1].Value;
                    var kilometers = (string)OilAndFiltersDataGridView.Rows[i].Cells[2].Value;
                    var oil = (string)OilAndFiltersDataGridView.Rows[i].Cells[3].Value;
                    var nextChange = (string)OilAndFiltersDataGridView.Rows[i].Cells[4].Value;
                    var oilFilter = (string)OilAndFiltersDataGridView.Rows[i].Cells[5].Value;
                    var fuelFilter = (string)OilAndFiltersDataGridView.Rows[i].Cells[6].Value;
                    var airFilter = (string)OilAndFiltersDataGridView.Rows[i].Cells[7].Value;
                    var coupeFilter = (string)OilAndFiltersDataGridView.Rows[i].Cells[8].Value;

                    var oilAndFilters = new OilAndFiltersJsonData(date, kilometers, oil, nextChange, oilFilter, fuelFilter, airFilter, coupeFilter);
                    var parsedJson = JsonConvert.SerializeObject(oilAndFilters);

                    Car.OilAndFilters.FirstOrDefault(x => x.Id == id).Data = parsedJson;
                }

                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SaveChangesButton_Click: {ex}");
            }
        }

        private void DeleteRecordButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = OilAndFiltersDataGridView.SelectedRows;

                foreach (DataGridViewRow row in selectedRows)
                {
                    var id = (int)row.Cells["Id"].Value;
                    var itemForRemove = Car.OilAndFilters.FirstOrDefault(x => x.Id == id);
                    Car.OilAndFilters.Remove(itemForRemove);
                    OilAndFiltersDataGridView.Rows.Remove(row);
                }

                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"DeleteRecordButton_Click: {ex}");
            }
        }
    }
}
