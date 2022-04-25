namespace Tefter
{
    using Microsoft.Extensions.DependencyInjection;
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

        private bool isBackButtonClicked = false;

        public CreateNewServiceBookFormTwo(ApplicationDbContext dbContext, Logger logger)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Location = new Point(0, 0);

            this.dbContext = dbContext;
            this.logger = logger;
        }

        public Car Car { get; set; }

        public Form RefToCreateNewServiceBookFormOne { get; set; }

        private void Open_CreateNewServiceBookFormThreeButton_Click(object sender, EventArgs e)
        {
            var emptyOrWrongFields = new List<string>();

            //if (string.IsNullOrWhiteSpace(kilometers))
            //{
            //    emptyOrWrongFields.Add("Км");
            //}
            if (string.IsNullOrWhiteSpace(NextOilChangeKilometers_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Следваща смяна на (км)");
            }

            var sb = new StringBuilder();

            if (emptyOrWrongFields.Count() > 0)
            {
                sb.AppendLine("Моля попълнете следните полета: ");
                sb.AppendLine(string.Join(", ", emptyOrWrongFields.Select(x => x)));

                MessageBox.Show(sb.ToString());
                return;
            }

            var currentKilometersRegex = new Regex("^([0-9]*)$|^([0-9]* [0-9]*)$");
            var nextOilChangeKilometersRegex = new Regex("^([0-9]*)$|^([0-9]* [0-9]*)$");

            //if (!currentKilometersRegex.IsMatch(kilometers))
            //{
            //    emptyOrWrongFields.Add("Км");
            //}
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

            //var kilometers = CurrentKilometers_TextBox.Text.Trim();
            var nextOilChangeKilometers = NextOilChangeKilometers_TextBox.Text.Trim();
            var dateMadeChanges = DateMadeChanges_DatePicker.Value;
            var oil = Oil_TextBox.Text.Trim();
            var oilFilter = OilFilter_TextBox.Text.Trim();
            var fuelFilter = FuelFilter_TextBox.Text.Trim();
            var airFilter = AirFilter_TextBox.Text.Trim();
            var coupeFilter = CoupeFilter_TextBox.Text.Trim();

            var toStringedDate = dateMadeChanges.ToString("dd.M.yyyy HH:mm:ss");
            var jsonData = new OilAndFiltersJsonData(toStringedDate, Car.Kilometers, oil, nextOilChangeKilometers, oilFilter, fuelFilter, airFilter, coupeFilter);
            var data = JsonConvert.SerializeObject(jsonData);
            var oilAndFilters = new OilAndFilter(data);

            try
            {
                this.Car.OilAndFilters.Add(oilAndFilters);
            }
            catch (Exception ex)
            {
                logger.WriteLine($"CreateNewServiceBookFormTwo.iconButton1_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }

            //var thirdForm = new CreateNewServiceBookFormThree(Car, dbContext, logger);
            //thirdForm.RefToCreateNewServiceBookFormTwo = this;

            //this.Hide();
            //thirdForm.Show();

            using (var createNewSerivceBookFormThree = Program.ServiceProvider.GetRequiredService<CreateNewServiceBookFormThree>())
            {
                createNewSerivceBookFormThree.RefToCreateNewServiceBookFormTwo = this;
                this.Hide();
                createNewSerivceBookFormThree.Car = this.Car;
                createNewSerivceBookFormThree.ShowDialog();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.isBackButtonClicked = true;
            this.Close();
            this.RefToCreateNewServiceBookFormOne.Show();
        }

        private void CreateNewServiceBookFormThree_Load(object sender, EventArgs e)
        {
            OilAndFilters_PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            CurrentKilometers_TextBox.Text = this.Car.Kilometers;
        }

        private void CreateNewServiceBookFormTwo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isBackButtonClicked)
            {
                RefToCreateNewServiceBookFormOne.Close();
            }
        }
    }
}