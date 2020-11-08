namespace Cw2
{
    internal class CSVFormatter
    {
        private string pathIn;
        private string pathOut;
        private string format;

        public CSVFormatter(string pathIn, string pathOut, string format)
        {
            this.pathIn = pathIn;
            this.pathOut = pathOut;
            this.format = format;
        }
    }
}