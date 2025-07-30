using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Services;

namespace Persistence;

public static class Bootstrapper
{
    public static IServiceCollection AddTelegramPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<BotContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IStudentRepository, StudentRepository>();
        
        return services;
    }
}