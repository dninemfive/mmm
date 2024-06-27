namespace d9.lcm.gui;
public record MinecraftVersion(string Name, DateTime ReleaseTime)
    : IComparable<MinecraftVersion>
{
    public int CompareTo(MinecraftVersion? other)
        => ReleaseTime.CompareTo(other?.ReleaseTime);
}