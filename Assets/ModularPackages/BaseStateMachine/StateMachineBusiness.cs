using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachineBusiness<T> : MonoBehaviour
    where T : State
{
    public StateMachine<T> stateMachine { get; protected set; }

    [NonSerialized] public Dictionary<Enum, T> stateDictionary;

    public virtual void InitializeStates() 
    {
        stateDictionary = new Dictionary<Enum, T>();
    }

    protected void TickStateMachine() 
    {
        stateMachine?.TickCurrentState();
    }

    protected void FixedTickStateMachine() 
    {
        stateMachine?.TickCurrentStateFixed();   
    }

    public T AddState(Enum _stateTag, T _newState)
    {
        if(stateDictionary.ContainsKey(_stateTag) || stateDictionary == null)
            return null;

        stateDictionary.Add(_stateTag, _newState);
        return stateDictionary[_stateTag];
    }

    public T GetState(Enum _stateTag) => stateDictionary[_stateTag];



}
