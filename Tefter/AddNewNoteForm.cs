namespace Tefter
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Tefter.DbEntities;
    using Tefter.Helpers;

    public partial class AddNewNoteForm : Form
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Logger logger;

        public AddNewNoteForm(ApplicationDbContext dbContext, Logger logger, DataGridView searchAllNotes_DataGridView, List<Note> notes)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(800, 100);

            this.dbContext = dbContext;
            this.logger = logger;

            this.SearchAllNotes_DataGridView = searchAllNotes_DataGridView;
            this.Notes = notes;
        }

        public DataGridView SearchAllNotes_DataGridView { get; set; }

        public List<Note> Notes { get; set; }

        private void AddNote_Button_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            var emptyOrWrongFields = new List<string>();

            if (string.IsNullOrWhiteSpace(PlateNumber_TextBox.Text.Trim()) || PlateNumber_TextBox.Text.Trim() == "РЕГИСТРАЦИОНЕН НОМЕР")
            {
                emptyOrWrongFields.Add("Регистрационен номер");
            }
            if (string.IsNullOrWhiteSpace(Description_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Описание");
            }

            if (emptyOrWrongFields.Count() > 0)
            {
                sb.AppendLine("Моля попълнете следните полета: ");
                sb.AppendLine(string.Join(", ", emptyOrWrongFields.Select(x => x)));

                MessageBox.Show(sb.ToString());
                return;
            }

            var plateNumberRegex = new Regex("^[А-а-Я-я]{2}[0-9]{4}[А-а-Я-я]{2}$");

            if (!plateNumberRegex.IsMatch(PlateNumber_TextBox.Text.Trim()))
            {
                emptyOrWrongFields.Add("Регистрационен номер");
            }

            if (emptyOrWrongFields.Count() > 0)
            {
                sb.AppendLine("Моля въведете коректни данни за следните полета: ");
                sb.AppendLine(string.Join(", ", emptyOrWrongFields.Select(x => x)));

                MessageBox.Show(sb.ToString());
                return;
            }

            var carId = PlateNumber_TextBox.Text.Trim();
            var description = Description_TextBox.Text.Trim();

            var note = new Note(carId, description);

            try
            {
                this.dbContext.Notes.Add(note);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"AddNewNoteForm.AddNote_Button_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }

            this.Notes.Add(note);
            this.SearchAllNotes_DataGridView.Rows.Add();

            var rowsCountWithNewRow = this.SearchAllNotes_DataGridView.Rows.Count - 1;

            this.SearchAllNotes_DataGridView.Rows[rowsCountWithNewRow].Cells[0].Value = carId;
            this.SearchAllNotes_DataGridView.Rows[rowsCountWithNewRow].Cells[1].Value = description;

            this.Close();
        }

        private void PlateNumber_TextBox_Leave(object sender, EventArgs e)
        {
            if (PlateNumber_TextBox.Text == "")
            {
                PlateNumber_TextBox.Text = "РЕГИСТРАЦИОНЕН НОМЕР";
            }

            PlateNumber_TextBox.Font = new Font("Times New Roman", 22);
            PlateNumber_TextBox.ForeColor = Color.DarkGray;
        }

        private void PlateNumber_TextBox_Enter(object sender, EventArgs e)
        {
            if (PlateNumber_TextBox.Text == "РЕГИСТРАЦИОНЕН НОМЕР")
            {
                PlateNumber_TextBox.Text = null;
            }

            PlateNumber_TextBox.Font = new Font("Times New Roman", 22);
            PlateNumber_TextBox.ForeColor = Color.Black;
        }
    }
}
