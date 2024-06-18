using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace d9.lcm;
public record MinecraftVersion
{
    [JsonPropertyName("version")]
    public required string Name { get; set; }
    [JsonPropertyName("version_type")]
    public required MinecraftVersionType VersionType { get; set; }
    [JsonPropertyName("date")]
    public required DateTime ReleaseDate { get; set; }
    [JsonPropertyName("major")]
    public required bool IsMajorRelease { get; set; }
}
public class Iso8601DateJsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateTime.ParseExact(reader.GetString()!, "O", CultureInfo.InvariantCulture);
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString("O", CultureInfo.InvariantCulture));
}
public enum MinecraftVersionType { Release, Snapshot, Alpha, Beta }