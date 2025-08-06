namespace Application.Interfaces;

public interface IBotService
{
    public Task SendMessageToUser(long chatId, string message);
}