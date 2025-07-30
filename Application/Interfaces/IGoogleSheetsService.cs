namespace Application.Interfaces;

public interface IGoogleSheetsService
{
    public Task AppendRowAsync(string range, IList<object> row);
    public Task ClearCellsAsync(string range);
}