﻿using Modrinth;
using Modrinth.Models;
using Modrinth.Models.Tags;
using d9.utl;

namespace d9.mmm;
public record ModOutputRow(string Name, string ModUrl, Decision Decision, string[]? Categories, GameVersion? MostRecentVersion)
    : IWritableWithDelimiter
{
    public static Func<ModInputRow, Task<ModOutputRow>> TransformFunction(ModrinthClient client, MinecraftVersions mvs)
        => async (ModInputRow mir) =>
        {
            static ModOutputRow defaultValue(ModInputRow mir)
                => new(mir.ModName, mir.ModUrl, mir.Decision, null, null);
            if (mir.ModUrl.TryGetSlug(out string? slug))
            {
                try
                {
                    Project project = await client.Project.GetAsync(slug);
                    return new(project.Title, project.Url, mir.Decision, project.Categories, mvs.MostRecentVersion(project.GameVersions));
                }
                catch
                {
                    return defaultValue(mir);
                }
            }
            return defaultValue(mir);
        };
    public string ToLine(string delimiter)
    {
        string[] items = [
            Name,
            ModUrl,
            Decision.ToString(),
            Categories?.ListNotation(brackets: null).PrintNull()!,
            MostRecentVersion?.Version.PrintNull()!
        ];
        return items.InColumns([24, 64, 8, 32, 8], delimiter, true);
    }     
}
