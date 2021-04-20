using System;
namespace Tefter
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Tefter.DbEntities;
    using Tefter.DbEntities.Helper;

    public partial class SearchServiceBookFormTwo : Form
    {
        private readonly ApplicationDbContext dbContext;

        public SearchServiceBookFormTwo(Car car, ApplicationDbContext dbContext)
        {
            InitializeComponent();

            this.dbContext = dbContext;

            Car = car;
        }

        public Car Car { get; set; }

        private void SearchServiceBookFormTwo_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Car.OilAndFilters.Count(); i++)
            {
                if (Car.OilAndFilters.Count() - 1 != i)
                {
                    OilAndFiltersDataGridView.Rows.Add();
                }

                var parsedJson = Car.OilAndFilters[i].ParseData<OilAndFiltersJsonData>();
                OilAndFiltersDataGridView.Rows[i].Cells[0].Value = parsedJson.Date;
                OilAndFiltersDataGridView.Rows[i].Cells[1].Value = parsedJson.Kilometers;
                OilAndFiltersDataGridView.Rows[i].Cells[2].Value = parsedJson.Oil;
                OilAndFiltersDataGridView.Rows[i].Cells[3].Value = parsedJson.NextChange;
                OilAndFiltersDataGridView.Rows[i].Cells[4].Value = parsedJson.OilFilter;
                OilAndFiltersDataGridView.Rows[i].Cells[5].Value = parsedJson.FuelFilter;
                OilAndFiltersDataGridView.Rows[i].Cells[6].Value = parsedJson.AirFilter;
                OilAndFiltersDataGridView.Rows[i].Cells[7].Value = parsedJson.CoupeFilter;
            }

            //OilAndFilterDataGridView.DataSource = oilsAndFiltersData;
            //OilAndFilterDataGridView.Columns[0].HeaderText = "Дата";
            //OilAndFilterDataGridView.Columns[1].HeaderText = "Километри";
            //OilAndFilterDataGridView.Columns[2].HeaderText = "Масло";
            //OilAndFilterDataGridView.Columns[3].HeaderText = "Следваща смяна (км)";
            //OilAndFilterDataGridView.Columns[4].HeaderText = "Маслен филтър";
            //OilAndFilterDataGridView.Columns[5].HeaderText = "Горивен филтър";
            //OilAndFilterDataGridView.Columns[6].HeaderText = "Въздушен филтър";
            //OilAndFilterDataGridView.Columns[7].HeaderText = "Филтър купе";

            //OilAndFiltersDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //OilAndFiltersDataGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void Search_BackButton_Click(object sender, EventArgs e)
        {
            var searchServiceBookFirstPage = new SearchServiceBookFormOne(Car, dbContext);
            this.Close();
            searchServiceBookFirstPage.Show();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addOilAndFiltersForm = new AddOilAndFiltersForm(Car, OilAndFiltersDataGridView, dbContext, this);
            addOilAndFiltersForm.Show();
        }
    }
}
