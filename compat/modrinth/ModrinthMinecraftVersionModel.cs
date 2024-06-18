using static d9.lcm.compat.modrinth.ModrinthEnums;
namespace d9.lcm.compat.modrinth;
/// <summary>
/// https://docs.modrinth.com/#tag/tags/operation/versionList
/// </summary>
public record ModrinthMinecraftVersionModel
{
    /// <summary>
    /// The name/number of the game version
    /// </summary>
    public required string Version { get; set; }
    /// <summary>
    /// The type of the game version
    /// </summary>
    public required MinecraftVersionType VersionType { get; set; }
    /// <summary>
    /// The date of the game version release
    /// </summary>
    public required DateTime Date { get; set; }
    /// <summary>
    /// Whether or not this is a major version, used for Featured Versions
    /// </summary>
    public required bool Major { get; set; }
}
