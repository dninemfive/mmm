using d9.utl;
using Modrinth;
using Modrinth.Models;
using Modrinth.Models.Tags;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using File = System.IO.File;

namespace d9.mmm;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private async void LoadMods_Click(object sender, RoutedEventArgs _)
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
        List<Project> projects = new();
        ModList.ItemsSource = projects;
        foreach (string row in rows)
        {
            try
            {
                Project project = await client.Project.GetAsync(row.Split("/").Last());
                string summary = $"{project.Title}\t{project.GameVersions.ListNotation()}";
                sw.WriteLine(summary);
                Print(summary);
                projects.Add(project);
            }
            catch (Exception e)
            {
                sw.WriteLine(e);
                Print(e);
            }
        }
    }
    public void Print(object? obj)
    {
        Run run = new($"{obj}");
        Paragraph result = new();
        result.Inlines.Add(run);
        // Document.Blocks.Add(result);
    }
}