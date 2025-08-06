using Application.Interfaces;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace GoogleSheets;

public class GoogleSheetsService : IGoogleSheetsService
{
    private readonly SheetsService _sheetsService;
    private readonly string _spreadsheetId = "1lNq7Tq7y2pxVxE_hs5Bo8uof1EzmqJRiGOi5bv8aPGY";

    public GoogleSheetsService(SheetsService sheetsService)
    {
        _sheetsService = sheetsService;
    }

    public async Task AppendRowAsync(string range, IList<object> row)
    {
        var valueRange = new ValueRange
        {
            Values = new List<IList<object>> { row }
        };

        var request = _sheetsService.Spreadsheets.Values.Append(valueRange, _spreadsheetId, range);
        request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.RAW;
        await request.ExecuteAsync();
    }

    public async Task ClearCellsAsync(string range)
    {
        var request = _sheetsService.Spreadsheets.Values.Clear(new ClearValuesRequest(), _spreadsheetId, range);
        
        await request.ExecuteAsync();
    }
}