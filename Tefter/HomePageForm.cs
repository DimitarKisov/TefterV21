namespace Tefter
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Tefter.DbEntities;
    using Tefter.Helpers;

    public partial class HomePageForm : Form
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Logger logger;

        public HomePageForm(ApplicationDbContext dbContext, Logger logger)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            this.dbContext = dbContext;
            this.logger = logger;

            try
            {
                this.dbContext.Database.Migrate();
                //dbContext.Database.ExecuteSqlRaw("ALTER DATABASE TefterV21 COLLATE Cyrillic_General_CI_AS");
            }
            catch (Exception ex)
            {
                this.logger.WriteLine($"HomePageForm.Constructor: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Search_TextBox.Text) || Search_TextBox.Text == "РЕГИСТРАЦИОНЕН НОМЕР")
            {
                MessageBox.Show("Моля, въведете регистрационен номер.");
                return;
            }

            var carId = Search_TextBox.Text.Trim();

            var carIdRegex = new Regex("^[А-а-Я-я]{2}[0-9]{4}[А-а-Я-я]{2}$");
            if (!carIdRegex.IsMatch(carId))
            {
                MessageBox.Show("Моля, въведете валиден регистрационен номер.");
                return;
            }

            Car car = null;

            try
            {
                car = this.dbContext.Cars.Find(carId);

                if (car == null)
                {
                    MessageBox.Show("Не съществува кола с такъв номер!");
                    return;
                }
            }
            catch (Exception ex)
            {
                this.logger.WriteLine($"HomePageForm.SearchButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }

            var formTwo = Program.ServiceProvider.GetRequiredService<CreateNewServiceBookFormTwo>();
            formTwo.Car = car;

            this.Hide();
            formTwo.Show();

            //var searchForm = new SearchServiceBookFormOne(car, dbContext, logger);
            //this.Hide();
            //searchForm.Show();
        }

        private void CreateNewServiceBook_Button_Click(object sender, EventArgs e)
        {
            var createNewServiceBookFormOne = Program.ServiceProvider.GetRequiredService<CreateNewServiceBookFormOne>();
            //this.Hide();
            createNewServiceBookFormOne.ShowDialog();

            //var createNewServiceBookFormOne = new CreateNewServiceBookFormOne(dbContext, logger);
            //this.Hide();
            //createNewServiceBookFormOne.Show();
        }

        private void SearchAllNotesForm_Click(object sender, EventArgs e)
        {
            //var searchAllNotesForm = new SearchAllNotesForm(dbContext, logger);

            var searchAllNotesForm = Program.ServiceProvider.GetRequiredService<SearchAllNotesForm>();
            //this.Hide();
            searchAllNotesForm.ShowDialog();
        }

        private void Search_TextBox_Leave(object sender, EventArgs e)
        {
            if (Search_TextBox.Text == "")
            {
                Search_TextBox.Text = "РЕГИСТРАЦИОНЕН НОМЕР";
            }
            Search_TextBox.Font = new Font("Times New Roman", 48);
            Search_TextBox.ForeColor = Color.DarkGray;
        }

        private void Search_TextBox_Enter(object sender, EventArgs e)
        {
            if (Search_TextBox.Text == "РЕГИСТРАЦИОНЕН НОМЕР")
            {
                Search_TextBox.Text = null;
            }
            Search_TextBox.Font = new Font("Times New Roman", 48);
            Search_TextBox.ForeColor = Color.Black;
        }

        private void Search_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    SearchButton_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                logger.WriteLine($"HomePageForm.Search_TextBox_KeyPress: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }
    }
}
