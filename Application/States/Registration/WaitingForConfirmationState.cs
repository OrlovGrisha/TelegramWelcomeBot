using Application.Interfaces;
using Application.Services;

namespace Application.States.Registration;

public class WaitingForConfirmationState : IState
{
    private readonly StateManager _stateManager;
    public WaitingForConfirmationState(StateManager stateManager) => _stateManager = stateManager;

    public async Task HandleMessage(long chatId, string message, IBotService botService)
    {
        if (message.ToLower() == "да")
        {
            _stateManager.SetState(chatId, new DefaultState());

            await botService.SendMessageToUser(chatId, "Отлично! Вы зарегистрированы");
            return;
        }
        else if (message.ToLower() == "нет")
        {
            _stateManager.SetState(chatId, new WaitingForNameState(_stateManager));

            await botService.SendMessageToUser(chatId, "Хорошо, введите заново Ваше ФИО и класс:\n\nИванов Иван Иванович, 10А");
            return;
        }

        await botService.SendMessageToUser(chatId, "Введите только да или нет");
    }
    
}