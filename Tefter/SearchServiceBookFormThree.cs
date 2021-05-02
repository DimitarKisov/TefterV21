namespace Tefter
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Tefter.DbEntities;
    using Tefter.DbEntities.Helper;
    using Tefter.Helpers;

    public partial class SearchServiceBookFormThree : Form
    {
        private readonly ApplicationDbContext dbContext;
        private Logger logger;

        public SearchServiceBookFormThree(Car car, ApplicationDbContext dbContext, Logger logger)
        {
            InitializeComponent();

            this.dbContext = dbContext;
            this.logger = logger;

            Car = car;
        }

        public Car Car { get; set; }

        private void SearchServiceBookFormThree_Load(object sender, EventArgs e)
        {
            try
            {
                OtherServicesDataGridView.Columns["Id"].Visible = false;

                OtherServicesDataGridView.Columns["DateMadeChanges"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                OtherServicesDataGridView.Columns["DateMadeChanges"].ReadOnly = false;
                
                OtherServicesDataGridView.Columns["Kilometers"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                OtherServicesDataGridView.Columns["Kilometers"].ReadOnly = false;

                OtherServicesDataGridView.Columns["ServiceDone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                OtherServicesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                for (int i = 0; i < Car.OtherServices.Count(); i++)
                {
                    if (Car.OtherServices.Count() - 1 >= i)
                    {
                        OtherServicesDataGridView.Rows.Add();
                    }

                    var parsedJson = Car.OtherServices[i].ParseData<OtherServicesJsonData>();
                    OtherServicesDataGridView.Rows[i].Cells[0].Value = Car.OtherServices[i].Id;
                    OtherServicesDataGridView.Rows[i].Cells[1].Value = parsedJson.DateMadeChanges;
                    OtherServicesDataGridView.Rows[i].Cells[2].Value = parsedJson.Kilometers;
                    OtherServicesDataGridView.Rows[i].Cells[3].Value = parsedJson.ServiceMade;
                }
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormThree.SearchServiceBookFormThree_Load: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void Search_BackButton_Click(object sender, EventArgs e)
        {
            try
            {
                var searchServiceBookFirstPage = new SearchServiceBookFormOne(Car, dbContext, logger);
                Close();
                searchServiceBookFirstPage.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormThree.Search_BackButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                var addOtherServicesForm = new AddOtherServicesForm(Car, OtherServicesDataGridView, dbContext, logger);
                addOtherServicesForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormThree.AddButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < Car.OtherServices.Count(); i++)
                {
                    var id = (int)OtherServicesDataGridView.Rows[i].Cells[0].Value;
                    var dateMadeChanges = (string)OtherServicesDataGridView.Rows[i].Cells[1].Value;
                    var kilometers = (string)OtherServicesDataGridView.Rows[i].Cells[2].Value;
                    var servicesMade = (string)OtherServicesDataGridView.Rows[i].Cells[3].Value;

                    var sb = new StringBuilder();
                    var emptyOrWrongFields = new List<string>();

                    if (string.IsNullOrWhiteSpace(dateMadeChanges))
                    {
                        emptyOrWrongFields.Add("Дата");
                    }

                    if (string.IsNullOrWhiteSpace(kilometers))
                    {
                        emptyOrWrongFields.Add("Км");
                    }

                    if (string.IsNullOrWhiteSpace(servicesMade))
                    {
                        emptyOrWrongFields.Add("Извършена сервизна дейност");
                    }

                    if (emptyOrWrongFields.Count() > 0)
                    {
                        sb.AppendLine("Моля попълнете следните полета: ");
                        sb.AppendLine(string.Join(", ", emptyOrWrongFields.Select(x => x)));

                        MessageBox.Show(sb.ToString());
                        return;
                    }

                    var dateMadeChangesRegex = new Regex(@"^([1-9]|([012][0-9])|(3[01]))\.([0]{0,1}[1-9]|1[012])\.\d\d\d\d (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$");
                    var currentKilometersRegex = new Regex("^([0-9]*)$|^([0-9]* [0-9]*)$");

                    if (!dateMadeChangesRegex.IsMatch(dateMadeChanges))
                    {
                        emptyOrWrongFields.Add("Дата");
                    }

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

                    var otherServicesMade = new OtherServicesJsonData(dateMadeChanges, kilometers, servicesMade);
                    var parsedJson = JsonConvert.SerializeObject(otherServicesMade);

                    Car.OtherServices.FirstOrDefault(x => x.Id == id).Data = parsedJson;
                }

                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormThree.SaveChangesButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void SearchServiceBookFormThree_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var columnName = OtherServicesDataGridView.Columns[e.ColumnIndex].Name;

                if (columnName == "ServiceDone")
                {
                    var readServiceMadeForm = new ReadServicesMadeForm(OtherServicesDataGridView, e.ColumnIndex, e.RowIndex, logger);
                    readServiceMadeForm.Show();
                }
                else if (columnName == "DateMadeChanges" || columnName == "Kilometers")
                {
                    var cell = OtherServicesDataGridView[e.ColumnIndex, e.RowIndex];
                    OtherServicesDataGridView.CurrentCell = cell;
                    OtherServicesDataGridView.BeginEdit(true);
                }
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormThree.SearchServiceBookFormThree_CellDoubleClick: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void DeleteRecordButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = OtherServicesDataGridView.SelectedRows;

                foreach (DataGridViewRow row in selectedRows)
                {
                    var id = (int)row.Cells["Id"].Value;
                    var itemForRemove = Car.OtherServices.FirstOrDefault(x => x.Id == id);

                    Car.OtherServices.Remove(itemForRemove);
                    OtherServicesDataGridView.Rows.Remove(row);
                }

                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormThree.DeleteRecordButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }
    }
}
