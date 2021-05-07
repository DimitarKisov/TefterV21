namespace Tefter
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Tefter.DbEntities;
    using Tefter.DbEntities.Enums;
    using Tefter.Helpers;

    public partial class CreateNewServiceBookFormOne : Form
    {
        private ApplicationDbContext dbContext;
        private readonly Logger logger;

        public CreateNewServiceBookFormOne(ApplicationDbContext dbContext, Logger logger)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Location = new Point(0, 0);
            this.dbContext = dbContext;
            this.logger = logger;
        }

        private void Open_CreateNewServiceBookFormTwo_Button_Click(object sender, EventArgs e)
        {
            try
            {
                #region CarData
                var carId = PlateNumber_TextBox.Text.Trim(); //Регистрационен номер
                var brand = Made_TextBox.Text.Trim();
                var model = Model_TextBox.Text.Trim();
                var color = Color_TextBox.Text.Trim();
                var chassisNumber = ChassisNumber_TextBox.Text.Trim();
                var engineNumber = EngineNumber_TextBox.Text.Trim();
                var workingVolumeCubicCm = WorkingVolumeCubicCm_TextBox.Text.Trim();
                var firstRegistration = Convert.ToDateTime(FirstDateRegister_DatePicker.Value, CultureInfo.InvariantCulture);
                var firstRegistrationInBG = Convert.ToDateTime(FirstDateRegisterBG_DatePicker.Value, CultureInfo.InvariantCulture);
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
                var airConditioning = AirConditioning_CheckBox.Checked;
                var climatronic = Climatronic_CheckBox.Checked;
                var hatch = Hatch_CheckBox.Checked;
                var alarm = Alarm_CheckBox.Checked;
                var immobilizer = Immobilizer_CheckBox.Checked;
                var centralLocking = CentralLocking_CheckBox.Checked;
                var electronicGlass = ElectronicGlass_CheckBox.Checked;
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
                if (string.IsNullOrWhiteSpace(kilometers))
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

                var brandRegex = new Regex("^([А-Я-а-я]+)$");
                var modelRegex = new Regex("^([А-Я-а-я]+)$");
                var colorRegex = new Regex("^([А-Я-а-я]+)$");
                var workingVolumeCubicCmRegex = new Regex("^[0-9]*$");
                var plateNumberRegex = new Regex("^[А-Я-а-я]{2}[0-9]{4}[А-Я-а-я]{2}$");
                var kilometersRegex = new Regex("^([0-9]*)$|^([0-9]* [0-9]*)$");
                var ownerRegex = new Regex("^(([А-Я-а-я]+)|([А-Я-а-я]+ [А-Я-а-я]+ [А-Я-а-я]+)|[А-Я-а-я]+ [А-Я-а-я]+)$");
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

                var dbExists = dbContext.Cars.Find(carId);
                if (dbExists != null)
                {
                    MessageBox.Show($"Вече съществува кола с регистрационен номер {carId}. Моля, въведете друг.");
                    return;
                }

                brand = GlobalMethods.CapitalizeFirstLetter(brand);
                model = GlobalMethods.CapitalizeFirstLetter(model);
                color = GlobalMethods.CapitalizeFirstLetter(color);
                owner = GlobalMethods.CapitalizeOwnerName(owner);

                var car = new Car(carId, brand, model, color, chassisNumber, engineNumber, workingVolumeCubicCm, firstRegistration, firstRegistrationInBG, fuelType, kilometers, owner, egn, bulstat, phoneNumber, address);
                var carExtras = new CarExtras(abs, asd, ebs, esp, fourByFour, airConditioning, climatronic, hatch, alarm, immobilizer, centralLocking, electronicGlass, electronicMirrors, automatic, electronicPacket, steeringWheelHydraulics, stereo, cdChanger, amplifier, others);

                car.CarExtras = carExtras;

                var secondForm = new CreateNewServiceBookFormTwo(car, dbContext, logger);
                secondForm.RefToHomePageForm = this;

                Hide();

                secondForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"CreateNewServiceBookFormOne.NextToNewServiceBookFormTwo_Button_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            try
            {
                var homePageForm = new HomePageForm();
                Close();
                homePageForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"CreateNewServiceBookFormOne.BackButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }
    }
}