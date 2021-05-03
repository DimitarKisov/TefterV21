namespace Tefter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Tefter.DbEntities;
    using Tefter.DbEntities.Enums;
    using Tefter.Helpers;

    public partial class SearchServiceBookFormOne : Form
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Logger logger;

        public SearchServiceBookFormOne(Car car, ApplicationDbContext dbContext, Logger logger)
        {
            InitializeComponent();

            this.dbContext = dbContext;
            this.logger = logger;

            Car = car;
        }

        public Car Car { get; set; }

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
                logger.WriteLine($"SearchServiceBookFormOne.BackButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void SearcheServiceBookFormOne_Load(object sender, EventArgs e)
        {
            try
            {
                PlateNumber_TextBox.Text = Car.Id;
                Made_TextBox.Text = Car.CarData.Brand;
                Model_TextBox.Text = Car.CarData.Model;
                Color_TextBox.Text = Car.CarData.Color;
                ChassisNumber_TextBox.Text = Car.CarData.ChassisNumber;
                EngineNumber_TextBox.Text = Car.CarData.EngineNumber;
                WorkingVolumeCubicCm_TextBox.Text = Car.CarData.WorkingVolumeCubicCm;
                FirstDateRegister_DatePicker.Value = Car.CarData.FirstRegisterDate;
                FirstDateRegisterBG_DatePicker.Value = Car.CarData.FirstRegisterDate;
                CurrentKilometers_TextBox.Text = Car.CarData.Kilometers;
                OwnerName_TextBox.Text = Car.CarData.Owner;
                Egn_TextBox.Text = Car.CarData.Egn;
                Bulstat_TextBox.Text = Car.CarData.Bulstat;
                PhoneNumber_TextBox.Text = Car.CarData.PhoneNumber;
                Address_TextBox.Text = Car.CarData.Address;

                switch (Car.CarData.FuelType)
                {
                    case FuelType.Diesel:FuelType_Diesel_RadioButton.Checked = true; break;
                    case FuelType.Gasoline:FuelType_Gasoline_RadioButton.Checked = true; break;
                    case FuelType.AGU:FuelType_Gas_RadioButton.Checked = true; break;
                    case FuelType.Methane:FuelType_Methane_RadioButton.Checked = true; break;
                }

                Abs_CheckBox.Checked = Car.CarData.CarExtras.Abs;
                Asd_CheckBox.Checked = Car.CarData.CarExtras.Asd;
                Ebs_CheckBox.Checked = Car.CarData.CarExtras.Ebs;
                Arb_CheckBox.Checked = Car.CarData.CarExtras.Arb;
                Esp_CheckBox.Checked = Car.CarData.CarExtras.Esp;
                FourByFour_CheckBox.Checked = Car.CarData.CarExtras.FourByFour;
                AirConditioning_CheckBox.Checked = Car.CarData.CarExtras.AirConditioning;
                Climatronic_CheckBox.Checked = Car.CarData.CarExtras.Climatronic;
                Hatch_CheckBox.Checked = Car.CarData.CarExtras.Hatch;
                Alarm_CheckBox.Checked = Car.CarData.CarExtras.Alarm;
                Immobilizer_CheckBox.Checked = Car.CarData.CarExtras.Immobilizer;
                CentralLocking_CheckBox.Checked = Car.CarData.CarExtras.CentralLocking;
                ElectronicGlass_CheckBox.Checked = Car.CarData.CarExtras.ElectronicGlass;
                ElectronicMirror_CheckBox.Checked = Car.CarData.CarExtras.ElectronicMirrors;
                Automatic_CheckBox.Checked = Car.CarData.CarExtras.Automatic;
                ElectronicPacket_CheckBox.Checked = Car.CarData.CarExtras.ElectronicPacket;
                SteeringWheelHydraulics_CheckBox.Checked = Car.CarData.CarExtras.SteeringWheelHydraulics;
                Stereo_CheckBox.Checked = Car.CarData.CarExtras.Stereo;
                CdChanger_CheckBox.Checked = Car.CarData.CarExtras.CdChanger;
                Amplifier_CheckBox.Checked = Car.CarData.CarExtras.Amplifier;
                Others_TextBox.Text = Car.CarData.CarExtras.Other;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormOne.SearcheServiceBookFormOne_Load: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void NextToSearchServiceBookFormTwo_Button_Click(object sender, EventArgs e)
        {
            try
            {
                var secondSearchForm = new SearchServiceBookFormTwo(Car, dbContext, logger);
                Hide();
                secondSearchForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormOne.NextToSearchServiceBookFormTwo_Button_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void LoadOtherServiceButton_Click_Click(object sender, EventArgs e)
        {
            try
            {
                var thirdSearchForm = new SearchServiceBookFormThree(Car, dbContext, logger);
                Hide();
                thirdSearchForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormOne.LoadOtherServiceButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                #region CarData
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

                brand = GlobalMethods.CapitalizeFirstLetter(brand);
                model = GlobalMethods.CapitalizeFirstLetter(model);
                color = GlobalMethods.CapitalizeFirstLetter(color);
                owner = GlobalMethods.CapitalizeOwnerName(owner);

                #region CarData
                Car.CarData.Brand = brand;
                Car.CarData.Model = model;
                Car.CarData.Color = color;
                Car.CarData.ChassisNumber = chassisNumber;
                Car.CarData.EngineNumber = engineNumber;
                Car.CarData.FuelType = fuelType;
                Car.CarData.WorkingVolumeCubicCm = workingVolumeCubicCm;
                Car.CarData.FirstRegisterDate = firstRegistration;
                Car.CarData.FirstRegisterDateInBg = firstRegistrationInBG;
                Car.CarData.Kilometers = kilometers;
                Car.CarData.Owner = owner;
                Car.CarData.Egn = egn;
                Car.CarData.Bulstat = bulstat;
                Car.CarData.PhoneNumber = phoneNumber;
                Car.CarData.Address = address;
                #endregion

                #region CarExtras
                Car.CarData.CarExtras.Abs = abs;
                Car.CarData.CarExtras.Asd = asd;
                Car.CarData.CarExtras.Ebs = ebs;
                Car.CarData.CarExtras.Arb = arb;
                Car.CarData.CarExtras.Esp = esp;
                Car.CarData.CarExtras.FourByFour = fourByFour;
                Car.CarData.CarExtras.AirConditioning = airConditioning;
                Car.CarData.CarExtras.Climatronic = climatronic;
                Car.CarData.CarExtras.Hatch = hatch;
                Car.CarData.CarExtras.Alarm = alarm;
                Car.CarData.CarExtras.Immobilizer = immobilizer;
                Car.CarData.CarExtras.CentralLocking = centralLocking;
                Car.CarData.CarExtras.ElectronicGlass = electronicGlass;
                Car.CarData.CarExtras.ElectronicMirrors = electronicMirrors;
                Car.CarData.CarExtras.Automatic = automatic;
                Car.CarData.CarExtras.ElectronicPacket = electronicPacket;
                Car.CarData.CarExtras.SteeringWheelHydraulics = steeringWheelHydraulics;
                Car.CarData.CarExtras.Stereo = stereo;
                Car.CarData.CarExtras.CdChanger = cdChanger;
                Car.CarData.CarExtras.Amplifier = amplifier;
                Car.CarData.CarExtras.Other = others;
                #endregion

                dbContext.SaveChanges();

                MessageBox.Show("Успешно направени промени.");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormOne.SaveChangesButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void DeleteRecordButton_Click(object sender, EventArgs e)
        {
            try
            {
                dbContext.OilAndFilters.RemoveRange(Car.OilAndFilters);
                dbContext.OtherServices.RemoveRange(Car.OtherServices);
                dbContext.CarExtras.Remove(Car.CarData.CarExtras);
                dbContext.CarDatas.Remove(Car.CarData);
                dbContext.Cars.Remove(Car);

                MessageBox.Show("Успешно изтрит запис.");

                var homePage = new HomePageForm();
                Close();
                homePage.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormOne.DeleteRecordButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }
    }
}
