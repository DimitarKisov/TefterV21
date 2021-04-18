namespace Tefter
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Tefter.DbEntities;
    using Tefter.DbEntities.Enums;

    public partial class CreateNewServiceBookFormOne : Form
    {
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
            #region CarData
            var carId = PlateNumber_TextBox.Text.Trim(); //Регистрационен номер
            var brand = Made_TextBox.Text.Trim();
            var model = Model_TextBox.Text.Trim();
            var color = Color_TextBox.Text.Trim();
            var chassisNumber = ChassisNumber_TextBox.Text.Trim();
            var engineNumber = EngineNumber_TextBox.Text.Trim();
            var workingVolumeCubicCm = WorkingVolumeCubicCm_TextBox.Text.Trim();
            var firstRegistration = FirstDateRegister_DatePicker.Value;
            var firstRegistrationInBG = FirstDateRegisterBG_DatePicker.Value;
            var kilometers = CurrentKilometers_TextBox.Text.Trim();
            var owner = OwnerName_TextBox.Text.Trim();
            var egn = Egn_TextBox.Text.Trim();
            var bulstat = Bulstat_TextBox.Text.Trim();
            var phoneNumber = PhoneNumber_TextBox.Text.Trim();
            var address = Address_TextBox.Text.Trim();
            #endregion

            #region CarExtras
            var abs = Abs_CheckBox.Checked;
            var asd = Asd_CheckBox.Checked;
            var ebs = Ebs_CheckBox.Checked;
            var arb = Arb_CheckBox.Checked;
            var esp = Esp_CheckBox.Checked;
            var fourByFour = FourByFour_CheckBox.Checked;
            var airConditioning = AirConditioning_CheckBox;
            var climatronic = Climatronic_CheckBox.Checked;
            var hatch = Hatch_CheckBox.Checked;
            var alarm = Alarm_CheckBox.Checked;
            var immobilizer = Immobilizer_CheckBox.Checked;
            var centralLocking = CentralLocking_CheckBox.Checked;
            var electronicGlass = ElectronicGlass_CheckBox;
            var electronicMirrors = ElectronicMirror_CheckBox.Checked;
            var automatic = Automatic_CheckBox.Checked;
            var electronicPacket = ElectronicPacket_CheckBox.Checked;
            var steeringWheelHydraulics = SteeringWheelHydraulics_CheckBox.Checked;
            var stereo = Stereo_CheckBox.Checked;
            var cdChanger = CdChanger_CheckBox.Checked;
            var amplifier = Amplifier_CheckBox.Checked;
            var others = Others_TextBox.Text.Trim();
            #endregion

            var sb = new StringBuilder();
            var emptyOrWrongFields = new List<string>();

            if (string.IsNullOrWhiteSpace(brand))
            {
                emptyOrWrongFields.Add("Марка");
            }
            if (string.IsNullOrWhiteSpace(model))
            {
                emptyOrWrongFields.Add("Модел");
            }
            if (string.IsNullOrWhiteSpace(carId))
            {
                emptyOrWrongFields.Add("Регистрационен номер");
            }
            if (string.IsNullOrWhiteSpace(CurrentKilometers_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Км");
            }
            if (string.IsNullOrWhiteSpace(owner))
            {
                emptyOrWrongFields.Add("Собственик");
            }

            var fuelType = FuelType.Diesel;
            if (FuelType_Diesel_RadioButton.Checked)
            {
                fuelType = FuelType.Diesel;
            }
            else if (FuelType_Gasoline_RadioButton.Checked)
            {
                fuelType = FuelType.Gasoline;
            }
            else if (FuelType_Gas_RadioButton.Checked)
            {
                fuelType = FuelType.Gasoline;
            }
            else if (FuelType_Methane_RadioButton.Checked)
            {
                fuelType = FuelType.Methane;
            }
            else
            {
                emptyOrWrongFields.Add("Вид двигател");
            }

            if (emptyOrWrongFields.Count() > 0)
            {
                sb.AppendLine("Моля попълнете следните полета: ");
                sb.AppendLine(string.Join(", ", emptyOrWrongFields.Select(x => x)));
                MessageBox.Show(sb.ToString());
                return;
            }

            var brandRegex = new Regex("^([А-Я][а-я]*)$");
            var modelRegex = new Regex("^([А-Я][а-я]*)$");
            var colorRegex = new Regex("^([А-Я][а-я]*)$");
            var workingVolumeCubicCmRegex = new Regex("^[0-9]*$");
            var plateNumberRegex = new Regex("^[А-а-Я-я]{2}[0-9]{4}[А-а-Я-я]{2}$");
            var kilometersRegex = new Regex("^([0-9]*)$|^([0-9]* [0-9]*)$");
            var ownerRegex = new Regex("^(([А-Я][а-я]+)|([А-Я][а-я]+ [А-Я][а-я]+ [А-Я][а-я]+)|[А-Я][а-я]+ [А-Я][а-я]+)$");
            var egnRegex = new Regex("^[0-9]{10}$");
            var phoneNumberRegex = new Regex("^([0-9]{10})$|([0-9{12}]{12})$");
            
            if (!brandRegex.IsMatch(brand))
            {
                emptyOrWrongFields.Add("Марка");
            }
            if (!modelRegex.IsMatch(model))
            {
                emptyOrWrongFields.Add("Модел");
            }
            if (!colorRegex.IsMatch(color))
            {
                emptyOrWrongFields.Add("Цвят");
            }
            if (!workingVolumeCubicCmRegex.IsMatch(workingVolumeCubicCm))
            {
                emptyOrWrongFields.Add("Работен обем куб. см");
            }
            if (!plateNumberRegex.IsMatch(carId))
            {
                emptyOrWrongFields.Add("Регистрационен номер");
            }
            if (!kilometersRegex.IsMatch(kilometers))
            {
                emptyOrWrongFields.Add("Км");
            }
            if (!ownerRegex.IsMatch(owner))
            {
                emptyOrWrongFields.Add("Собственик");
            }
            if (!egnRegex.IsMatch(egn) && !string.IsNullOrWhiteSpace(egn))
            {
                emptyOrWrongFields.Add("ЕГН");
            }
            if (!phoneNumberRegex.IsMatch(phoneNumber) && !string.IsNullOrWhiteSpace(phoneNumber))
            {
                emptyOrWrongFields.Add("Тел");
            }

            if (emptyOrWrongFields.Count() > 0)
            {
                sb.AppendLine("Моля въведете коректни данни за следните полета: ");
                sb.AppendLine(string.Join(", ", emptyOrWrongFields.Select(x => x)));
                MessageBox.Show(sb.ToString());
                return;
            }

            carId = carId.ToUpper();
            var car = new Car(carId);
            var carData = new CarData(brand, model, color, chassisNumber, engineNumber, workingVolumeCubicCm, firstRegistration, firstRegistrationInBG, fuelType, kilometers, owner, egn, bulstat, phoneNumber, address);

            car.CarData = carData;

            this.Hide();
            var secondForm = new CreateNewServiceBookFormTwo(car);
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
