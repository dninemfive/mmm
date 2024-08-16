using Modrinth;
using Modrinth.Models;

namespace d9.mmm;
public class ModAnalysisContext(ModrinthClient client, MinecraftVersions versions)
{
    public ModrinthClient ModrinthClient = client;
    public MinecraftVersions MinecraftVersions = versions;
    public static async Task<ModAnalysisContext> GenerateContext()
    {
        ModrinthClient client = ModrinthUtils.Client;
        MinecraftVersions versions = new(await client.Tag.GetGameVersionsAsync());
        return new(client, versions);
    }
    public AsyncCache<string, CachedProject> ProjectCache = new(s => client.Project.GetAsync(s));
    public async Task<CachedProject> FromSlug(string slug)
        => await ProjectCache.TryGet(slug);
}
