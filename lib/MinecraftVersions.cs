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
    public IEnumerable<GameVersion> Parse(IEnumerable<string> input)
        => input.Select(x => this[x]);
    public GameVersion MostRecent(IEnumerable<GameVersion> gameVersions)
        => gameVersions.OrderBy(x => x.Date).Last();
    public GameVersion MostRecentVersion(IEnumerable<string> input)
        => MostRecent(Parse(input));
    private IEnumerable<GameVersion> _versionsWhere(Func<GameVersion, bool> predicate)
        => _dict.Values.Where(predicate);
    public IEnumerable<GameVersion> VersionsWhere(Func<GameVersion, bool> predicate)
        => _versionsWhere(predicate).Order();
    public IEnumerable<GameVersion> VersionsSince(GameVersion version)
        => VersionsWhere(x => x.Date > version.Date);
    public IEnumerable<GameVersion> MajorVersionsSince(GameVersion version)
        => VersionsWhere(x => x.Major && x.Date > version.Date);
    public IEnumerable<GameVersion> MajorVersionsSince(string version)
        => VersionsWhere(x => x.Major && x.Date > _dict[version].Date);
}