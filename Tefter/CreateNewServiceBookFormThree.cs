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

    public partial class CreateNewServiceBookFormThree : Form
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Logger logger;

        public CreateNewServiceBookFormThree(Car car, ApplicationDbContext dbContext, Logger logger)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Location = new Point(0, 0);

            this.dbContext = dbContext;
            this.logger = logger;

            this.Car = car;
        }

        public Car Car { get; set; }

        public Form RefToCreateNewServiceBookFormTwo { get; set; }

        private void EndButton_Click(object sender, EventArgs e)
        {
            HomePageForm homePageForm;

            if (string.IsNullOrWhiteSpace(CurrentKilometers_TextBox.Text.Trim()) && string.IsNullOrWhiteSpace(Description_TextBox.Text.Trim()))
            {
                try
                {
                    this.dbContext.Cars.Add(Car);
                    this.dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    logger.WriteLine($"CreateNewServiceBookFormThree.End_Button_Click: {ex}");
                    MessageBox.Show("Възникна неочаквана грешка!");
                };

                homePageForm = new HomePageForm(dbContext, logger);
                this.Close();
                homePageForm.Show();

                return;
            }

            var sb = new StringBuilder();
            var emptyOrWrongFields = new List<string>();

            if (string.IsNullOrWhiteSpace(CurrentKilometers_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Км");
            }

            if (string.IsNullOrWhiteSpace(Description_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Извършена сервизна дейност");
            }

            if (emptyOrWrongFields.Count() > 0)
            {
                sb.AppendLine("Моля попълнете следните полета: ");
                sb.AppendLine(string.Join(", ", emptyOrWrongFields.Select(x => x)));

                MessageBox.Show(sb.ToString());
                return;
            }

            var currentKilometersRegex = new Regex("^([0-9]*)$|^([0-9]* [0-9]*)$");

            if (!currentKilometersRegex.IsMatch(CurrentKilometers_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Км");
            }

            if (emptyOrWrongFields.Count() > 0)
            {
                sb.AppendLine("Моля въведете коректни данни за следните полета: ");
                sb.AppendLine(string.Join(", ", emptyOrWrongFields.Select(x => x)));

                MessageBox.Show(sb.ToString());
                return;
            }

            var kilometers = CurrentKilometers_TextBox.Text.Trim();
            var serviceMade = Description_TextBox.Text.Trim();
            var dateMadeChanges = DateMadeChanges_DatePicker.Value;

            var toStringedDate = dateMadeChanges.ToString("dd.M.yyyy HH:mm:ss");
            var jsonData = new OtherServicesJsonData(toStringedDate, kilometers, serviceMade);
            var data = JsonConvert.SerializeObject(jsonData);
            var otherServices = new OtherService(data);

            this.Car.OtherServices.Add(otherServices);

            this.dbContext.Cars.Add(Car);
            this.dbContext.SaveChanges();

            homePageForm = new HomePageForm(dbContext, logger);
            this.Close();
            homePageForm.Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Car.OilAndFilters.Remove(this.Car.OilAndFilters.Last());
            this.Close();
            this.RefToCreateNewServiceBookFormTwo.Show();
        }
    }
}
