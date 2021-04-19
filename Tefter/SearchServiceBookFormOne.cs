namespace Tefter
{
    using System;
    using System.Windows.Forms;
    using Tefter.DbEntities;

    public partial class SearchServiceBookFormOne : Form
    {
        public SearchServiceBookFormOne(Car car)
        {
            InitializeComponent();

            Car = car;
        }

        public Car Car { get; set; }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            var homePageForm = new HomePageForm();
            homePageForm.Show();
        }

        private void SearcheServiceBookFormOne_Load(object sender, EventArgs e)
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

        private void NextToSearchServiceBookFormTwo_Button_Click(object sender, EventArgs e)
        {
            var secondSearchForm = new SearchServiceBookFormTwo(Car);
            this.Hide();
            secondSearchForm.Show();
        }
    }
}
