using System;
using System.IO;

namespace Cw2
{
    class FileUtils
    {
        public static readonly string logFilePath = @"C:\Users\Łukasz\Desktop\PJATK\VII\APBD\apbd_int_cw2\Cw2\Cw2\Data\logs.txt";
        public static string pathToFiles = @"C:\Users\Łukasz\Desktop\PJATK\VII\APBD\apbd_int_cw2\Cw2\Cw2\Data\";
        public static string pathIn = pathToFiles + "dane.csv";
        public static string format = "xml";
        public static string pathOut = pathToFiles + "result." + format;

        public static void CheckAllData(string[] args)
        {
            CheckArguments(args);
            CheckPath();
            CheckIfFileExists();
        }

        private static void CheckPath()
        {
            if (!Path.IsPathRooted(pathIn))
            {
                throw new ArgumentException("Podana ścieżka jest niepoprawna");
            }
        }

        private static void CheckIfFileExists()
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
                    pathIn= args[0];
                    break;
                case 2:
                    pathIn = args[0];
                    pathOut = args[1];
                    break;
                case 3:
                    pathIn = args[0];
                    pathOut = args[1];
                    format = args[2];
                    break;
            }
        }
    }
}
