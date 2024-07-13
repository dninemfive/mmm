using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace d9.lcm;
public interface IReadOnlySpreadsheet<TRow>
    : IEnumerable<TRow>
    where TRow : IReadOnlySpreadsheetRow<TRow>
{
    public TRow this[int index] { get; }
    public object? this[int row, string column] => this[row][column];
}
public interface IReadOnlySpreadsheetRow<TSelf>
{
    public object? this[string column] { get; }
}
public abstract class AutoRow : IReadOnlySpreadsheetRow<AutoRow>
{
    private readonly Dictionary<string, FieldInfo> _columns = new();
    public object? this[string column]
    {
        get
        {
            if(_columns.TryGetValue(column, out FieldInfo? field))
            {
                return field.GetValue(this);
            }
            field = GetType().GetField(column);
            if(field is not null)
            {
                _columns[column] = field;
                return field.GetValue(this);
            }
            return null;
        }
    }
}
public class DelimitedSpreadsheet<TRow>
    : IReadOnlySpreadsheet<TRow>
    where TRow : IReadOnlySpreadsheetRow<TRow>
{
    public TRow this[int index] => throw new NotImplementedException();
    public IEnumerator<TRow> GetEnumerator()
    {
        throw new NotImplementedException();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
