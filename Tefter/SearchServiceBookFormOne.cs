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
            this.Car = car;
        }

        public Car Car { get; set; }

        private void SearcheServiceBookFormOne_Load(object sender, EventArgs e)
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

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            var emptyOrWrongFields = new List<string>();

            if (string.IsNullOrWhiteSpace(Made_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Марка");
            }
            if (string.IsNullOrWhiteSpace(Model_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Модел");
            }
            //if (string.IsNullOrWhiteSpace(carId))
            //{
            //    emptyOrWrongFields.Add("Регистрационен номер");
            //}
            if (string.IsNullOrWhiteSpace(CurrentKilometers_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Км");
            }
            if (string.IsNullOrWhiteSpace(OwnerName_TextBox.Text.Trim()))
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

            if (!brandRegex.IsMatch(Made_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Марка");
            }
            if (!modelRegex.IsMatch(Model_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Модел");
            }
            if (!kilometersRegex.IsMatch(CurrentKilometers_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Км");
            }
            if (!ownerRegex.IsMatch(OwnerName_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Собственик");
            }
            if (!colorRegex.IsMatch(Color_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Цвят");
            }
            if (!workingVolumeCubicCmRegex.IsMatch(WorkingVolumeCubicCm_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Работен обем куб. см");
            }
            //if (!plateNumberRegex.IsMatch(carId))
            //{
            //    emptyOrWrongFields.Add("Регистрационен номер");
            //}
            
            if (!egnRegex.IsMatch(Egn_TextBox.Text.Trim()) && !string.IsNullOrWhiteSpace(Egn_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("ЕГН");
            }
            if (!phoneNumberRegex.IsMatch(PhoneNumber_TextBox.Text.Trim()) && !string.IsNullOrWhiteSpace(PhoneNumber_TextBox.Text.Trim()))
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

            #region CarData
            //var carId = PlateNumber_TextBox.Text.Trim();
            var brand = Made_TextBox.Text.Trim();
            var model = Model_TextBox.Text.Trim();
            var kilometers = CurrentKilometers_TextBox.Text.Trim();
            var owner = OwnerName_TextBox.Text.Trim();
            var color = Color_TextBox.Text.Trim();
            var workingVolumeCubicCm = WorkingVolumeCubicCm_TextBox.Text.Trim();
            var egn = Egn_TextBox.Text.Trim();
            var phoneNumber = PhoneNumber_TextBox.Text.Trim();
            var chassisNumber = ChassisNumber_TextBox.Text.Trim();
            var engineNumber = EngineNumber_TextBox.Text.Trim();
            var firstRegistration = Convert.ToDateTime(FirstDateRegister_DatePicker.Value, CultureInfo.InvariantCulture);
            var firstRegistrationInBG = Convert.ToDateTime(FirstDateRegisterBG_DatePicker.Value, CultureInfo.InvariantCulture);
            var bulstat = Bulstat_TextBox.Text.Trim();
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

            this.Car.Brand = brand;
            this.Car.Model = model;
            this.Car.Color = color;
            this.Car.ChassisNumber = chassisNumber;
            this.Car.EngineNumber = engineNumber;
            this.Car.FuelType = fuelType;
            this.Car.WorkingVolumeCubicCm = workingVolumeCubicCm;
            this.Car.FirstRegisterDate = firstRegistration;
            this.Car.FirstRegisterDateInBg = firstRegistrationInBG;
            this.Car.Kilometers = kilometers;
            this.Car.Owner = owner;
            this.Car.Egn = egn;
            this.Car.Bulstat = bulstat;
            this.Car.PhoneNumber = phoneNumber;
            this.Car.Address = address;
            #endregion

            #region CarExtras
            this.Car.CarExtras.Abs = abs;
            this.Car.CarExtras.Asd = asd;
            this.Car.CarExtras.Ebs = ebs;
            this.Car.CarExtras.Arb = arb;
            this.Car.CarExtras.Esp = esp;
            this.Car.CarExtras.FourByFour = fourByFour;
            this.Car.CarExtras.AirConditioning = airConditioning;
            this.Car.CarExtras.Climatronic = climatronic;
            this.Car.CarExtras.Hatch = hatch;
            this.Car.CarExtras.Alarm = alarm;
            this.Car.CarExtras.Immobilizer = immobilizer;
            this.Car.CarExtras.CentralLocking = centralLocking;
            this.Car.CarExtras.ElectronicGlass = electronicGlass;
            this.Car.CarExtras.ElectronicMirrors = electronicMirrors;
            this.Car.CarExtras.Automatic = automatic;
            this.Car.CarExtras.ElectronicPacket = electronicPacket;
            this.Car.CarExtras.SteeringWheelHydraulics = steeringWheelHydraulics;
            this.Car.CarExtras.Stereo = stereo;
            this.Car.CarExtras.CdChanger = cdChanger;
            this.Car.CarExtras.Amplifier = amplifier;
            this.Car.CarExtras.Other = others;
            #endregion

            try
            {
                this.dbContext.SaveChanges();
                MessageBox.Show("Успешно направени промени.");
            }
            catch (Exception ex)
            {
                this.logger.WriteLine($"SearchServiceBookFormOne.SaveChangesButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void DeleteRecordButton_Click(object sender, EventArgs e)
        {
            try
            {
                var oilAndFilters = this.dbContext.OilAndFilters.Where(x => x.CarId == Car.Id);
                var otherServices = this.dbContext.OtherServices.Where(x => x.CarId == Car.Id);
                this.dbContext.OilAndFilters.RemoveRange(oilAndFilters);
                this.dbContext.OtherServices.RemoveRange(otherServices);
                this.dbContext.CarExtras.Remove(Car.CarExtras);
                this.dbContext.Cars.Remove(Car);

                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.WriteLine($"SearchServiceBookFormOne.DeleteRecordButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }

            MessageBox.Show("Успешно изтрит запис.");

            var homePage = new HomePageForm(dbContext, logger);
            this.Close();
            homePage.Show();
        }

        private void LoadSearchServiceBookFormTwoButton_Click(object sender, EventArgs e)
        {
            var secondSearchForm = new SearchServiceBookFormTwo(Car, dbContext, logger);
            this.Hide();
            secondSearchForm.Show();
        }

        private void LoadOtherServiceButton_Click_Click(object sender, EventArgs e)
        {
            var thirdSearchForm = new SearchServiceBookFormThree(Car, dbContext, logger);
            this.Hide();
            thirdSearchForm.Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var homePageForm = new HomePageForm(dbContext, logger);
            this.Close();
            homePageForm.Show();
        } 
    }
}
