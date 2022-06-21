using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachineBusiness<S> : MonoBehaviour 
    where S : State
{
    public StateMachine<S> stateMachine { get; protected set; }

    public S initialState;
    public List<S> states;

    private void Start() => InitializeStates();    
    private void OnValidate() => states = new List<S>(GetComponents<S>());
    private void Update() => stateMachine?.TickCurrentState();
    private void FixedUpdate() => stateMachine?.TickCurrentStateFixed();  

    private void InitializeStates() 
    {
        states = new List<S>(GetComponents<S>());

        S initial = initialState != null ? initialState : states[0];
        stateMachine = new StateMachine<S>(initial);
    } 

    public S GetState(Type _stateType)
    {
        if(states.Count <= 0) 
            return null;

        for(int i = 0; i < states.Count; i++)
            if(states[i].GetType() == _stateType)
                return states[i];

        return null;
    }
}
