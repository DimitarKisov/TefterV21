﻿namespace Tefter
{
    using System;
    using System.Windows.Forms;
    using Tefter.DbEntities;
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
                this.Close();
                homePageForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormOne.BackButton_Click: {ex}");
            }
        }

        private void SearcheServiceBookFormOne_Load(object sender, EventArgs e)
        {
            try
            {
                Search_PlateNumber_TextBox.Text = Car.Id;
                Search_Made_TextBox.Text = Car.CarData.Brand;
                Search_Model_TextBox.Text = Car.CarData.Model;
                Search_Color_TextBox.Text = Car.CarData.Color;
                Search_ChassisNumber_TextBox.Text = Car.CarData.ChassisNumber;
                Search_EngineNumber_TextBox.Text = Car.CarData.EngineNumber;
                Search_WorkingVolumeCubicCm_TextBox.Text = Car.CarData.WorkingVolumeCubicCm;
                Search_FirstDateRegister_DatePicker.Value = Car.CarData.FirstRegisterDate;
                Search_FirstDateRegisterBG_DatePicker.Value = Car.CarData.FirstRegisterDate;
                Search_CurrentKilometers_TextBox.Text = Car.CarData.Kilometers;
                Search_OwnerName_TextBox.Text = Car.CarData.Owner;
                Search_Egn_TextBox.Text = Car.CarData.Egn;
                Search_Bulstat_TextBox.Text = Car.CarData.Bulstat;
                Search_PhoneNumber_TextBox.Text = Car.CarData.PhoneNumber;
                Search_Address_TextBox.Text = Car.CarData.Address;

                Search_Abs_CheckBox.Checked = Car.CarData.CarExtras.Abs;
                Search_Asd_CheckBox.Checked = Car.CarData.CarExtras.Asd;
                Search_Ebs_CheckBox.Checked = Car.CarData.CarExtras.Ebs;
                Search_Arb_CheckBox.Checked = Car.CarData.CarExtras.Arb;
                Search_Esp_CheckBox.Checked = Car.CarData.CarExtras.Esp;
                Search_FourByFour_CheckBox.Checked = Car.CarData.CarExtras.FourByFour;
                Search_AirConditioning_CheckBox.Checked = Car.CarData.CarExtras.AirConditioning;
                Search_Climatronic_CheckBox.Checked = Car.CarData.CarExtras.Climatronic;
                Search_Hatch_CheckBox.Checked = Car.CarData.CarExtras.Hatch;
                Search_Alarm_CheckBox.Checked = Car.CarData.CarExtras.Alarm;
                Search_Immobilizer_CheckBox.Checked = Car.CarData.CarExtras.Immobilizer;
                Search_CentralLocking_CheckBox.Checked = Car.CarData.CarExtras.CentralLocking;
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
                logger.WriteLine($"SearcheServiceBookFormOne_Load: {ex}");
            }
        }

        private void NextToSearchServiceBookFormTwo_Button_Click(object sender, EventArgs e)
        {
            try
            {
                var secondSearchForm = new SearchServiceBookFormTwo(Car, dbContext, logger);
                this.Hide();
                secondSearchForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"NextToSearchServiceBookFormTwo_Button_Click: {ex}");
            }
        }

        private void LoadOtherServiceButton_Click(object sender, EventArgs e)
        {

        }
    }
}
