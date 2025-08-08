using Application.Interfaces;
using StackExchange.Redis;

namespace Redis;

public class CacheService : ICacheService
{
    private readonly IDatabase _cache;

    public CacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _cache = connectionMultiplexer.GetDatabase();
    }

    public async Task SetAsync(long chatId, string value)
    {
        Console.WriteLine($"Установлен кэш: key = {chatId}; value = {value}");
        
        await _cache.StringSetAsync($"user_state:{chatId}", value);
    }

    public async Task<string?> GetAsync(long chatId)
    {
        var key = $"user_state:{chatId}";
        var value = await _cache.StringGetAsync(key);
    
        Console.WriteLine($"[Cache] GET key = {key}, value = {value}");

        return value;
    }

    public async Task RemoveAsync(long chatId)
    {
        await _cache.KeyDeleteAsync($"user_state:{chatId}");
    }
}