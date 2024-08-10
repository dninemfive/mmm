using Modrinth;
using Modrinth.Models;

namespace d9.lcm;
public class ModAnalysisContext(ModrinthClient client, MinecraftVersions versions)
{
    public ModrinthClient Client = client;
    public MinecraftVersions MinecraftVersions = versions;
    public static async Task<ModAnalysisContext> GenerateContext()
    {
        ModrinthClient client = ModrinthUtils.Client;
        MinecraftVersions versions = new(await client.Tag.GetGameVersionsAsync());
        return new(client, versions);
    }
    public AsyncCache<string, Project> ProjectCache = new(s => client.Project.GetAsync(s));
    
}
