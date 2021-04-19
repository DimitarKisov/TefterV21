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

    public partial class CreateNewServiceBookFormThree : Form
    {
        private readonly ApplicationDbContext dbContext;
        public CreateNewServiceBookFormThree(Car car, ApplicationDbContext dbContext)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(0, 0);
            this.dbContext = dbContext;

            Car = car;
        }

        public Car Car { get; set; }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            var secondForm = new CreateNewServiceBookFormTwo(Car, dbContext);
            secondForm.Show();
        }

        private void End_Button_Click(object sender, EventArgs e)
        {
            var dateMadeChanges = Convert.ToDateTime(DateMadeChanges_DatePicker.Value, CultureInfo.InvariantCulture);
            var kilometers = CurrentKilometers_TextBox.Text.Trim();
            var serviceMade = Description_TextBox.Text.Trim();

            var sb = new StringBuilder();
            var emptyOrWrongFields = new List<string>();

            if (string.IsNullOrWhiteSpace(kilometers))
            {
                emptyOrWrongFields.Add("Км");
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

            var jsonData = new OtherServicesJsonData(dateMadeChanges, kilometers, serviceMade);
            var data = JsonConvert.SerializeObject(jsonData);
            var otherServices = new OtherService(data);

            Car.OtherServices.Add(otherServices);
            dbContext.SaveChanges();

            this.Close();
            var homePageForm = new HomePageForm();
            homePageForm.Show();
        }
    }
}
