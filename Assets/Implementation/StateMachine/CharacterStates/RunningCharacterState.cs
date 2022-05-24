using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningCharacterState : CharacterState
{
    float currentCoyoteTime;
    bool canEndRun;
    public RunningCharacterState(CharacterStateBusiness _business)
    {
        enumId = CharStates.Running;
        Init(_business);
    }

    public override void Enter()
    {
        currentCoyoteTime = 0f;
        if(business.inputProcessor.IsMainInputBuffered(true))
        {
            MainInputStarted();
            return;
        }

        business.rbManager.OnStateEnter(this);
    }

    public override State Tick()
    {
        business.rbManager.CheckForTurn();

        if(business.rbManager.IsGrounded())
        {
            currentCoyoteTime = 0f;
            return this;
        }

        currentCoyoteTime += Time.deltaTime;
        canEndRun = currentCoyoteTime > business.rbManager.variables.coyoteTime;

        if(canEndRun)
            return business.GetState(CharStates.Airborne);

        return this;

        
    }

    public override State FixedTick()
    {
        business.rbManager.Move(business.rbManager.variables.acceleration);
        business.rbManager.ApplyGravityMultiplier(this);
        return this;
    }


    public override void MainInputStarted()
    {
        business.inputProcessor.ResetBuffer(true);
        business.rbManager.Jump(business.rbManager.variables.jumpForce);
        business.stateMachine.NewState(business.GetState(CharStates.Jumping));
    }
}
