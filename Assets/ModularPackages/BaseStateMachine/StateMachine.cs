using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : State
{
    public T currentState { get; private set; }

    public StateMachine(T _initialState)
    {
        currentState = _initialState;
        currentState.Enter();
    }

    public void NewState(T _nextState)
    {
        if(_nextState == currentState)
            return;

        currentState.Exit();
        currentState = _nextState;
        currentState.Enter();
    }

    public void TickCurrentState()
    {
        NewState(currentState?.Tick() as T);
    }

    public void TickCurrentStateFixed()
    {
        NewState(currentState?.FixedTick() as T);
    }
}
