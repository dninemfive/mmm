namespace d9.lcm;
public interface IParsableWithDelimiter<TSelf>
{
    public static abstract TSelf Parse(string line, string delimiter);
}
