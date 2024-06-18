using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static d9.lcm.compat.modrinth.ModrinthEnums;

namespace d9.lcm.compat.modrinth;
/// <summary>
/// https://docs.modrinth.com/#tag/projects/operation/searchProjects
/// </summary>
public record ModrinthProjectModel
{
    public required string Slug { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required List<string> Categories { get; set; }
    public required SupportType ClientSide { get; set; }
    public required SupportType ServerSide { get; set; }
    public required string Body { get; set; }
    public required string Status { get; set; }
    public string? RequestedStatus { get; set; }
    public List<string>? AdditionalCategories { get; set; }
    public string? IssuesUrl { get; set; }
    public string? SourceUrl { get; set; }
    public string? WikiUrl { get; set; }
    public string? DiscordUrl { get; set; }
    public List<string>? DonationUrls { get; set; }
    public required ProjectType ProjectType { get; set; }
    public required int Downloads { get; set; }
    public string? IconUrl { get; set; }
    public int? Color { get; set; }
    public string? ThreadId { get; set; }
    public MonetizationStatus? MonetizationStatus { get; set; }
    public required string Id { get; set; }
    public required string Team { get; set; }
    public required DateTime Published { get; set; }
    public required DateTime Updated { get; set; }
    public DateTime? Approved { get; set; }
    public DateTime? Queued { get; set; }
    public required int Followers { get; set; }
    public ModrinthLicenseModel? License { get; set; }
    public List<string>? Versions { get; set; }
    public List<string>? GameVersions { get; set; }
    public List<string>? Loaders { get; set; }
    public List<ModrinthGalleryImage>? Gallery { get; set; }
}
