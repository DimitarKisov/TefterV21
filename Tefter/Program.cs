namespace Tefter
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Serilog;
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
            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   var appSettings = ConfigurationManager.AppSettings;
                   var path = appSettings["LoggerPath"];

                   //Add Serilog
                   var serilogLogger = new LoggerConfiguration()
                   .WriteTo.File(path)
                   .CreateLogger();
                   services.AddLogging(x =>
                   {
                       x.SetMinimumLevel(LogLevel.Information);
                       x.AddSerilog(logger: serilogLogger, dispose: true);
                   });

               });

            var host = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomePageForm());
        }
    }
}
