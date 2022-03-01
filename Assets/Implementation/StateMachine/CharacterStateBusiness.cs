using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateBusiness : StateMachineBusiness<CharacterState>
{
    public InputProcessor inputProcessor;
    public RigidbodyManager rbManager;

    private void Awake() 
    {
        InitializeStates();    
    }

    public override void InitializeStates()
    {
        base.InitializeStates();
        AddState("Running", new RunningCharacterState(this));
        stateMachine = new StateMachine<CharacterState>(GetState("Running"));
    }

    private void Update() 
    {
        stateMachine.TickCurrentState();    
    }

    private void FixedUpdate() 
    {
        stateMachine.TickCurrentStateFixed();    
    }
    
}
