using Application.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Microsoft.Extensions.DependencyInjection;

namespace GoogleSheets;

public static class Bootstrapper
{
    public static IServiceCollection AddGoogleSheets(this IServiceCollection services, string credentialsPath)
    {
        var credential = GoogleCredential
            .FromFile(credentialsPath)
            .CreateScoped(SheetsService.Scope.Spreadsheets);
        
        var sheetsService = new SheetsService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "TgWelcomeBot"
        });
        
        services.AddSingleton(sheetsService);

        services.AddSingleton<IGoogleSheetsService, GoogleSheetsService>();

        return services;
    }
}