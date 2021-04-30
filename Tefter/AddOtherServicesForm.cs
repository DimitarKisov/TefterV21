namespace Tefter
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Tefter.DbEntities;
    using Tefter.DbEntities.Helper;
    using Tefter.Helpers;

    public partial class AddOtherServicesForm : Form
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Logger logger;

        public AddOtherServicesForm(Car car, DataGridView otherServicesDataGridView, ApplicationDbContext dbContext, Logger logger)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(800, 100);

            this.dbContext = dbContext;
            this.logger = logger;

            Car = car;
            OtherServicesDataGridView = otherServicesDataGridView;
        }

        public Car Car { get; set; }

        public DataGridView OtherServicesDataGridView { get; set; }

        private void AddOtherServicesRow_Click(object sender, EventArgs e)
        {
            try
            {
                var dateMadeChanges = DateMadeChanges_DatePicker.Value;
                var kilometers = CurrentKilometers_TextBox.Text.Trim();
                var serviceMade = Description_TextBox.Text.Trim();

                var sb = new StringBuilder();
                var emptyOrWrongFields = new List<string>();

                if (string.IsNullOrWhiteSpace(kilometers))
                {
                    emptyOrWrongFields.Add("Км");
                }

                var currentKilometersRegex = new Regex("^([0-9]*)$|^([0-9]* [0-9]*)$");

                if (!currentKilometersRegex.IsMatch(kilometers))
                {
                    emptyOrWrongFields.Add("Км");
                }

                if (emptyOrWrongFields.Count() > 0)
                {
                    sb.AppendLine("Моля въведете коректни данни за следните полета: ");
                    sb.AppendLine(string.Join(", ", emptyOrWrongFields.Select(x => x)));
                    MessageBox.Show(sb.ToString());
                    return;
                }

                var toStringedDate = dateMadeChanges.ToString("dd.M.yyyy HH:mm:ss");
                var jsonData = new OtherServicesJsonData(toStringedDate, kilometers, serviceMade);
                var data = JsonConvert.SerializeObject(jsonData);
                var otherServices = new OtherService(data);

                Car.OtherServices.Add(otherServices);

                dbContext.SaveChanges();

                OtherServicesDataGridView.Rows.Add();
                var rowsCountWithNewRow = OtherServicesDataGridView.Rows.Count - 1;

                OtherServicesDataGridView.Rows[rowsCountWithNewRow].Cells[0].Value = Car.OtherServices.First().Id;
                OtherServicesDataGridView.Rows[rowsCountWithNewRow].Cells[1].Value = jsonData.DateMadeChanges;
                OtherServicesDataGridView.Rows[rowsCountWithNewRow].Cells[2].Value = jsonData.Kilometers;
                OtherServicesDataGridView.Rows[rowsCountWithNewRow].Cells[3].Value = jsonData.ServiceMade;

                Close();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"AddOtherServicesForm.AddOtherServicesRow_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }
    }
}
