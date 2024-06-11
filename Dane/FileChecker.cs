using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class FileChecker
    {
        public static void CheckFileExists(string FilePath)
        {
            if (!File.Exists(FilePath))
            {
                var myFile = File.Create(FilePath);
                myFile.Close();
            }
        }

        public static void CheckDirectoryExists(string DirectoryPath)
        {
            if (!Directory.Exists(DirectoryPath)) 
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }
    }
}
