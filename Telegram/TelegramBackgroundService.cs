using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace Telegram;

public class TelegramBackgroundService : BackgroundService
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IUpdateHandler _updateHandler;
    
    public TelegramBackgroundService(ITelegramBotClient telegramBotClient, IUpdateHandler updateHandler)
    {
        _telegramBotClient = telegramBotClient;
        _updateHandler = updateHandler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var receiverOptions = new ReceiverOptions { AllowedUpdates = Array.Empty<UpdateType>() };
        
        await _telegramBotClient.ReceiveAsync(_updateHandler, receiverOptions, stoppingToken);
    }
}