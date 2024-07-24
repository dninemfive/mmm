using System.Reflection;

namespace d9.lcm.spreadsheets;
public abstract class AutoSerializedSpreadsheetRow<TSelf>
    : ISerializableUsingDelimiter<TSelf>
{
    public static string[] Columns
    {
        get
        {
            if (typeof(TSelf).GetCustomAttribute<ColumnOrderAttribute>()?.Columns is string[] columns)
                return columns;
            throw new Exception($"Attempted to auto-initialize an object of type {typeof(TSelf).Name}, but it doesn't have a ColumnOrder attribute!");
        }
    }
    public static TSelf FromLine(string line, string delimiter)
    {
        string[] columns = Columns, split = line.Split(delimiter);
        if (split.Length < columns.Length)
            throw new Exception($"Cannot make a {typeof(TSelf).Name} from line `{line}`: not enough columns!");
        TSelf result = Activator.CreateInstance<TSelf>();
        foreach (string column in columns)
        {
            if(typeof(TSelf).GetField(column) is FieldInfo fi)
            {
                Type targetType = fi.FieldType;
                fi.SetValue(result, )
            }
        }
    }
    public string ToLine(string delimiter)
    {
        throw new NotImplementedException();
    }
}
