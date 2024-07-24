namespace d9.lcm;
public class ModInputRow
    : IParsableWithDelimiter<ModInputRow>
{
    public readonly string ModName, ModUrl;
    public readonly Decision Decision;
    public ModInputRow(string line, string delimiter)
    {
        string[] split = line.SplitTo(delimiter, 3);
        ModName = split[0];
        ModUrl = split[1];
        Decision = split[2].ParseDecision();
    }
    public static ModInputRow Parse(string line, string delimiter)
        => new(line, delimiter);
    public string ToLine(string delimiter)
        => new string[] { ModName, ModUrl, Decision.ToString() }.JoinWithDelimiter(delimiter);
}