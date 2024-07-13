using Modrinth;
using Modrinth.Models.Tags;

namespace d9.lcm;
public class MinecraftVersions
{
    private Dictionary<string, GameVersion> _dict = new();
    public MinecraftVersions(IEnumerable<GameVersion> versions)
    {
        foreach (GameVersion version in versions)
            _dict[version.Version] = version;
    }
    public static async Task<MinecraftVersions> DownloadUsing(ModrinthClient client)
        => new(await client.Tag.GetGameVersionsAsync());
    public GameVersion this[string version]
        => _dict[version];
    public DateTime ReleaseDateFor(string version)
        => this[version].Date;
}