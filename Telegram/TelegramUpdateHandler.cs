using Application.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace Telegram;

public class TelegramUpdateHandler : IUpdateHandler
{
    private readonly IGoogleSheetsService _googleSheetsService;
    public TelegramUpdateHandler(IGoogleSheetsService googleSheetsService)
    {
        _googleSheetsService = googleSheetsService;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient telegramBotClient, Update update, CancellationToken cancellationToken)
    {
        long chatId = update.Message.Chat.Id;
        string message = update.Message.Text;

        await _googleSheetsService.AppendRowAsync("Лист1!A4", new List<object>() { "Приветик" });
        
        await telegramBotClient.SendMessage(chatId,"Привет!", cancellationToken: cancellationToken);

        if (message is "Очистить")
        {
            await _googleSheetsService.ClearCellsAsync("Лист1!B1:B4");
        }
    }

    public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
    {
        Console.WriteLine(exception.Message);
    }
}