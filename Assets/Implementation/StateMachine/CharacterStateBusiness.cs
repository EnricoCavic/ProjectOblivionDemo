using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterStateBusiness : StateMachineBusiness<CharacterState>
{
    public InputProcessor inputProcessor;
    public ProjectOblivionRBM rbManager;
    public bool inputTeste;

    private void Awake() 
    {
        InitializeStates();    
    }

    private void OnEnable() 
    {
        InputAction mainInput = inputProcessor.GetAction("MainInput").action;
        mainInput.started += MainInput;
        mainInput.canceled += MainInput;

        GetState("Running").onInputProcessed += rbManager.ApplyInput;
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

    private void OnDisable() 
    {
        InputAction mainInput = inputProcessor.GetAction("MainInput").action;
        mainInput.started -= MainInput;
        mainInput.canceled -= MainInput;


        GetState("Running").onInputProcessed -= rbManager.ApplyInput;
    }

    public void MainInput(InputAction.CallbackContext _context)
    {
        StateInput _input = new StateInput();
        _input.id = "MainInput";
        _input.boolParam = _context.ReadValue<float>() > float.Epsilon;
        stateMachine.FeedInput(_input);
    }
    
}
