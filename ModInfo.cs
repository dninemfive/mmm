using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d9.lcm;
public class ModInfo
{
    public string Name, ModrinthLink, CurseForgeLink, Description, McVersion, ModVersion;
    public Purpose Purpose;
    public DateOnly ReleaseDate, LastUpdateDate;
    public float FileSizeKb;
    public IEnumerable<string> DependencyKeys, SupportedMcVersions;
    public InstallTarget InstallTarget;
    public Status Status;
}
public enum Purpose
{
    Administration,
    Aesthetic,
    Audio,
    Content,
    Convenience,
    Decor,
    Library,
    Misc,
    Neat,
    Optimization,
    Social,
    Storage,
    Tweak,
    Utility,
    Visuals
}
public enum InstallTarget
{
    Client,
    Server,
    ClientOrServer,
    ClientAndServer
}
public enum Status
{
    LockedIn,
    Active,
    Deferred,
    Pending,
    Poll,
    Considering,
    Rejected
}