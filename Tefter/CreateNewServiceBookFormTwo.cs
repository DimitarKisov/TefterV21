namespace Tefter
{
    using System;
    using System.Drawing;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Tefter.DbEntities;

    public partial class CreateNewServiceBookFormTwo : Form
    {
        private static DateTime dateMadeChanges = DateTime.Now;
        private static string oil = null;
        private static int currentKilometers = -1;
        private static int nextOilChangeKilometers = -1;
        private static string oilFilter = null;
        private static string fuelFilter = null;
        private static string airFilter = null;
        private static string coupeFilter = null;

        private ApplicationDbContext dbContext;

        public CreateNewServiceBookFormTwo(Car car, ApplicationDbContext dbContext)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            Car = car;
            this.dbContext = dbContext;
        }

        public Car Car { get; set; }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            dateMadeChanges = DateMadeChanges_DatePicker.Value;
            oil = Oil_TextBox.Text.Trim();
            oilFilter = OilFilter_TextBox.Text.Trim();
            fuelFilter = FuelFilter_TextBox.Text.Trim();
            airFilter = AirFilter_TextBox.Text.Trim();
            coupeFilter = CoupeFilter_TextBox.Text.Trim();

            var emptyRequiredInfo = false;
            var sb = new StringBuilder();
            sb.Append("Моля попълнете следните полета: ");

            if (string.IsNullOrWhiteSpace(CurrentKilometers_TextBox.Text.Trim()))
            {
                sb.AppendLine("Км, ");
                emptyRequiredInfo = true;
            }
            if (string.IsNullOrWhiteSpace(NextOilChangeKilometers_TextBox.Text.Trim()))
            {
                sb.AppendLine("Следваща смяна на (км), ");
                emptyRequiredInfo = true;
            }

            if (emptyRequiredInfo)
            {
                MessageBox.Show(string.Join("", sb.ToString()));
                return;
            }

            currentKilometers = int.Parse(CurrentKilometers_TextBox.Text.Replace(" ", string.Empty));
            nextOilChangeKilometers = int.Parse(NextOilChangeKilometers_TextBox.Text.Replace(" ", string.Empty));

            var currentKilometersRegex = new Regex("^([0-9]+)$");
            var nextOilChangeKilometersRegex = new Regex("^([0-9]+)$");

            sb.Clear();
            sb.Append("Моля въведете коректни данни за следните полета: ");
            var wrongDateInserted = false;

            
            if (!currentKilometersRegex.IsMatch(currentKilometers.ToString()))
            {
                sb.Append("Км, ");
                wrongDateInserted = true;
            }
            if (!nextOilChangeKilometersRegex.IsMatch(nextOilChangeKilometers.ToString()))
            {
                sb.Append("Следваща смяна на (км)");
                wrongDateInserted = true;
            }

            if (wrongDateInserted)
            {
                MessageBox.Show(string.Join("", sb.ToString()));
                return;
            }

            this.Hide();
            var thirdForm = new CreateNewServiceBookFormThree();
            thirdForm.Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            var firstForm = new CreateNewServiceBookFormOne();
            firstForm.Show();
        }
    }
}
