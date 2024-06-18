using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modrinth;
using Modrinth.Models;

namespace d9.lcm.gui;
public record ModId(string? ModrinthSlug, string? CurseforgeUrl)
{
    public string Key => ModrinthSlug 
                      ?? CurseforgeUrl 
                      ?? throw new Exception("A ModDecision must have a Modrinth slug, a Curseforge URL, or both!");
}
