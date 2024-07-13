using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace d9.lcm;
public interface IParsableWithDelimiter<TSelf>
{
    public static abstract TSelf Parse(string line, string delimiter);
}
public class ModDataRow
    : IParsableWithDelimiter<ModDataRow>
{
    public readonly string ModName, ModUrl;
    public readonly Decision Decision;
    public ModDataRow(string line, string delimiter)
    {
        string[] split = line.Split(delimiter);
        if (split.Length < 3)
            throw new ArgumentException($"Not enough values in line `{line}` when split by delimiter `{delimiter}`!", nameof(line));
        ModName = split[0];
        ModUrl = split[1];
        Decision = split[2].ParseDecision();
    }
    public static ModDataRow Parse(string line, string delimiter)
        => new(line, delimiter);
}
public class DelimitedSpreadsheet<TRow>(string[] lines, string delimiter)
    : IEnumerable<TRow>
    where TRow : IParsableWithDelimiter<TRow>
{
    private List<TRow> _rows = lines.Select(x => TRow.Parse(x, delimiter)).ToList();
    public TRow this[int index] => _rows[index];
    public int RowCount => _rows.Count;
    public IEnumerator<TRow> GetEnumerator()
        => ((IEnumerable<TRow>)_rows).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable)_rows).GetEnumerator();
}
