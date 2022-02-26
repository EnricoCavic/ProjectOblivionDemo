using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachineBusiness<T> : MonoBehaviour
    where T : State
{
    public StateMachine<T> stateMachine { get; protected set; }

    private Dictionary<string, T> stateDictionary;

    public virtual void InitializeStates() 
    {
        stateDictionary = new Dictionary<string, T>();
    }

    protected void TickStateMachine() 
    {
        stateMachine?.TickCurrentState();
    }

    protected void FixedTickStateMachine() 
    {
        stateMachine?.TickCurrentStateFixed();   
    }

    public T AddState(string _stateTag, T _newState)
    {
        if(stateDictionary.ContainsKey(_stateTag) || stateDictionary == null)
            return null;

        stateDictionary.Add(_stateTag, _newState);
        return stateDictionary[_stateTag];
    }

    public T GetState(string _stateTag) => stateDictionary[_stateTag];



}
