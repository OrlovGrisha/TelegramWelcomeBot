using Application.Interfaces;
using Application.States;

namespace Application.Services;

public class StateManager
{
    private readonly Dictionary<long, IState> _states = new Dictionary<long, IState>();
    public void SetState(long chatId, IState state) => _states[chatId] = state;

    public IState GetState(long chatId)
    {
        return _states.TryGetValue(chatId, out var state) ? state : new DefaultState();
    }
}