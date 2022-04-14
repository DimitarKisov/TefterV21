namespace Tefter
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Tefter.Helpers;

    static class Program
    {
        private static Logger logger;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .Build();

            var dbContext = new ApplicationDbContext(configuration);

            logger = new Logger();

            Application.Run(new HomePageForm(dbContext, logger));
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            MessageBox.Show("Възникна неочаквана грешка!");
            logger.WriteLine($"Global Exception Handler: {e.StackTrace}");
        }
    }
}
