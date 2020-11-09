using System;
using System.Collections.Generic;
using System.Text;

namespace Cw2.Utils
{
    class TableChecker<T>
    { 
        public static Boolean CheckLength(T[] tab, int length)
        {
            return tab.Length == length;
        }

        public static Boolean CheckColumn(T column)
        {
            return String.IsNullOrWhiteSpace(column.ToString()) || String.IsNullOrEmpty(column.ToString());
        }
    }
}
