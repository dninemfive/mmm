using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using d9.utl;

namespace d9.lcm;
public static class Extensions
{
    // todo: move to utl
    public static string InColumnsOfWidth<T>(this IEnumerable<T> items, int width)
        => items.InColumns(Enumerable.Repeat(width, items.Count()));
    public static Decision ParseDecision(this string s)
        => Enum.Parse<Decision>(s.Replace(" ", ""));
    // todo: move to utl
    public static string JoinWithDelimiter(this IEnumerable<string> strings, string delimiter)
        => strings.Aggregate((x, y) => $"{x}{delimiter}{y}");
    // todo: move to utl
    public static IEnumerable<(int i, T value)> WithIndices<T>(this IEnumerable<T> enumerable)
    {
        int i = 0;
        foreach (T item in enumerable)
            yield return (i++, item);
    }
    public static ProportionRange ProportionTrue(this IEnumerable<bool?> truthValues)
    {
        double total = truthValues.Count(),
               @true = truthValues.Count(x => x is true),
               @null = truthValues.Count(x => x is null);
        return (@true / total, (@true + @null) / total);
    }
    public static IEnumerable<bool?> EvaluateTernary<T>(this IEnumerable<T?> values, Func<T, bool> predicate)
    {
        foreach(T? value in values)
        {
            if(value is not null)
            {
                yield return predicate(value);
            } 
            else
            {
                yield return null;
            }
        }
    }
}
