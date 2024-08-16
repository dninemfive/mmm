namespace d9.mmm;
public interface IParsableWithDelimiter<TSelf>
{
    public static abstract TSelf Parse(string line, string delimiter);
}