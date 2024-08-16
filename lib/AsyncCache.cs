namespace d9.mmm;
public class AsyncCache<K, V>(Func<K, Task<V>> getter)
    where K : notnull
{
    private readonly Dictionary<K, V> _cache = new();
    private readonly Func<K, Task<V>> _getter = getter;
    public async Task<V> TryGet(K key)
    {
        if (_cache.TryGetValue(key, out V? value))
            return value;
        V? result = await _getter(key);
        if (result is not null)
            _cache[key] = result;
        return result;
    }
}
