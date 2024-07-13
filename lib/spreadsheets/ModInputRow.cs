namespace d9.lcm;
public class ModInputRow
    : IParsableWithDelimiter<ModInputRow>
{
    public readonly string ModName, ModUrl;
    public readonly Decision Decision;
    public ModInputRow(string line, string delimiter)
    {
        string[] split = line.Split(delimiter);
        if (split.Length < 3)
            throw new ArgumentException($"Not enough values in line `{line}` when split by delimiter `{delimiter}`!", nameof(line));
        ModName = split[0];
        ModUrl = split[1];
        Decision = split[2].ParseDecision();
    }
    public static ModInputRow Parse(string line, string delimiter)
        => new(line, delimiter);
}