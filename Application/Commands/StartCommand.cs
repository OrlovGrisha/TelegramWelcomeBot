using Application.Interfaces;

namespace Application.Commands.Registration;

public class StartCommand : ICommand
{
    public string Name => "start";
    
    public async Task Execute(long chatId, IBotService botService)
    {
        await botService.SendMessageToUser(chatId, "Привет! Это бот чистой архитектуры \n\nВведи команду /register, чтобы продолжить");
    }
}