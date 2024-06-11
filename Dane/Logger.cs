using Dane;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Logger : LoggerBase
    {
        private string LogDirectory;

        private string FileName;

        private string FilePath;

        public Logger()
        {
            FileChecker.CheckDirectoryExists(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/" + "Logs");
            this.LogDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/" + "Logs";
            FileChecker.CheckFileExists(LogDirectory + "/" + "Log.json");
            this.FileName = "Log.json";
            this.FilePath = LogDirectory + "/" + FileName;
            this.ClearFile();
        }
        private void ClearFile()
        {
            try
            {
                System.IO.File.WriteAllText(this.FilePath, string.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void Log(string time, string message)
        {
            //Debug.WriteLine(this.FilePath);
            using (System.IO.StreamWriter w = System.IO.File.AppendText(this.FilePath))
            {
                w.WriteLine(time);
                w.WriteLine(message);
                w.WriteLine("-------------------------");
            }
        }

        
    }
}
