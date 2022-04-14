namespace Tefter
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Tefter.Helpers;

    public partial class HomePageForm : Form
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Logger logger;

        public HomePageForm(ApplicationDbContext dbContext)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.dbContext = dbContext;

            try
            {
                //var connString = GetConnectionString();
                //var isDbCreated = CheckDatabaseExists(connString);

                //if (!isDbCreated)
                //{
                //    dbContext.Database.Migrate();
                //    //dbContext.Database.ExecuteSqlRaw("ALTER DATABASE TefterV21 COLLATE Cyrillic_General_CI_AS");
                //}

                //dbContext = new ApplicationDbContext();
                dbContext.Database.Migrate();

                //var isDbCreated = DbAccess.ExecuteQuery(new SqlCommand { CommandText = "SELECT database_id FROM sys.databases WHERE Name = 'TefterV21'" }, connString);

                //if (isDbCreated > 0)
                //{
                //    dbContext.Database.Migrate();
                //    dbContext.Database.ExecuteSqlRaw("ALTER DATABASE TefterV21 COLLATE Cyrillic_General_CI_AS");
                //}

                logger = new Logger();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"HomePageForm.Constructor: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
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

                var car = dbContext.Cars.Find(carId);

                if (car == null)
                {
                    MessageBox.Show("Не съществува кола с такъв номер!");
                    return;
                }

                var searchForm = new SearchServiceBookFormOne(car, dbContext, logger);
                Hide();
                searchForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"HomePageForm.SearchButton_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void CreateNewServiceBook_Button_Click(object sender, EventArgs e)
        {
            try
            {
                var createNewServiceBookFormOne = new CreateNewServiceBookFormOne(dbContext, logger);
                Hide();
                createNewServiceBookFormOne.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"HomePageForm.CreateNewServiceBook_Button_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void SearchAllNotesForm_Click(object sender, EventArgs e)
        {
            try
            {
                var searchAllNotesForm = new SearchAllNotesForm(dbContext, logger);
                Hide();
                searchAllNotesForm.Show();
            }
            catch (Exception ex)
            {
                logger.WriteLine($"HomePageForm.SearchAllNotesForm_Click: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void Search_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Search_TextBox.Text == "")
                {
                    Search_TextBox.Text = "РЕГИСТРАЦИОНЕН НОМЕР";
                }
                Search_TextBox.Font = new Font("Times New Roman", 48);
                Search_TextBox.ForeColor = Color.DarkGray;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"HomePageForm.Search_TextBox_Leave: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
        }

        private void Search_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                if (Search_TextBox.Text == "РЕГИСТРАЦИОНЕН НОМЕР")
                {
                    Search_TextBox.Text = null;
                }
                Search_TextBox.Font = new Font("Times New Roman", 48);
                Search_TextBox.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"HomePageForm.Search_TextBox_Enter: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
            }
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

        //private bool CheckDatabaseExists(string connectionString)
        //{
        //    string query;
        //    bool result = false;

        //    try
        //    {
        //        var sqlConnection = new SqlConnection(connectionString);

        //        query = "SELECT database_id FROM sys.databases WHERE Name = 'TefterV21'";

        //        using (sqlConnection)
        //        {
        //            using (SqlCommand sqlCmd = new SqlCommand(query, sqlConnection))
        //            {
        //                sqlConnection.Open();

        //                object resultObj = sqlCmd.ExecuteScalar();

        //                int databaseID = 0;

        //                if (resultObj != null)
        //                {
        //                    int.TryParse(resultObj.ToString(), out databaseID);
        //                }

        //                sqlConnection.Close();

        //                result = databaseID > 0;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.WriteLine($"HomePageForm.CheckDatabaseExists: {ex}");
        //        MessageBox.Show("Възникна неочаквана грешка!");
        //    }

        //    return result;
        //}

        private string GetConnectionString()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                var configuration = builder.Build();
                var connectionString = configuration.GetSection("ConnectionString")["DefaultConnection"];

                return connectionString;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"HomePageForm.GetConnectionString: {ex}");
                MessageBox.Show("Възникна неочаквана грешка!");
                return null;
            }
        }
    }
}
