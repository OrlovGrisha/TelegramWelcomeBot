using Application.Interfaces;
using Application.Services;

namespace Application.States.Registration;

public class WaitingForNameState : IState
{
    private readonly StateManager _stateManager;
    public WaitingForNameState(StateManager stateManager) => _stateManager = stateManager;

    public async Task HandleMessage(long chatId, string message, IBotService botService)
    {
        _stateManager.SetState(chatId, new WaitingForConfirmationState(_stateManager));
        
        await botService.SendMessageToUser(chatId, $"Ваше имя: {message}");
    }
}