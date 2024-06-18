using Modrinth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = Modrinth.Models.Version;

namespace d9.lcm.gui;
public interface IModVersion
{
    public string ModKey { get; }
    public string VersionNumber { get; }
    public bool IsCompatibleWith(IModVersion other);
}
public record ModrinthModVersion : IModVersion
{
    public string ModKey { get; private set; }
    public string VersionNumber { get; private set; }
    public Version Version { get; private set; }
    private ModrinthModVersion(string modKey, string versionNumber, Version version)
    {
        ModKey = modKey;
        VersionNumber = versionNumber;
        Version = version;
    }
    public static async Task<ModrinthModVersion?> GetVersion(string modSlug, string modVersionNumber)
    {
        Version version = await ModrinthUtils.Client.Version.GetByVersionNumberAsync(modSlug, modVersionNumber);
        return new(modSlug, modVersionNumber, version);
    }
}
