using Modrinth;
using Modrinth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModVersion = Modrinth.Models.Version;

namespace d9.lcm.gui;
public static class ModrinthUtils
{
    public static ModrinthClient Client { get; set; }
    public static bool IsCompatibleWith(this ModVersion a, ModVersion b)
    {
        static bool conflicts(ModVersion left, ModVersion right)
        {
            foreach (Dependency dependency in left.Dependencies ?? [])
            {
                if (dependency.ProjectId == left.ProjectId)
                    return true;
            }
            return false;
        }
        return !(conflicts(a, b) || conflicts(b, a));
    }
    public static async Task<ModVersion?> ToModVersion(this Dependency dependency)
        => dependency.VersionId is string id ? await Client.Version.GetAsync(id) : null;
}