using System.Diagnostics.CodeAnalysis;

namespace d9.lcm;
public readonly struct ModLoader(string name, params string[] compatibleModloaders)
{
    public readonly string Name = name;
    public readonly string[] CompatibleModloaders = compatibleModloaders;
    public static implicit operator string(ModLoader modloader)
        => modloader.Name;
    public static bool operator ==(ModLoader a, ModLoader b)
        => a.Name == b.Name;
    public static bool operator !=(ModLoader a, ModLoader b)
        => !(a == b);
    public override string ToString()
        => this;
    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is ModLoader other && this == other;
    public override int GetHashCode()
        => HashCode.Combine(Name);
}
