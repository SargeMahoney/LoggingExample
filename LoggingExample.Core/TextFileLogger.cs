namespace LoggingExample.Core
{
    public class TextFileLogger : ILoggerEngine
    {
        private readonly string LogFolderPath = AppDomain.CurrentDomain.BaseDirectory + @"Log\";

        public TextFileLogger()
        {
            Directory.CreateDirectory(LogFolderPath);
        }


        public async Task Write(string messageToLog, LogField logField)
        {
            try
            {
                if (string.IsNullOrEmpty(messageToLog))
                {
                    return;
                }

                var logPath = GetTextLogPathFromLogField(logField);
                using var w = File.AppendText(logPath);
                await WriteLog(messageToLog, w);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Il metodo statica che effettua la scrittura vera e propria sul file.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        private static async Task WriteLog(string log, TextWriter w)
        {
            await Task.Run(() =>
            {
                w.Write($"[{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}]");
                w.Write("\t");
                w.WriteLine($" {log}");
                w.WriteLine("-----------------------");
            });
        }


        private static string GetTextLogPathFromLogField(LogField logField)
        {
            return logField switch
            {
                LogField.NotDefined => AppDomain.CurrentDomain.BaseDirectory + @"Log\GeneralLog.txt",
                LogField.Database => AppDomain.CurrentDomain.BaseDirectory + @"Log\DatabaseLog.txt",
                LogField.UI => AppDomain.CurrentDomain.BaseDirectory + @"Log\UILog.txt",
                _ => AppDomain.CurrentDomain.BaseDirectory + @"Log\GeneralLog.txt",
            };
        }
    }
}
