namespace Application.Interfaces;

public interface ICommand
{
    string Name { get; }
    Task Execute(long chatId, IBotService botService);
}