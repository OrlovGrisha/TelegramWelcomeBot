using Application.Interfaces;
using Telegram.Bot;

namespace Telegram.Services;

public class MessageManager : IBotService
{
    private readonly ITelegramBotClient _telegramBotClient;
    public MessageManager(ITelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
    }

    public async Task SendMessageToUser(long chatId, string message)
    {
        await _telegramBotClient.SendMessage(chatId, message);
    }
}