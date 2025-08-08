using Application.Interfaces;
using Application.Services;
using Application.States.Registration;

namespace Application.Commands.Registration;

public class RegisterCommand : ICommand
{
    public string Name => "register";
    private readonly StateManager _stateManager;

    public RegisterCommand(StateManager stateManager)
    {
        _stateManager = stateManager;
    }

    public async Task Execute(long chatId, IBotService botService)
    {
        await _stateManager.SetState(chatId, new WaitingForNameState(_stateManager));
        await botService.SendMessageToUser(chatId, "Введи свое ФИО и класс в корректном формате \n\nИванов Иван Иванович, 10А");
    }
}