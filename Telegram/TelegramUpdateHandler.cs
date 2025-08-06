using Application.Commands.Registration;
using Application.Interfaces;
using Application.Services;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Services;

namespace Telegram;

public class TelegramUpdateHandler : IUpdateHandler
{
    private readonly CommandHandler _commandHandler;
    private readonly StateManager _stateManager;
    private readonly IBotService _messageManager;
    
    public TelegramUpdateHandler(CommandHandler commandHandler, StateManager stateManager, IBotService messageManager)
    {
        _commandHandler = commandHandler;
        _stateManager = stateManager;
        _messageManager = messageManager;
        
        _commandHandler.RegisterCommand(new StartCommand());
        _commandHandler.RegisterCommand(new RegisterCommand(_stateManager));
    }

    // Реализовать State Machine и Command Pattern вместе
    public async Task HandleUpdateAsync(ITelegramBotClient telegramBotClient, Update update, CancellationToken cancellationToken)
    {
        long chatId = update.Message.Chat.Id;
        string message = update.Message.Text;

        if (await _commandHandler.TryExecuteCommand(chatId, message, _messageManager)) return;
        
        var state = _stateManager.GetState(chatId);
        await state.HandleMessage(chatId, message, _messageManager);
    }

    public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
    {
        Console.WriteLine(exception.Message);
    }
}