using Modrinth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = Modrinth.Models.Version;

namespace d9.mmm;
public class CachedProject(Project project, ModAnalysisContext context)
{
    public readonly Project Project = project;
    public readonly ModAnalysisContext Context = context;
    public readonly AsyncCache<string, Version> Versions = new(s => context.ModrinthClient.Version.GetAsync(s));
}