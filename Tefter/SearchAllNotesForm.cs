namespace Tefter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Tefter.DbEntities;
    using Tefter.Helpers;

    public partial class SearchAllNotesForm : Form
    {
        private readonly ApplicationDbContext dbContext;
        private Logger logger;
        private List<Note> notes;

        public SearchAllNotesForm(ApplicationDbContext dbContext, Logger logger)
        {
            InitializeComponent();

            this.dbContext = dbContext;
            this.logger = logger;

            notes = dbContext.Notes.ToList();
        }

        private void SearchAllNotesForm_Load(object sender, EventArgs e)
        {
            try
            {
                SearchAllNotes_DataGridView.Columns["Id"].Visible = true;

                SearchAllNotes_DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                for (int i = 0; i < notes.Count(); i++)
                {
                    if (notes.Count() - 1 >= i)
                    {
                        SearchAllNotes_DataGridView.Rows.Add();
                    }

                    SearchAllNotes_DataGridView.Rows[i].Cells[0].Value = notes[i].Id;
                    SearchAllNotes_DataGridView.Rows[i].Cells[1].Value = notes[i].Description;
                }
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchAllNotesForm.SearchAllNotesForm_Load: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                var addNewNoteForm = new AddNewNoteForm(dbContext, logger, SearchAllNotes_DataGridView, notes);
                addNewNoteForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchAllNotesForm.AddButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                var sb = new StringBuilder();
                var emptyOrWrongFields = new List<string>();

                for (int i = 0; i < notes.Count(); i++)
                {
                    var carId = (string)SearchAllNotes_DataGridView.Rows[i].Cells[0].Value;
                    var description = (string)SearchAllNotes_DataGridView.Rows[i].Cells[1].Value;

                    if (string.IsNullOrWhiteSpace(carId))
                    {
                        emptyOrWrongFields.Add("Регистрационен номер");
                    }
                    if (string.IsNullOrWhiteSpace(description))
                    {
                        emptyOrWrongFields.Add("Бележки");
                    }

                    if (emptyOrWrongFields.Count() > 0)
                    {
                        sb.AppendLine("Моля попълнете следните полета: ");
                        sb.AppendLine(string.Join(", ", emptyOrWrongFields.Select(x => x)));

                        MessageBox.Show(sb.ToString());
                        return;
                    }

                    var plateNumberRegex = new Regex("^[А-а-Я-я]{2}[0-9]{4}[А-а-Я-я]{2}$");

                    if (!plateNumberRegex.IsMatch(carId))
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

                    notes[i].Description = description;
                }

                dbContext.SaveChanges();

                MessageBox.Show("Успешно направени промени.");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchAllNotesForm.SaveChangesButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void DeleteRecordButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = SearchAllNotes_DataGridView.SelectedRows;

                foreach (DataGridViewRow row in selectedRows)
                {
                    var id = (string)row.Cells["Id"].Value;
                    var itemForRemove = notes.FirstOrDefault(x => x.Id == id);

                    notes.Remove(itemForRemove);
                    dbContext.Notes.Remove(itemForRemove);

                    SearchAllNotes_DataGridView.Rows.Remove(row);
                }

                dbContext.SaveChanges();

                MessageBox.Show("Успешно изтрит запис.");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchAllNotesForm.DeleteRecordButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void Search_BackButton_Click(object sender, EventArgs e)
        {
            try
            {
                var homePageForm = new HomePageForm(dbContext);
                Close();
                homePageForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchAllNotesForm.Search_BackButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void SearchAllNotesForm_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    var columnName = SearchAllNotes_DataGridView.Columns[e.ColumnIndex].Name;

                    if (columnName == "Id")
                    {
                        var cell = SearchAllNotes_DataGridView[e.ColumnIndex, e.RowIndex];
                        SearchAllNotes_DataGridView.CurrentCell = cell;
                        SearchAllNotes_DataGridView.BeginEdit(true);
                    }
                    else if (columnName == "Description")
                    {
                        var readServiceMadeForm = new ReadNoteForm(SearchAllNotes_DataGridView, e.ColumnIndex, e.RowIndex, logger);
                        readServiceMadeForm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.WriteLine($"SearchServiceBookFormTwo.SearchServiceBookFormTwo_CellDoubleClick: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }
    }
}
