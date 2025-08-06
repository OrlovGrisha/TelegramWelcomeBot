namespace Application.Interfaces;

public interface IState
{
    Task HandleMessage(long chatId, string message, IBotService botService);
}