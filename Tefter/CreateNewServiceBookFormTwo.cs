namespace Tefter
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Tefter.DbEntities;
    using Tefter.DbEntities.Helper;
    using Tefter.Helpers;

    public partial class CreateNewServiceBookFormTwo : Form
    {
        private ApplicationDbContext dbContext;
        private readonly Logger logger;

        public CreateNewServiceBookFormTwo(Car car, ApplicationDbContext dbContext, Logger logger)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Location = new Point(0, 0);
            this.dbContext = dbContext;
            this.logger = logger;

            Car = car;
        }

        public Car Car { get; set; }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var dateMadeChanges = DateMadeChanges_DatePicker.Value;
                var oil = Oil_TextBox.Text.Trim();
                var kilometers = CurrentKilometers_TextBox.Text.Trim();
                var nextOilChangeKilometers = NextOilChangeKilometers_TextBox.Text.Trim();
                var oilFilter = OilFilter_TextBox.Text.Trim();
                var fuelFilter = FuelFilter_TextBox.Text.Trim();
                var airFilter = AirFilter_TextBox.Text.Trim();
                var coupeFilter = CoupeFilter_TextBox.Text.Trim();

                var sb = new StringBuilder();
                var emptyOrWrongFields = new List<string>();

                if (string.IsNullOrWhiteSpace(oil))
                {
                    emptyOrWrongFields.Add("Масло");
                }

                if (string.IsNullOrWhiteSpace(kilometers))
                {
                    emptyOrWrongFields.Add("Км");
                }

                if (string.IsNullOrWhiteSpace(nextOilChangeKilometers))
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

                if (!currentKilometersRegex.IsMatch(kilometers))
                {
                    emptyOrWrongFields.Add("Км");
                }
                if (!nextOilChangeKilometersRegex.IsMatch(nextOilChangeKilometers))
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

                var toStringedDate = dateMadeChanges.ToString("dd.M.yyyy HH:mm:ss");
                var jsonData = new OilAndFiltersJsonData(toStringedDate, kilometers, oil, nextOilChangeKilometers, oilFilter, fuelFilter, airFilter, coupeFilter);
                var data = JsonConvert.SerializeObject(jsonData);
                var oilAndFilters = new OilAndFilter(data);

                Car.OilAndFilters.Add(oilAndFilters);

                var thirdForm = new CreateNewServiceBookFormThree(Car, dbContext, logger);
                Hide();
                thirdForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"iconButton1_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            try
            {
                var firstForm = new CreateNewServiceBookFormOne(dbContext, logger);
                Close();
                firstForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"CreateNewServiceBookFormTwo.BackButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }
    }
}
