namespace d9.lcm.compat.modrinth;
public record ModrinthLicenseModel
{
    public required string Title { get; set; }
    public string? Body { get; set; }
}
