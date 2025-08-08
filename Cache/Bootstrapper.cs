using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Redis;

public static class Bootstrapper
{
    public static IServiceCollection AddRedis(this IServiceCollection services)
    {
        services.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect("tgwelcomebot_redis:6379,abortConnect=false"));

        services.AddSingleton<ICacheService, CacheService>();
        
        return services;
    }
}