using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d9.lcm.gui;
public class DesiredModpack(string name, List<ModId> loadOrder)
{
    public string Name { get; private set; } = name;
    public IReadOnlyList<ModId> LoadOrder { get; private set; } = loadOrder;
    public static async Task<DesiredModpack> Create(string name, string minecraftVersion, List<(string id, int value)> desiredMods)
    {
        
    }
    public IEnumerable<ModpackVersion> OptionsFor(string mcVersion, Dictionary<string, string>? requiredModVerisons = null, Dictionary<ModId, int>? priorities = null)
    {
        throw new NotImplementedException();
    }
}
public record ModpackVersion(string Name, string MinecraftVersion, List<IModVersion> Versions)
{
}
