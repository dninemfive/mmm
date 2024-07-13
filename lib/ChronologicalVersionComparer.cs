using Modrinth.Models.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d9.lcm;
public class ChronologicalVersionComparer : IComparer<GameVersion>
{
    public int Compare(GameVersion? x, GameVersion? y)
        => x?.Date.CompareTo(y?.Date) ?? 0;
}
