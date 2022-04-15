namespace Tefter
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Tefter.DbEntities;
    using Tefter.DbEntities.Helper;
    using Tefter.Helpers;

    public partial class AddOilAndFiltersForm : Form
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Logger logger;

        public AddOilAndFiltersForm(Car car, DataGridView oilAndFiltersDataGridView, ApplicationDbContext dbContext, Logger logger)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(800, 100);

            this.dbContext = dbContext;
            this.logger = logger;

            this.Car = car;
            this.OilAndFiltersDataGridView = oilAndFiltersDataGridView;
        }

        public Car Car { get; set; }

        public DataGridView OilAndFiltersDataGridView { get; set; }


        private void AddOilAndFiltersRow_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            var emptyOrWrongFields = new List<string>();

            if (string.IsNullOrWhiteSpace(CurrentKilometers_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Км");
            }
            if (string.IsNullOrWhiteSpace(NextOilChangeKilometers_TextBox.Text.Trim()))
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

            var currentKilometersRegex = new Regex("^([0-9]*)$|^([0-9]* [0-9]*)$");
            var nextOilChangeKilometersRegex = new Regex("^([0-9]*)$|^([0-9]* [0-9]*)$");

            if (!currentKilometersRegex.IsMatch(CurrentKilometers_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Км");
            }
            if (!nextOilChangeKilometersRegex.IsMatch(NextOilChangeKilometers_TextBox.Text.Trim()))
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

            var kilometers = CurrentKilometers_TextBox.Text.Trim();
            var nextOilChangeKilometers = NextOilChangeKilometers_TextBox.Text.Trim();
            var dateMadeChanges = DateMadeChanges_DatePicker.Value;
            var oil = Oil_TextBox.Text.Trim();
            var oilFilter = OilFilter_TextBox.Text.Trim();
            var fuelFilter = FuelFilter_TextBox.Text.Trim();
            var airFilter = AirFilter_TextBox.Text.Trim();
            var coupeFilter = CoupeFilter_TextBox.Text.Trim();

            var toStringedDate = dateMadeChanges.ToString("dd.M.yyyy HH:mm:ss");
            var jsonData = new OilAndFiltersJsonData(toStringedDate, kilometers, oil, nextOilChangeKilometers, oilFilter, fuelFilter, airFilter, coupeFilter);
            var data = JsonConvert.SerializeObject(jsonData);
            var oilAndFilters = new OilAndFilter(data);

            this.Car.OilAndFilters.Add(oilAndFilters);

            try
            {
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"AddOilAndFiltersForm.AddOilAndFiltersRow_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }

            this.OilAndFiltersDataGridView.Rows.Add();
            var rowsCountWithNewRow = OilAndFiltersDataGridView.Rows.Count - 1;

            this.OilAndFiltersDataGridView.Rows[rowsCountWithNewRow].Cells[0].Value = Car.OilAndFilters.First().Id;
            this.OilAndFiltersDataGridView.Rows[rowsCountWithNewRow].Cells[1].Value = jsonData.Date;
            this.OilAndFiltersDataGridView.Rows[rowsCountWithNewRow].Cells[2].Value = jsonData.Kilometers;
            this.OilAndFiltersDataGridView.Rows[rowsCountWithNewRow].Cells[3].Value = jsonData.Oil;
            this.OilAndFiltersDataGridView.Rows[rowsCountWithNewRow].Cells[4].Value = jsonData.NextChange;
            this.OilAndFiltersDataGridView.Rows[rowsCountWithNewRow].Cells[5].Value = jsonData.OilFilter;
            this.OilAndFiltersDataGridView.Rows[rowsCountWithNewRow].Cells[6].Value = jsonData.FuelFilter;
            this.OilAndFiltersDataGridView.Rows[rowsCountWithNewRow].Cells[7].Value = jsonData.AirFilter;
            this.OilAndFiltersDataGridView.Rows[rowsCountWithNewRow].Cells[8].Value = jsonData.CoupeFilter;

            this.Close();
        }
    }
}
