namespace Tefter
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Configuration;
    using System.Windows.Forms;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ///Generate Host Builder and Register the Services for DI
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomePageForm());

            //var builder = new HostBuilder()
            //   .ConfigureServices((hostContext, services) =>
            //   {
            //       services.AddSingleton<HomePageForm>();
            //       services.AddScoped<CreateNewServiceBookFormOne>();

            //       var appSettings = ConfigurationManager.AppSettings;
            //       var path = appSettings["LoggerPath"];

            //       //Add Serilog
            //       var serilogLogger = new LoggerConfiguration()
            //       .WriteTo.File(path)
            //       .CreateLogger();
            //       services.AddLogging(x =>
            //       {
            //           x.SetMinimumLevel(LogLevel.Information);
            //           x.AddSerilog(logger: serilogLogger, dispose: true);
            //       });

            //   });

            //var host = builder.Build();

            //using (var serviceScope = host.Services.CreateScope())
            //{
            //    var services = serviceScope.ServiceProvider;
            //    try
            //    {
            //        var homePageForm = services.GetRequiredService<HomePageForm>();
            //        Application.Run(homePageForm);

            //        Console.WriteLine("Success");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("Error Occured");
            //    }
            //}
        }
    }
}
