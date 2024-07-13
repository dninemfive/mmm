﻿using Modrinth;
using Modrinth.Models;
using Modrinth.Models.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ModVersion = Modrinth.Models.Version;

namespace d9.lcm.gui;
public static partial class ModrinthUtils
{
    public static ModrinthClient Client { get; set; } = new(new ModrinthClientConfig()
    {
        UserAgent = "dninemfive-lcm/0.0.0"
    });
    public static bool IsCompatibleWith(this ModVersion a, ModVersion b)
    {
        static bool conflicts(ModVersion left, ModVersion right)
        {
            foreach (Dependency dependency in left.Dependencies ?? [])
            {
                if (dependency.ProjectId == left.ProjectId)
                    return true;
            }
            return false;
        }
        return !(conflicts(a, b) || conflicts(b, a));
    }
    public static async Task<ModVersion?> ToModVersion(this Dependency dependency)
        => dependency.VersionId is string id ? await Client.Version.GetAsync(id) : null;
    public static async Task<MinecraftVersions> GetMinecraftVersionsAsync()
        => new(await Client.Tag.GetGameVersionsAsync());
    public static readonly Regex ModrinthRegex = GenerateModrinthRegex();

    [GeneratedRegex(@"https:\/\/modrinth\.com\/.+\/(.+)")]
    private static partial Regex GenerateModrinthRegex();
}