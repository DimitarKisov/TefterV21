namespace Tefter.Helpers
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;

    public class Logger
    {
        public bool fileLoggingEnabled;
        public string fileLogPath;
        private object locker = new object();

        public Logger(IConfiguration iconfiguration)
        {
            try
            {
                var logCOnfig = iconfiguration.GetSection("Log");
                fileLoggingEnabled = bool.Parse(logCOnfig["FileLoggingEnabled"]);
                fileLogPath = logCOnfig["FileLogPath"];
            }
            catch (Exception)
            {

            }
            
        }

        public void WriteLine(string text)
        {
            try
            {
                if (fileLoggingEnabled)
                {
                    var strPath = fileLogPath + "TefterV21-ExceptionLog.txt";

                    if (!File.Exists(strPath))
                    {
                        File.Create(strPath).Dispose();
                    }
                    else
                    {
                        var file = new FileInfo(strPath);

                        var docMb = (file.Length / 1024f) / 1024f;
                        if (docMb > 2)
                        {
                            File.Move(strPath, file.DirectoryName + file.Name + DateTime.Now.ToString("yyyyMMddHHmm") + file.Extension);
                            File.Create(strPath).Dispose();
                        }

                    }
                    lock (locker)
                    {
                        using (StreamWriter sw = File.AppendText(strPath))
                        {
                            sw.WriteLine(DateTime.Now + " - " + text);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
