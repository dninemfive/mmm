using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d9.lcm;
public static class SpreadsheetExtensions
{
    public static Spreadsheet<T> ToSpreadsheetWithDelimiter<T>(this IEnumerable<string> lines, string delimiter)
        where T : IParsableWithDelimiter<T>
        => Spreadsheet<T>.LoadUsingDelimiter<T>(lines, delimiter);
}
