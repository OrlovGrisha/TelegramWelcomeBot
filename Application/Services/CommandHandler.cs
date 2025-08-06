using Application.Interfaces;

namespace Application.Services;

public class CommandHandler
{
    private readonly Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();
    public void RegisterCommand(ICommand command) => _commands.Add(command.Name, command);

    public async Task<bool> TryExecuteCommand(long chatId, string message, IBotService botService)
    {
        if (!message.StartsWith("/")) return false;

        var name = message.TrimStart('/');

        if (_commands.TryGetValue(name, out var cmd))
        {
            await cmd.Execute(chatId, botService);
            return true;
        }

        await botService.SendMessageToUser(chatId, $"Неизвестная команда: {message}");
        return true;
    }
}