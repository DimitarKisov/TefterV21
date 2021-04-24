namespace Tefter
{
    using System;
    using System.Linq;
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
                OtherServicesDataGridView.Columns["Kilometers"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                OtherServicesDataGridView.Columns["ServiceDone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < Car.OtherServices.Count(); i++)
                {
                    if (Car.OtherServices.Count() - 1 >= i)
                    {
                        OtherServicesDataGridView.Rows.Add();
                    }

                    var parsedJson = Car.OtherServices[i].ParseData<OtherServicesJsonData>();
                    OtherServicesDataGridView.Rows[i].Cells[0].Value = Car.OilAndFilters[i].Id;
                    OtherServicesDataGridView.Rows[i].Cells[1].Value = parsedJson.DateMadeChanges;
                    OtherServicesDataGridView.Rows[i].Cells[2].Value = parsedJson.Kilometers;
                    OtherServicesDataGridView.Rows[i].Cells[3].Value = parsedJson.ServiceMade;
                }
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormThree_Load: {ex}");
            }
        }

        private void Search_BackButton_Click(object sender, EventArgs e)
        {
            try
            {
                var searchServiceBookFirstPage = new SearchServiceBookFormOne(Car, dbContext, logger);
                this.Close();
                searchServiceBookFirstPage.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormThree.Search_BackButton_Click: {ex}");
            }
        }
    }
}
