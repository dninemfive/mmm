namespace d9.lcm.compat.modrinth;
public static class ModrinthEnums
{
    // https://docs.modrinth.com/#tag/tags/operation/versionList
    public enum MinecraftVersionType
    {
        Release,
        Snapshot,
        Alpha,
        Beta
    }
    // https://docs.modrinth.com/#tag/projects/operation/addGalleryImage
    public enum GalleryImageExtension
    {
        Png,
        Jpg,
        Jpeg,
        Bmp,
        Gif,
        Webp,
        Svg,
        Svgz,
        Rgb
    }
    // https://docs.modrinth.com/#tag/project_model
    public enum SupportType
    {
        Required,
        Optional,
        Unsupported
    }
    /// <summary>
    /// The potential status types a Modrinth project can have. A subset of these can be requested statuses, namely:
    /// <br/>• Approved
    /// <br/>• Archived
    /// <br/>• Draft
    /// <br/>• Unlisted
    /// <br/>• Private
    /// </summary>
    public enum ProjectStatus
    {
        /// <summary>
        /// Can be a requested status.
        /// </summary>
        Approved,
        /// <summary>
        /// Can be a requested status.
        /// </summary>
        Archived,
        /// <summary>
        /// Can <b>NOT</b> be a requested status.
        /// </summary>
        Rejected,
        /// <summary>
        /// Can be a requested status.
        /// </summary>
        Draft,
        /// <summary>
        /// Can be a requested status.
        /// </summary>
        Unlisted,
        /// <summary>
        /// Can <b>NOT</b> be a requested status.
        /// </summary>
        Processing,
        /// <summary>
        /// Can <b>NOT</b> be a requested status.
        /// </summary>
        Withheld,
        /// <summary>
        /// Can <b>NOT</b> be a requested status.
        /// </summary>
        Scheduled,
        /// <summary>
        /// Can be a requested status.
        /// </summary>
        Private,
        /// <summary>
        /// Can <b>NOT</b> be a requested status.
        /// </summary>
        Unknown
    }
    public enum ProjectType
    {
        Mod,
        Modpack,
        ResourcePack,
        Shader
    }
    public enum MonetizationStatus
    {
        Monetized,
        Demonetized,
        ForceDemonetized
    }
}