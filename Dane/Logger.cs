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

        private string BufFile;

        private string BufFilePath;

        public Logger()
        {
            string tempDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Logs";
            tempDirectory = tempDirectory.Replace("Prezentacja", "Dane");

            FileChecker.CheckDirectoryExists(tempDirectory);
            this.LogDirectory = tempDirectory;
            
            FileChecker.CheckFileExists(LogDirectory + "/" + "Log.json");
            
            this.FileName = "Log.json";
            this.FilePath = LogDirectory + "/" + FileName;
            this.ClearFile(FilePath);

            FileChecker.CheckFileExists(this.LogDirectory + "/" + "bufor.txt");
            this.BufFile = "bufor.txt";
            this.BufFilePath = LogDirectory + "/" + BufFile;
            this.ClearFile(BufFilePath);
        }

        public string GetFilePath()
        {
            return this.FilePath;
        }
        private void ClearFile(string path)
        {
            try
            {
                System.IO.File.WriteAllText(path, string.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void Log(string time, string message)
        {
            var info = new FileInfo(this.BufFilePath);

            using (System.IO.StreamWriter w = System.IO.File.AppendText(this.BufFilePath))
            {
                if (info.Length == 0)
                {
                    w.WriteLine("[");
                    w.WriteLine("{\"Time\": \"" + time + "\"},");
                    w.WriteLine(message);
                    w.WriteLine("]");
                }
                else
                {
                    w.WriteLine("{\"Time\": \"" + time + "\"},");
                    w.WriteLine(message);
                    w.WriteLine("]");
                }
                w.Close();
            }
            this.FormatJsonFile();
        }

        public void FormatJsonFile()
        {
            StringBuilder fileContent = new StringBuilder();
            foreach (string line in File.ReadLines(this.BufFilePath))
            {
                fileContent.AppendLine(line);
            }
            for (int i = 0; i < fileContent.Length; i++)
            {
                if (fileContent[i] == ']')
                {
                    fileContent.Remove(i, 1);
                }
            }

            for (int i =  fileContent.Length - 1; i >= 0; i--)
            {
                if (fileContent[i] == ',')
                {
                    fileContent.Remove(i, 1); break;
                }
            }

            fileContent.Append(']');
            try
            {
                System.IO.File.WriteAllText(this.FilePath, fileContent.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
