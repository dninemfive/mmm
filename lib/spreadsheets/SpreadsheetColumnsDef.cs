using System.Collections;
using ColumnDef = (int Index, string Name);
namespace d9.lcm;
public readonly struct SpreadsheetColumnsDef(string[] columnNames)
    : IEnumerable<ColumnDef>
{
    private readonly ColumnDef[] _columns = columnNames.WithIndices().ToArray();
    public string this[int index] => _columns[index].Name;
    public IEnumerator<(int Index, string Name)> GetEnumerator()
        => (IEnumerator<ColumnDef>)_columns.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => _columns.GetEnumerator();
}
