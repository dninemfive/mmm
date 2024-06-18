using static d9.lcm.compat.modrinth.ModrinthEnums;

namespace d9.lcm.compat.modrinth;
/// <summary>
/// https://docs.modrinth.com/#tag/projects/operation/addGalleryImage
/// </summary>
public record ModrinthGalleryImage
{
    /// <summary>
    /// Image extension
    /// </summary>
    public required GalleryImageExtension Ext { get; set; }
    /// <summary>
    /// Whether an image is featured
    /// </summary>
    public required bool Featured { get; set; }
    /// <summary>
    /// Title of the image
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// Description of the image
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Ordering of the image
    /// </summary>
    public int? Ordering { get; set; }
}
