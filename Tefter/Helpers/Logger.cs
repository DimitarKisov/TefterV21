namespace Tefter.Helpers
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;

    public class Logger
    {
        private object locker = new object();

        public Logger()
        {
        }

        public void WriteLine(string text)
        {
            try
            {
                var strPath = "C:\\Logs\\\\TefterV21ExceptionLog.txt";

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
            catch (Exception е)
            {

            }
        }
    }
}
