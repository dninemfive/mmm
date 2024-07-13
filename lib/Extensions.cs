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
}
