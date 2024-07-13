namespace d9.lcm;
public interface IAsyncTransformable<T, U>
{
    public static abstract Task<U> TransformAsync(T t);
}
