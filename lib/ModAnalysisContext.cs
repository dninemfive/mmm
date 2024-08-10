using Modrinth;
using Modrinth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
public class AsyncCache<K, V>(Func<K, Task<V>> getter)
    where K : notnull
{
    private Dictionary<K, V> _cache = new();
    private Func<K, Task<V>> _getter = getter;
    public async Task<V> TryGet(K key)
    {
        if (_cache.TryGetValue(key, out V? value))
            return value;
        V? result = await _getter(key);
        if (result is not null)
            _cache[key] = result;
        return result;
    }
}
