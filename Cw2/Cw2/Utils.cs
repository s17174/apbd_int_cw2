using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Cw2
{
    class Utils
    { 
        public static void SaveErrorMessageToFile(Exception ex)
        { 
            string filePath = @"C:\Users\Łukasz\Desktop\PJATK\VII\APBD\apbd_int_cw2\Cw2\Cw2\logs.txt";

            FileInfo file = new FileInfo(filePath);

            if (!file.Exists)
            {
                file.Create();
            }
            else
            {
                using StreamWriter writer = new StreamWriter(filePath, true);
                writer.WriteLine("\tMessage: " + ex.Message + " " + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine);
            }
        }

        public static void CheckAllData(string[] args, string pathIn)
        {
            CheckArguments(args);
            CheckPath(pathIn);
            CheckIfFileExists(pathIn);
        }

        private static void CheckPath(string pathIn)
        {
            if (!Path.IsPathRooted(pathIn))
            {
                throw new ArgumentException("Podana ścieżka jest niepoprawna");
            }

        }

        private static void CheckIfFileExists(string pathIn)
        {
            FileInfo file = new FileInfo(pathIn);

            if (!file.Exists)
            {
                throw new FileNotFoundException("Plik " + pathIn + " nie istnieje");
            }
        }

        private static void CheckArguments(string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    Program.pathIn= args[0];
                    break;
                case 2:
                    Program.pathIn = args[0];
                    Program.pathOut = args[1];
                    break;
                case 3:
                    Program.pathIn = args[0];
                    Program.pathOut = args[1];
                    Program.format = args[2];
                    break;
            }
        }
    }
}
