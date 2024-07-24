using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using d9.utl;

namespace d9.lcm;
public static class SpreadsheetExtensions
{
    public static Spreadsheet<T> LoadSpreadsheetWithDelimiter<T>(this IEnumerable<string> lines, string delimiter)
        where T : IParsableWithDelimiter<T>
        => Spreadsheet<T>.LoadUsingDelimiter<T>(lines, delimiter);
    public static string[] SplitTo(this string line, string delimiter, int expectedCount, bool throwOnTooMany = false)
    {
        string[] split = line.Split(delimiter);
        ArgumentException exception(int actualCount)
            => new($"Expected {expectedCount} values in line `{line}` when split by delimiter `{delimiter}`, but got {actualCount}!", nameof(line));
        if (split.Length < expectedCount || (throwOnTooMany && split.Length > expectedCount))
            throw exception(split.Length);
        return split;
    }
    public static Spreadsheet<U> Transform<T, U>(this Spreadsheet<T> input, Func<T, U> transform)
        => new(input.Select(x => transform(x)));
    public static IEnumerable<string> ToLines<T>(this Spreadsheet<T> spreadsheet, string delimiter)
        where T : IWritableWithDelimiter
        => spreadsheet.Select(x => x.ToLine(delimiter));
}
