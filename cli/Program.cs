using Modrinth;
using Modrinth.Models;
using d9.utl;
using File = System.IO.File;
using d9.lcm;
using System.Text.RegularExpressions;

internal class Program
{
    public static MinecraftVersions? MinecraftVersions { get; private set; }
    private static async Task Main(string[] args)
    {
        string basePath = @"C:\Users\dninemfive\Documents\workspaces\mods\_meta\d9.lcm";
        string[] rows = File.ReadAllLines($@"{basePath}\examplemods.txt");
        using FileStream fs = File.OpenWrite($@"{basePath}\output.txt");
        using StreamWriter sw = new(fs);
        ModrinthClientConfig mcc = new()
        {
            UserAgent = "dninemfive-lcm/0.0.0"
        };
        using ModrinthClient client = new(mcc);
        MinecraftVersions = await MinecraftVersions.DownloadUsing(client);
        foreach (string row in rows)
        {
            Match match = ModrinthUtils.ModrinthRegex.Match(row);
            if(match.Success && match.Groups.Values.Any() && match.Groups.Values.Skip(1).First().Value is string slug)
            {
                try
                {
                    Project project = await client.Project.GetAsync(slug);
                    string summary = $"{project.Title,-64}\t{project.GameVersions.Where(x => MinecraftVersions[x].Major).InColumnsOfWidth(10)}";
                    Print(summary);
                }
                catch (Exception e)
                {
                    Print($"{e.GetType().Name}: {e.Message}");
                }
            }
            else
            {
                Print(row);
            }
        }
    }
    private static void Print(object? obj, StreamWriter? sw = null)
    {
        Console.WriteLine($"{obj}");
        sw?.WriteLine($"{obj}");
    }
}