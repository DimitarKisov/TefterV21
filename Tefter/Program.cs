namespace Tefter
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;
    using System.Windows.Forms;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .Build();

            var dbContext = new ApplicationDbContext(configuration);

            Application.Run(new HomePageForm(dbContext));
        }
    }
}
