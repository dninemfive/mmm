using Modrinth.Models;
using Modrinth.Models.Enums.Version;
using ModVersion = Modrinth.Models.Version;

namespace d9.lcm;
public record Modpack(string Name, string Loader, IEnumerable<string> ModUrls)
{

}
public record ModpackVersion(Modpack Modpack, string MinecraftVersion)
{
}
