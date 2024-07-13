using Modrinth.Models.Tags;

namespace d9.lcm.gui;
public class MinecraftVersions
{
    private Dictionary<string, GameVersion> _dict = new();
    public MinecraftVersions(IEnumerable<GameVersion> versions)
    {
        foreach (GameVersion version in versions)
            _dict[version.Version] = version;
    }
    public GameVersion this[string version]
        => _dict[version];
    public DateTime ReleaseDateFor(string version)
        => this[version].Date;
}