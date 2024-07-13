using Modrinth;
using Modrinth.Models;
using d9.utl;
using File = System.IO.File;

internal class Program
{
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

        foreach (string row in rows)
        {
            try
            {
                Project project = await client.Project.GetAsync(row.Split("/").Last());
                string summary = $"{project.Title}\t{project.GameVersions.ListNotation(brackets: null)}";
                Print(summary);
            }
            catch (Exception e)
            {
                Print($"{e.GetType().Name}: {e.Message}");
            }
        }
    }
    private static void Print(object? obj, StreamWriter? sw = null)
    {
        Console.WriteLine($"{obj}");
        sw?.WriteLine($"{obj}");
    }
}