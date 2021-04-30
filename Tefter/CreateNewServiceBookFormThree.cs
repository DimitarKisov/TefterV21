namespace Tefter
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
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
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(0, 0);
            this.dbContext = dbContext;
            this.logger = logger;

            Car = car;
        }

        public Car Car { get; set; }

        private void BackButton_Click(object sender, EventArgs e)
        {
            try
            {
                Car.OilAndFilters.Remove(Car.OilAndFilters.Last());

                var secondForm = new CreateNewServiceBookFormTwo(Car, dbContext, logger);
                Close();
                secondForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"CreateNewServiceBookFormThree.BackButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void End_Button_Click(object sender, EventArgs e)
        {
            try
            {
                var dateMadeChanges = DateMadeChanges_DatePicker.Value;
                var kilometers = CurrentKilometers_TextBox.Text.Trim();
                var serviceMade = Description_TextBox.Text.Trim();

                HomePageForm homePageForm;

                if (string.IsNullOrWhiteSpace(kilometers) && string.IsNullOrWhiteSpace(serviceMade))
                {
                    dbContext.Cars.Add(Car);
                    dbContext.SaveChanges();

                    homePageForm = new HomePageForm();
                    Close();
                    homePageForm.Show();

                    return;
                }

                var sb = new StringBuilder();
                var emptyOrWrongFields = new List<string>();

                if (string.IsNullOrWhiteSpace(kilometers))
                {
                    emptyOrWrongFields.Add("Км");
                }

                if (string.IsNullOrWhiteSpace(serviceMade))
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

                if (!currentKilometersRegex.IsMatch(kilometers))
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

                var toStringedDate = dateMadeChanges.ToString("dd.M.yyyy HH:mm:ss");
                var jsonData = new OtherServicesJsonData(toStringedDate, kilometers, serviceMade);
                var data = JsonConvert.SerializeObject(jsonData);
                var otherServices = new OtherService(data);

                Car.OtherServices.Add(otherServices);

                dbContext.Cars.Add(Car);
                dbContext.SaveChanges();

                homePageForm = new HomePageForm();
                Close();
                homePageForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"CreateNewServiceBookFormThree.End_Button_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }
    }
}
