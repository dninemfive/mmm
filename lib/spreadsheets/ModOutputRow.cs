using Modrinth.Models;
using Modrinth.Models.Tags;

namespace d9.lcm;
public record ModOutputRow(string Name, string ModUrl, Decision Decision, List<string>? Categories, GameVersion MostRecentVersion)
    : IAsyncTransformable<ModInputRow, ModOutputRow>
{
    public static async Task<ModOutputRow> TransformAsync(ModInputRow mir)
    {
        if(mir.ModUrl.TryGetSlug(out string? slug))
        {
            Project project = await 
        }
    }
}
