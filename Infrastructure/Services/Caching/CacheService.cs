using System.Collections.Concurrent;
using Domain.Abstractions.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Infrastructure.Services.Caching;

public class CacheService(IDistributedCache distributedCache) : ICacheService
{
    private static readonly ConcurrentDictionary<string, bool> CacheKeys = new();

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
    {
        var cachedValue = await distributedCache.GetStringAsync(key, cancellationToken);

        if (cachedValue is null)
        {
            return null;
        }
        
        var value = JsonConvert.DeserializeObject<T>(cachedValue);

        return value;
    }

    public async Task<T> GetAsync<T>(string key, Func<Task<T>> factory, CancellationToken cancellationToken = default) where T : class
    {
        var cachedValue = await GetAsync<T>(key, cancellationToken);

        if (cachedValue is not null)
        {
            return cachedValue;
        }
        
        cachedValue = await factory();
        
        await SetAsync(key, cachedValue, cancellationToken);

        return cachedValue;
    }

    public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default) where T : class
    {
        var cachedValue = JsonConvert.SerializeObject(value);
        
        await distributedCache.SetStringAsync(key, cachedValue, cancellationToken);
        
        CacheKeys.TryAdd(key, false);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await distributedCache.RemoveAsync(key, cancellationToken);

        CacheKeys.TryRemove(key, out var _);
    }

    public async Task RemoveByPrefixAsync(string prefixKey, CancellationToken cancellationToken = default)
    {
        IEnumerable<Task> tasks = CacheKeys
            .Keys
            .Where(key => key.StartsWith(prefixKey))
            .Select(key => RemoveAsync(key, cancellationToken));

        await Task.WhenAll(tasks);
    }
}