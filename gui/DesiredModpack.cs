using Modrinth.Models;
using Modrinth.Models.Enums.Version;
using ModVersion = Modrinth.Models.Version;

namespace d9.lcm.gui;
public class DesiredModpack(string name, Dictionary<string, int> modValues)
{
    public string Name { get; private set; } = name;
    public IReadOnlyList<(string id, int value)> LoadOrder { get; private set; } = modValues.Select(x => (x.Key, x.Value))
                                                                                            .OrderBy(x => x.Value)
                                                                                            .ThenBy(x => x.Key)
                                                                                            .ToList();
    public IEnumerable<ModpackVersion> OptionsFor(string mcVersion, Dictionary<string, string>? requiredModVerisons = null, Dictionary<ModId, int>? priorities = null)
    {
        throw new NotImplementedException();
    }
}
public record ModpackVersion(string Name, string MinecraftVersion)
{
    private readonly List<ModVersion> _mods = [];
    public IReadOnlyList<ModVersion> Mods => _mods;
    public bool IsValid
    {
        get
        {
            foreach((ModVersion a, ModVersion b) in Mods.Zip(Mods))
            {
                if (a == b)
                    continue;
                if (!(a.IsCompatibleWith(b) && b.IsCompatibleWith(a)))
                    return false;
            }
            return true;
        }
    }
    public async Task<ModpackVersion?> TryAdd(Dependency dependency)
        => await TryAdd(await dependency.ToModVersion());
    public async Task<ModpackVersion?> TryAdd(ModVersion? version)
    {
        if (version is null || Mods.Contains(version))
            return null;
        ModpackVersion? newModpack = new(this);
        newModpack._mods.Add(version);
        foreach(Dependency dependency in version.Dependencies ?? [])
        {
            if(dependency.DependencyType is DependencyType.Required or DependencyType.Embedded)
            {
                newModpack = await TryAdd(dependency);
                if (newModpack is null)
                    return null;
            }
            if(dependency.DependencyType is DependencyType.Optional)
            {
                ModpackVersion? possibleNewVersion = await TryAdd(dependency);
                if (possibleNewVersion is ModpackVersion mpv)
                    newModpack = mpv;
            }
        }
        if (newModpack.IsValid)
            return newModpack;
        return null;
    }
}
