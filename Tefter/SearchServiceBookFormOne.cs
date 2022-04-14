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

        private void SearcheServiceBookFormOne_Load(object sender, EventArgs e)
        {
            try
            {
                if (Screen.PrimaryScreen.WorkingArea.Width != 1920 || Screen.PrimaryScreen.WorkingArea.Height != 1080)
                {
                    Size = new Size(Screen.PrimaryScreen.WorkingArea.Width - 30, Screen.PrimaryScreen.WorkingArea.Height - 50);
                }

                PlateNumber_TextBox.Text = Car.Id;
                Made_TextBox.Text = Car.Brand;
                Model_TextBox.Text = Car.Model;
                Color_TextBox.Text = Car.Color;
                ChassisNumber_TextBox.Text = Car.ChassisNumber;
                EngineNumber_TextBox.Text = Car.EngineNumber;
                WorkingVolumeCubicCm_TextBox.Text = Car.WorkingVolumeCubicCm;
                FirstDateRegister_DatePicker.Value = Car.FirstRegisterDate;
                FirstDateRegisterBG_DatePicker.Value = Car.FirstRegisterDate;
                CurrentKilometers_TextBox.Text = Car.Kilometers;
                OwnerName_TextBox.Text = Car.Owner;
                Egn_TextBox.Text = Car.Egn;
                Bulstat_TextBox.Text = Car.Bulstat;
                PhoneNumber_TextBox.Text = Car.PhoneNumber;
                Address_TextBox.Text = Car.Address;

                switch (Car.FuelType)
                {
                    case FuelType.Diesel: FuelType_Diesel_RadioButton.Checked = true; break;
                    case FuelType.Gasoline: FuelType_Gasoline_RadioButton.Checked = true; break;
                    case FuelType.AGU: FuelType_Gas_RadioButton.Checked = true; break;
                    case FuelType.Methane: FuelType_Methane_RadioButton.Checked = true; break;
                }

                var carExtras = dbContext.CarExtras.FirstOrDefault(x => x.CarId == Car.Id);
                if (carExtras != null)
                {
                    Abs_CheckBox.Checked = carExtras.Abs;
                    Asd_CheckBox.Checked = carExtras.Asd;
                    Ebs_CheckBox.Checked = carExtras.Ebs;
                    Arb_CheckBox.Checked = carExtras.Arb;
                    Esp_CheckBox.Checked = carExtras.Esp;
                    FourByFour_CheckBox.Checked = carExtras.FourByFour;
                    AirConditioning_CheckBox.Checked = carExtras.AirConditioning;
                    Climatronic_CheckBox.Checked = carExtras.Climatronic;
                    Hatch_CheckBox.Checked = carExtras.Hatch;
                    Alarm_CheckBox.Checked = carExtras.Alarm;
                    Immobilizer_CheckBox.Checked = carExtras.Immobilizer;
                    CentralLocking_CheckBox.Checked = carExtras.CentralLocking;
                    ElectronicGlass_CheckBox.Checked = carExtras.ElectronicGlass;
                    ElectronicMirror_CheckBox.Checked = carExtras.ElectronicMirrors;
                    Automatic_CheckBox.Checked = carExtras.Automatic;
                    ElectronicPacket_CheckBox.Checked = carExtras.ElectronicPacket;
                    SteeringWheelHydraulics_CheckBox.Checked = carExtras.SteeringWheelHydraulics;
                    Stereo_CheckBox.Checked = carExtras.Stereo;
                    CdChanger_CheckBox.Checked = carExtras.CdChanger;
                    Amplifier_CheckBox.Checked = carExtras.Amplifier;
                    Others_TextBox.Text = carExtras.Other;
                }
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormOne.SearcheServiceBookFormOne_Load: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                #region CarData
                //var carId = PlateNumber_TextBox.Text.Trim();
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
                //if (string.IsNullOrWhiteSpace(carId))
                //{
                //    emptyOrWrongFields.Add("Регистрационен номер");
                //}
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
                //var plateNumberRegex = new Regex("^[А-Я-а-я]{2}[0-9]{4}[А-Я-а-я]{2}$");
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
                //if (!plateNumberRegex.IsMatch(carId))
                //{
                //    emptyOrWrongFields.Add("Регистрационен номер");
                //}
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
                //if (Car.Id != carId)
                //{
                //    var oilAndFilters = dbContext.OilAndFilters.Where(x => x.CarId == Car.Id).ToList();
                //    var otherServices = dbContext.OtherServices.Where(x => x.CarId == Car.Id).ToList();
                //    var carExtras = dbContext.CarExtras.FirstOrDefault(x => x.CarId == Car.Id);

                //    oilAndFilters.ForEach(x => x.CarId = carId);
                //    otherServices.ForEach(x => x.CarId = carId);
                //    carExtras.CarId = carId;

                //    Car.Id = carId;
                //}
                
                Car.Brand = brand;
                Car.Model = model;
                Car.Color = color;
                Car.ChassisNumber = chassisNumber;
                Car.EngineNumber = engineNumber;
                Car.FuelType = fuelType;
                Car.WorkingVolumeCubicCm = workingVolumeCubicCm;
                Car.FirstRegisterDate = firstRegistration;
                Car.FirstRegisterDateInBg = firstRegistrationInBG;
                Car.Kilometers = kilometers;
                Car.Owner = owner;
                Car.Egn = egn;
                Car.Bulstat = bulstat;
                Car.PhoneNumber = phoneNumber;
                Car.Address = address;
                #endregion

                #region CarExtras
                Car.CarExtras.Abs = abs;
                Car.CarExtras.Asd = asd;
                Car.CarExtras.Ebs = ebs;
                Car.CarExtras.Arb = arb;
                Car.CarExtras.Esp = esp;
                Car.CarExtras.FourByFour = fourByFour;
                Car.CarExtras.AirConditioning = airConditioning;
                Car.CarExtras.Climatronic = climatronic;
                Car.CarExtras.Hatch = hatch;
                Car.CarExtras.Alarm = alarm;
                Car.CarExtras.Immobilizer = immobilizer;
                Car.CarExtras.CentralLocking = centralLocking;
                Car.CarExtras.ElectronicGlass = electronicGlass;
                Car.CarExtras.ElectronicMirrors = electronicMirrors;
                Car.CarExtras.Automatic = automatic;
                Car.CarExtras.ElectronicPacket = electronicPacket;
                Car.CarExtras.SteeringWheelHydraulics = steeringWheelHydraulics;
                Car.CarExtras.Stereo = stereo;
                Car.CarExtras.CdChanger = cdChanger;
                Car.CarExtras.Amplifier = amplifier;
                Car.CarExtras.Other = others;
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
                var oilAndFilters = dbContext.OilAndFilters.Where(x => x.CarId == Car.Id);
                var otherServices = dbContext.OtherServices.Where(x => x.CarId == Car.Id);
                dbContext.OilAndFilters.RemoveRange(oilAndFilters);
                dbContext.OtherServices.RemoveRange(otherServices);
                dbContext.CarExtras.Remove(Car.CarExtras);
                dbContext.Cars.Remove(Car);

                dbContext.SaveChanges();

                MessageBox.Show("Успешно изтрит запис.");

                var homePage = new HomePageForm(dbContext);
                Close();
                homePage.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormOne.DeleteRecordButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void LoadSearchServiceBookFormTwoButton_Click(object sender, EventArgs e)
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

        private void BackButton_Click(object sender, EventArgs e)
        {
            try
            {
                var homePageForm = new HomePageForm(dbContext);
                Close();
                homePageForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormOne.BackButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        } 
    }
}
