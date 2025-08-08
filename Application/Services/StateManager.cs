using Application.Interfaces;
using Application.States;
using Application.States.Registration;

namespace Application.Services;

public class StateManager
{
    private readonly ICacheService _cacheService;
    private readonly Dictionary<string, Func<IState>> _states;

    public StateManager(ICacheService cacheService)
    {
        _cacheService = cacheService;
        
        _states = new Dictionary<string, Func<IState>>()
        {
            ["default"] = () => new DefaultState(),
            ["waitingForName"] = () => new WaitingForNameState(this),
            ["waitingForConfirmation"] = () => new WaitingForConfirmationState(this)
        };
    }

    public async Task SetState(long chatId, IState state)
    {
        var stateKey = _states.First(x => x.Value().GetType() == state.GetType()).Key;

        await _cacheService.SetAsync(chatId, stateKey);
    }

    public async Task<IState> GetState(long chatId)
    {
        var key = await _cacheService.GetAsync(chatId) ?? "default";

        return _states[key]();
    }
}