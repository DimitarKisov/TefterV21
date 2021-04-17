namespace Tefter
{
    using System;
    using System.Drawing;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Tefter.DbEntities;

    public partial class CreateNewServiceBookFormOne : Form
    {
        public static string made = null;
        public static string model = null;
        public static string color = null;
        public static string chassisNumber = null;
        public static string engineNumber = null;
        public static string plateNumber = null;
        public static DateTime firstRegistration = DateTime.Now;
        public static DateTime firstRegistrationInBG = DateTime.Now;
        public static string ownerName = string.Empty;
        public static int currentKilometers = -1;
        public static int fuelType = -1;

        public CreateNewServiceBookFormOne()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(0, 0);
        }

        private void CreateNewServiceBookFormOne_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Model_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void NextToNewServiceBookFormTwo_Button_Click(object sender, EventArgs e)
        {
            //Регистрационен номер
            var carId = PlateNumber_TextBox.Text.Trim();
            var brand = Made_TextBox.Text.Trim();
            var model = Model_TextBox.Text.Trim();
            var color = Color_TextBox.Text.Trim();
            var chassisNumber = ChassisNumber_TextBox.Text.Trim();
            var engineNumber = EngineNumber_TextBox.Text.Trim();
            plateNumber = PlateNumber_TextBox.Text.Trim();
            firstRegistration = FirstDateRegister_DatePicker.Value;
            firstRegistrationInBG = FirstDateRegisterBG_DatePicker.Value;
            ownerName = OwnerName_TextBox.Text.Trim();
            
            var emptyRequiredInfo = false;
            var sb = new StringBuilder();
            sb.Append("Моля попълнете следните полета: ");
            
            if (string.IsNullOrWhiteSpace(made))
            {
                sb.AppendLine("Марка, ");
                emptyRequiredInfo = true;
            }
            if (string.IsNullOrWhiteSpace(model))
            {
                sb.AppendLine("Модел, ");
                emptyRequiredInfo = true;
            }
            if (string.IsNullOrWhiteSpace(plateNumber))
            {
                sb.AppendLine("Регистрационен номер, ");
                emptyRequiredInfo = true;
            }
            if (string.IsNullOrWhiteSpace(CurrentKilometers_TextBox.Text.Trim()))
            {
                sb.AppendLine("Км, ");
                emptyRequiredInfo = true;
            }
            if (string.IsNullOrWhiteSpace(ownerName))
            {
                sb.AppendLine("Собственик, ");
                emptyRequiredInfo = true;
            }

            if (FuelType_Diesel_RadioButton.Checked)
            {
                fuelType = 0;
            }
            else if (FuelType_Gasoline_RadioButton.Checked)
            {
                fuelType = 1;
            }
            else if (FuelType_Gas_RadioButton.Checked)
            {
                fuelType = 2;
            }
            else if (FuelType_Methane_RadioButton.Checked)
            {
                fuelType = 3;
            }
            else
            {
                sb.Append("Вид на двигател");
                emptyRequiredInfo = true;
            }

            if (emptyRequiredInfo)
            {
                MessageBox.Show(string.Join(";", sb.ToString()));
                return;
            }

            currentKilometers = int.Parse(CurrentKilometers_TextBox.Text.Replace(" ", string.Empty));
            plateNumber = plateNumber.ToUpper();

            var madeRegex = new Regex("^([А-Я][а-я]*)$");
            var modelRegex = new Regex("^([А-Я][а-я]*)$");
            var plateNumberRegex = new Regex("^[А-а-Я-я]{2}[0-9]{4}[А-а-Я-я]{2}$");
            var currentKilometersRegex = new Regex("^([0-9]+)$");
            var ownerNameRegex = new Regex("^(([А-Я][а-я]+)|([А-Я][а-я]+ [А-Я][а-я]+ [А-Я][а-я]+)|[А-Я][а-я]+ [А-Я][а-я]+)$");

            sb.Clear();
            sb.Append("Моля въведете коректни данни за следните полета: ");
            var wrongDateInserted = false;

            if (!madeRegex.IsMatch(made))
            {
                sb.Append("Марка, ");
                wrongDateInserted = true;
            }
            if (!modelRegex.IsMatch(model))
            {
                sb.Append("Модел, ");
                wrongDateInserted = true;
            }
            if (!plateNumberRegex.IsMatch(plateNumber))
            {
                sb.Append("Регистрационен номер, ");
                wrongDateInserted = true;
            }
            if (!currentKilometersRegex.IsMatch(currentKilometers.ToString()))
            {
                sb.Append("Км, ");
                wrongDateInserted = true;
            }
            if (!ownerNameRegex.IsMatch(ownerName))
            {
                sb.Append("Собственик, ");
                wrongDateInserted = true;
            }

            if (wrongDateInserted)
            {
                MessageBox.Show(string.Join("", sb.ToString()));
                return;
            }

            var info = new Info()
            {
                Made = made
            };

            this.Hide();
            var secondForm = new CreateNewServiceBookFormTwo(info);
            secondForm.Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            var homePageForm = new HomePageForm();
            homePageForm.Show();
        }

        private void CreateNewServiceBookFormOne_Load_1(object sender, EventArgs e)
        {

        }

        private void EngineNumber_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
