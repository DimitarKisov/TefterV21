using System;
namespace Tefter
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Tefter.DbEntities;
    using Tefter.DbEntities.Helper;

    public partial class SearchServiceBookFormTwo : Form
    {
        public SearchServiceBookFormTwo(Car car)
        {
            InitializeComponent();

            Car = car;
        }

        public Car Car { get; set; }

        private void SearchServiceBookFormTwo_Load(object sender, EventArgs e)
        {
            var oilsAndFiltersData = new List<OilAndFiltersJsonData>();
            foreach (var item in Car.OilAndFilters)
            {
                oilsAndFiltersData.Add(item.ParseData<OilAndFiltersJsonData>());
            }

            OilAndFilterDataGridView.DataSource = oilsAndFiltersData;
            OilAndFilterDataGridView.Columns[0].HeaderText = "Дата";
            OilAndFilterDataGridView.Columns[1].HeaderText = "Километри";
            OilAndFilterDataGridView.Columns[2].HeaderText = "Масло";
            OilAndFilterDataGridView.Columns[3].HeaderText = "Следваща смяна (км)";
            OilAndFilterDataGridView.Columns[4].HeaderText = "Маслен филтър";
            OilAndFilterDataGridView.Columns[5].HeaderText = "Горивен филтър";
            OilAndFilterDataGridView.Columns[6].HeaderText = "Въздушен филтър";
            OilAndFilterDataGridView.Columns[7].HeaderText = "Филтър купе";
            OilAndFilterDataGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
