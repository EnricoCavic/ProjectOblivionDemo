using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum CharStates { Running, Jumping, Airborne }

public class CharacterStateBusiness : StateMachineBusiness<CharacterState>
{
    public InputProcessor inputProcessor;
    public ProjectOblivionRBM rbManager;

    private void Start() 
    {
        InitializeStates();    
    }

    private void OnEnable() 
    {
        inputProcessor.inputAsset.Gameplay.MainInput.started += FeedMainInputStarted;
        inputProcessor.inputAsset.Gameplay.MainInput.canceled += FeedMainInputCanceled;    
    }

    private void Update() 
    {
        stateMachine.TickCurrentState();    
        //Debug.Log(stateMachine.currentState.enumId);
    }

    private void FixedUpdate() 
    {
        stateMachine.TickCurrentStateFixed();    
    }


    public override void InitializeStates()
    {
        base.InitializeStates();

        AddState(CharStates.Running, new RunningCharacterState(this));
        AddState(CharStates.Jumping, new JumpingCharacterState(this));
        AddState(CharStates.Airborne, new AirborneCharacterState(this));
        
        stateMachine = new StateMachine<CharacterState>(GetState(CharStates.Running));
    }

    private void OnDisable() 
    {
        inputProcessor.inputAsset.Gameplay.MainInput.started -= FeedMainInputStarted;
        inputProcessor.inputAsset.Gameplay.MainInput.canceled -= FeedMainInputCanceled;    
    }

    private void FeedMainInputStarted(InputAction.CallbackContext _context)
    {
        stateMachine.currentState.MainInputStarted();
    }

    private void FeedMainInputCanceled(InputAction.CallbackContext _context)
    {
        stateMachine.currentState.MainInputCanceled();
    }

    public void JumpAction()
    {
        inputProcessor.ResetBuffer(true);
        rbManager.Jump(rbManager.variables.jumpForce);
        stateMachine.NewState(GetState(CharStates.Jumping));
    }

    public void WallJumpAction(bool _invertedHorizontalForce)
    {
        inputProcessor.ResetBuffer(true);
        rbManager.Jump(rbManager.variables.wallJumpVerticalForce);
        float dir = _invertedHorizontalForce ? rbManager.RunningDirection() : rbManager.RunningDirection() * -1f;
        rbManager.HorizontalVelocity(rbManager.variables.wallJumpHorizontalForce, dir);
        stateMachine.NewState(GetState(CharStates.Jumping));
    }

}
