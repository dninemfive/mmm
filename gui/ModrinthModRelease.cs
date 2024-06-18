using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d9.lcm;
public readonly struct ModrinthModRelease
{
    public readonly MinecraftVersion MinecraftVersion;
    public readonly ModLoader ModLoader;
    public readonly string ModVersion, Changelog, ReleaseChannel, Publisher, ReleaseName, Url;
    public readonly string[] Dependencies;
    public readonly DateTime PublicationDate;
    public readonly string? VersionId;
}