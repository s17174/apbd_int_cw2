using Cw2.Utils;
using System;
using System.IO;

namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            FormatCVS(args);
        }

        static void FormatCVS(string[] args)
        {
            try
            {
                CreateLogFile();
                FileUtils.CheckAllData(args);
                CSVFormatter formater = new CSVFormatter();
                formater.FormatAndSerialize();
            }
            catch (Exception e)
            {
                Logger.SaveErrorMessageToFile(e);
            }
        }

        static void CreateLogFile()
        {
            FileInfo file = new FileInfo(FileUtils.logFilePath);

            if (!file.Exists)
            {
                file.Create();
            }
        }
    }
}
