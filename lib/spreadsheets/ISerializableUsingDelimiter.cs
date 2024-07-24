namespace d9.lcm;
public interface ISerializableUsingDelimiter<TSelf>
{
    public static abstract TSelf FromLine(string line, string delimiter);
    public abstract string ToLine(string delimiter);
}