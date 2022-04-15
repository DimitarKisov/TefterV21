namespace Tefter
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Tefter.Helpers;

    public partial class ReadServicesMadeForm : Form
    {
        private int columnIndex;
        private int rowIndex;

        private readonly Logger logger;

        public ReadServicesMadeForm(DataGridView otherServiceDataGridView, int columnIndex, int rowIndex, Logger logger)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(800, 100);

            this.columnIndex = columnIndex;
            this.rowIndex = rowIndex;
            this.logger = logger;

            this.OtherServiceDataGridView = otherServiceDataGridView;
        }

        public DataGridView OtherServiceDataGridView { get; set; }

        private void ReadServicesMadeForm_Load(object sender, EventArgs e)
        {
            var content = OtherServiceDataGridView[columnIndex, rowIndex].Value.ToString();
            LoadContext_TextBox.Text = content;
        }

        private void ReadServicesMadeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OtherServiceDataGridView[columnIndex, rowIndex].Value = LoadContext_TextBox.Text;
        }
    }
}
