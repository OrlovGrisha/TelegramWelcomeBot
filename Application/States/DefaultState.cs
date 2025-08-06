using Application.Interfaces;
using Application.Services;

namespace Application.States;

public class DefaultState : IState
{
    
    public async Task HandleMessage(long chatId, string message, IBotService botService)
    {
        await botService.SendMessageToUser(chatId, "Такой команды нет, выбери из предложенных: \n\n/start \n/register");
    }
}