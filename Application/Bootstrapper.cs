using Application.Interfaces;
using Application.Services;
using Application.States;
using Application.States.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Bootstrapper
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<CommandHandler>();
        services.AddSingleton<StateManager>();

        services.AddTransient<DefaultState>();
        services.AddTransient<WaitingForNameState>();
        services.AddTransient<WaitingForConfirmationState>();
        
        return services;
    }
}