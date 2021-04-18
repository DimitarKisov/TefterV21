using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tefter.DbEntities;

namespace Tefter
{
    public partial class CreateNewServiceBookFormThree : Form
    {
        public static DateTime otherServicesDateMadeChanges = DateTime.Now;
        public static int currentKilometers = -1;
        public static string changesMadeDescription = string.Empty;

        public CreateNewServiceBookFormThree()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

        }

        public Car Car { get; set; }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            //var secondForm = new CreateNewServiceBookFormTwo(Car);
            //secondForm.Show();
        }

        private void End_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
