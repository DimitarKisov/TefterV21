namespace Tefter
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Tefter.Helpers;

    public partial class ReadNoteForm : Form
    {
        private int columnIndex;
        private int rowIndex;

        private readonly Logger logger;

        public ReadNoteForm(DataGridView searchAllNotes_DataGridView, int columnIndex, int rowIndex, Logger logger)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(800, 100);

            this.columnIndex = columnIndex;
            this.rowIndex = rowIndex;
            this.logger = logger;

            this.SearchAllNotes_DataGridView = searchAllNotes_DataGridView;
        }

        public DataGridView SearchAllNotes_DataGridView { get; set; }

        private void ReadNoteForm_Load(object sender, EventArgs e)
        {
            var content = SearchAllNotes_DataGridView[columnIndex, rowIndex].Value.ToString();
            ReadDescription_TextBox.Text = content;
        }

        private void ReadNoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SearchAllNotes_DataGridView[columnIndex, rowIndex].Value = ReadDescription_TextBox.Text;
        }
    }
}
