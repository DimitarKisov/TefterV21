namespace Tefter
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            //var configuration = new ConfigurationBuilder()
            //                    .SetBasePath(Directory.GetCurrentDirectory())
            //                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //                    .Build();

            //var dbContext = new ApplicationDbContext(configuration);

            //logger = new Logger();

            //Application.Run(new HomePageForm(dbContext, logger));

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .Build();

            Application.Run(ServiceProvider.GetRequiredService<HomePageForm>());
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            MessageBox.Show("Възникна неочаквана грешка!");
            logger.WriteLine($"Global Exception Handler: {e.StackTrace}");
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddDbContext<ApplicationDbContext>();
                    services.AddTransient<Logger>();
                    services.AddTransient<HomePageForm>();
                    services.AddTransient<CreateNewServiceBookFormOne>();
                    services.AddTransient<CreateNewServiceBookFormTwo>();
                    services.AddTransient<CreateNewServiceBookFormThree>();
                    services.AddTransient<SearchAllNotesForm>();
                });
        }

    }
}
