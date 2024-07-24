using System.Collections;

namespace d9.lcm;
public class Spreadsheet<TRow>(SpreadsheetColumnsDef columns, IEnumerable<TRow>? rows = null)
    : IEnumerable<TRow>
{
    private List<TRow> _rows = rows is not null ? rows.ToList() : new();
    public TRow this[int index] => _rows[index];
    public int RowCount => _rows.Count;
    public IEnumerator<TRow> GetEnumerator()
        => ((IEnumerable<TRow>)_rows).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable)_rows).GetEnumerator();
    public static Spreadsheet<T> LoadUsingDelimiter<T>(IEnumerable<string> lines, string delimiter)
        where T : IParsableWithDelimiter<T>
        => new(lines.Select(x => T.Parse(x, delimiter)));
    public static Spreadsheet<U> Transform<T, U>(Spreadsheet<T> input, Func<T, U> transform)
        => new(input.Select(x => transform(x)));
}
