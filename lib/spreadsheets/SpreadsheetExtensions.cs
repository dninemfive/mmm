using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using d9.utl;

namespace d9.lcm;
public static class SpreadsheetExtensions
{
    public static Spreadsheet<T> ToSpreadsheetWithDelimiter<T>(this IEnumerable<string> lines, string delimiter)
        where T : IParsableWithDelimiter<T>
        => Spreadsheet<T>.LoadUsingDelimiter<T>(lines, delimiter);
    public static string ToSpreadsheetRow(this object obj, string delimiter)
    {
        IEnumerable<(MemberInfo member, ColumnAttribute attr)> columns = obj.GetType().MembersWithAttribute<ColumnAttribute>();
        if (columns.Select(x => x.attr.Index).Distinct().Count() < columns.Count())
            throw new Exception("Duplicate column numbers on type {obj.GetType().Name}: {stuff idk}");
        foreach(MemberInfo member in columns.OrderBy(x => x.attr.Index).Select(x => x.member))
        {
            if(member is FieldInfo field && field.GetValue(obj) is object fval)
            {
                
            }
            else if(member is PropertyInfo property && property.GetValue(obj, null) is object pval)
            {
                // write value
            } else
            {
                // throw exception: invalid target
            }
        }
        return ""; // joined values of above
    }
}
