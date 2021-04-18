namespace Tefter
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Tefter.DbEntities;

    public partial class HomePageForm : Form
    {
        private ApplicationDbContext dbContex = new ApplicationDbContext();

        public HomePageForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(0, 0);

            var connString = GetConnectionString();
            var isDbCreated = CheckDatabaseExists(connString);

            if (!isDbCreated)
            {
                dbContex.Database.Migrate();
            }
        }
        
        private void CreateNewServiceBook_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            var createNewServiceBookFormOne = new CreateNewServiceBookFormOne();
            createNewServiceBookFormOne.Show();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }

        private static bool CheckDatabaseExists(string connectionString)
        {
            string query;
            bool result = false;

            try
            {
                var sqlConnection = new SqlConnection(connectionString);

                query = "SELECT database_id FROM sys.databases WHERE Name = 'TefterV21'";

                using (sqlConnection)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(query, sqlConnection))
                    {
                        sqlConnection.Open();

                        object resultObj = sqlCmd.ExecuteScalar();

                        int databaseID = 0;

                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }

                        sqlConnection.Close();

                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            var connectionString = configuration.GetSection("ConnectionString")["DefaultConnection"];

            return connectionString;
        }

        private void Search_TextBox_Leave(object sender, EventArgs e)
        {
            if (Search_TextBox.Text == "")
            {
                Search_TextBox.Text = "РЕГИСТРАЦИОНЕН НОМЕР";
            }
            Search_TextBox.Font = new Font("Times New Roman", 26);
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
    }
}
