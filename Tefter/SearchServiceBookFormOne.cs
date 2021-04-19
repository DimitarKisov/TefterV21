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

        }
    }
}
