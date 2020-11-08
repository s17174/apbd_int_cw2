using System;

namespace Cw2
{
    class Program
    {
        public static string pathIn = "dane.csv";
        public static string pathOut = "result.xml";
        public static string format = "xml";
        static void Main(string[] args)
        {
            try
            { 
                Utils.CheckAllData(args, pathIn);
                new CSVFormatter(pathIn, pathOut, format);
            }
            catch (Exception e)
            {
                Utils.SaveErrorMessageToFile(e);
            }
        }

      
    }
}
