using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Services;

namespace Telegram;

public static class Bootstrapper
{
    public static IServiceCollection AddTelegramInfrastructure(this IServiceCollection services, string token)
    {
        services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(token));

        services.AddSingleton<IUpdateHandler, TelegramUpdateHandler>();
        services.AddHostedService<TelegramBackgroundService>();

        services.AddSingleton<IBotService, MessageManager>();
        
        return services;
    }
}