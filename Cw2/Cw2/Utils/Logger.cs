using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cw2.Utils
{
    class Logger
    {
        public static void SaveErrorMessageToFile(Exception ex)
        {
            using StreamWriter writer = new StreamWriter(FileUtils.logFilePath, true);
            writer.WriteLine("\tMessage: " + ex.Message + " " + Environment.NewLine + "StackTrace :" + ex.StackTrace +
               "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
            writer.WriteLine(Environment.NewLine);
        }

    }
}
