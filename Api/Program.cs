using Application;
using GoogleSheets;
using Persistence;
using Redis;
using Telegram;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddTelegramInfrastructure(builder.Configuration["TelegramBot:Token"]!);
        builder.Services.AddTelegramPersistence(builder.Configuration.GetConnectionString("DefaultConnection")!);
        builder.Services.AddRedis();
        builder.Services.AddApplicationServices();
        builder.Services.AddGoogleSheets("credentials.json");

        var app = builder.Build();
        
        app.Run();
    }
}