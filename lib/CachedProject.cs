using Modrinth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d9.lcm;
public class CachedProject(Project project)
{
    public Project Project = project;
    public async Task<CachedProject> FromSlug(string slug)
        => await Modrinth.Models.
}
