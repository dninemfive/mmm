﻿namespace d9.lcm;
[ColumnOrder(nameof(ModName), nameof(ModUrl), nameof(Decision))]
public class ModInputRow
    : ISerializableUsingDelimiter<ModInputRow>
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
    public static ModInputRow FromLine(string line, string delimiter)
        => new(line, delimiter);
    public string ToLine(string delimiter)
        => new string[] { ModName, ModUrl, Decision.ToString() }.JoinWithDelimiter(delimiter);
}