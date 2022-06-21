using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterStateBusiness : StateMachineBusiness<CharacterState>
{
    public InputProcessor inputProcessor;
    public ProjectOblivionRBM rbManager;

    private void OnEnable() 
    {
        inputProcessor.inputAsset.Gameplay.MainInput.started += FeedMainInputStarted;
        inputProcessor.inputAsset.Gameplay.MainInput.canceled += FeedMainInputCanceled;    
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
        stateMachine.NewState(GetState(typeof(JumpingCharacterState)));
    }

    public void WallJumpAction(bool _invertedHorizontalForce)
    {
        inputProcessor.ResetBuffer(true);
        rbManager.Jump(rbManager.variables.wallJumpVerticalForce);
        rbManager.HorizontalVelocity(rbManager.variables.wallJumpHorizontalForce, rbManager.RunningDirection());
        stateMachine.NewState(GetState(typeof(JumpingCharacterState)));
    }

}
