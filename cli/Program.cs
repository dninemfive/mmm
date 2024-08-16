using Modrinth;
using Modrinth.Models;
using d9.utl;
using File = System.IO.File;
using d9.mmm;
using System.Text.RegularExpressions;
using Modrinth.Models.Tags;

internal class Program
{
    public static MinecraftVersions? MinecraftVersions { get; private set; }
    private static async Task Main(string[] args)
    {
        string basePath = @"C:\Users\dninemfive\Documents\workspaces\mods\_meta\d9.lcm";
        Spreadsheet<ModInputRow> data = File.ReadAllLines($@"{basePath}\moddata.tsv").LoadSpreadsheetWithDelimiter<ModInputRow>("\t");
        string outputPath = $@"{basePath}\output.tsv";
        File.WriteAllText(outputPath, "");
        using FileStream fs = File.OpenWrite(outputPath);
        using StreamWriter sw = new(fs);
        ModrinthClientConfig mcc = new()
        {
            UserAgent = "dninemfive-lcm/0.0.0"
        };
        using ModrinthClient client = new(mcc);
        MinecraftVersions = await MinecraftVersions.DownloadUsing(client);
        Func<ModInputRow, Task<ModOutputRow>> tf = ModOutputRow.TransformFunction(client, MinecraftVersions);
        List<ModOutputRow> modData = [];
        foreach (ModInputRow row in data)
        {
            if (row.Decision < Decision.Active)
                continue;
            ModOutputRow mor = await tf(row);
            modData.Add(mor);
            Print(mor.ToLine("\t"), sw);
        }
        Console.WriteLine($"\nUpdated percentage: {modData.Select(x => x.MostRecentVersion).EvaluateTernary(x => x == MinecraftVersions["1.21"]).ProportionTrue()}");
    }
    private static void Print(object? obj, StreamWriter? sw = null)
    {
        Console.WriteLine($"{obj}");
        sw?.WriteLine($"{obj}");
    }
}