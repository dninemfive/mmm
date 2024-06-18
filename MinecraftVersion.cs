using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace d9.lcm;
public readonly struct MinecraftVersion(string version, string versionType, DateTime date, bool isMajor)
    : IComparable<MinecraftVersion>
{
    public readonly string Version = version;
    public readonly DateTime ReleaseDate = date;

    public static bool operator ==(MinecraftVersion a, MinecraftVersion b)
        => a.Version == b.Version && a.ReleaseDate == b.ReleaseDate;
    public static bool operator !=(MinecraftVersion a, MinecraftVersion b)
        => !(a == b);
    public int CompareTo(MinecraftVersion other)
        => ReleaseDate.CompareTo(other.ReleaseDate);
    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is MinecraftVersion other && this == other;
    public override int GetHashCode()
        => HashCode.Combine(Version, ReleaseDate);
    public static bool operator <(MinecraftVersion a, MinecraftVersion b)
        => a.CompareTo(b) < 0;
    public static bool operator <=(MinecraftVersion a, MinecraftVersion b)
        => a.CompareTo(b) <= 0;
    public static bool operator >(MinecraftVersion a, MinecraftVersion b)
        => a.CompareTo(b) > 0;
    public static bool operator >=(MinecraftVersion a, MinecraftVersion b)
        => a.CompareTo(b) >= 0;
}