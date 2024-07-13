using Modrinth;
using Modrinth.Models;
using d9.utl;
using File = System.IO.File;
using d9.lcm;
using System.Text.RegularExpressions;
using Modrinth.Models.Tags;

internal class Program
{
    public static MinecraftVersions? MinecraftVersions { get; private set; }
    private static async Task Main(string[] args)
    {
        string basePath = @"C:\Users\dninemfive\Documents\workspaces\mods\_meta\d9.lcm";
        Spreadsheet<ModInputRow> data = File.ReadAllLines($@"{basePath}\moddata.tsv").ToSpreadsheetWithDelimiter<ModInputRow>("\t");
        using FileStream fs = File.OpenWrite($@"{basePath}\output.txt");
        using StreamWriter sw = new(fs);
        ModrinthClientConfig mcc = new()
        {
            UserAgent = "dninemfive-lcm/0.0.0"
        };
        using ModrinthClient client = new(mcc);
        MinecraftVersions = await MinecraftVersions.DownloadUsing(client);
        int updatedCount = 0;
        double totalCount = 0;
        foreach (ModInputRow row in data)
        {
            if (row.Decision < Decision.Considering)
                continue;
            totalCount++;
            Match match = ModrinthUtils.ModrinthRegex.Match(row.ModUrl);
            if(match.Success && match.Groups.Values.Any() && match.Groups
                                                                  .Values
                                                                  .Skip(1)
                                                                  .First()
                                                                  .Value is string slug)
            {
                try
                {
                    Project project = await client.Project.GetAsync(slug);
                    string lastVersion = project.GameVersions.OrderBy(x => MinecraftVersions[x].Date).Last();
                    bool upToDate = lastVersion == "1.21";
                    if (upToDate)
                        updatedCount++;
                    string summary = $"{project.Title,-64}\t{lastVersion,8}\t{(upToDate ? "TRUE" : "")}";
                    Print(summary);
                }
                catch (Exception e)
                {
                    Print($"{e.GetType().Name}: {e.Message}");
                }
            }
            else
            {
                Print($"{row.ModName,-64}\t{row.ModUrl}");
            }
        }
        Console.WriteLine($"\nUpdated percentage: {updatedCount / totalCount:P2}");
    }
    private static void Print(object? obj, StreamWriter? sw = null)
    {
        Console.WriteLine($"{obj}");
        sw?.WriteLine($"{obj}");
    }
}