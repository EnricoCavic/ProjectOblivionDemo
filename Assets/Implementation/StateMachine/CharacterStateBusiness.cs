using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum CharStates { Running, Jumping }

public class CharacterStateBusiness : StateMachineBusiness<CharacterState>
{
    public InputProcessor inputProcessor;
    public ProjectOblivionRBM rbManager;

    private void Awake() 
    {
        InitializeStates();    
    }

    private void OnEnable()
    {
        SubUnsubInputs(true);
        SubUnsubRbResponses(true);
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
        SubUnsubInputs(false);
        SubUnsubRbResponses(false);
    }

    public override void InitializeStates()
    {
        base.InitializeStates();

        AddState(CharStates.Running, new RunningCharacterState(this));
        AddState(CharStates.Jumping, new JumpingCharacterState(this));
        
        stateMachine = new StateMachine<CharacterState>(GetState(CharStates.Running));
    }

   private void SubUnsubInputs(bool _isSubscribing)
    {
        InputAction mainInput = inputProcessor.GetAction("MainInput").action;

        if(_isSubscribing)
        {
            mainInput.started += MainInput;
            mainInput.canceled += MainInput;
            return;
        }

        mainInput.started -= MainInput;
        mainInput.canceled -= MainInput;

    }

    private void SubUnsubRbResponses(bool _isSubscribing)
    {
        if(_isSubscribing)
        {
            GetState(CharStates.Running).onInputProcessed += rbManager.ApplyInput;
            GetState(CharStates.Running).onEnter += rbManager.OnStateEnter;
            GetState(CharStates.Jumping).onEnter += rbManager.OnStateEnter;            
            return;
        }    

        GetState(CharStates.Running).onEnter -= rbManager.OnStateEnter;
        GetState(CharStates.Running).onInputProcessed -= rbManager.ApplyInput;       
        GetState(CharStates.Jumping).onEnter -= rbManager.OnStateEnter;    
    }

    public void MainInput(InputAction.CallbackContext _context)
    {
        StateInput _input = new StateInput();
        _input.id = "MainInput";
        _input.boolParam = _context.ReadValue<float>() > float.Epsilon;
        stateMachine.FeedInput(_input);
    }

 
    
}
