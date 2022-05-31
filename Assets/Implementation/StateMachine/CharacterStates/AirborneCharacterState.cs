using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirborneCharacterState : CharacterState
{

    float currentWallJumpCoyoteTime;
    bool canWallJump;

    public AirborneCharacterState(CharacterStateBusiness _business)
    {
        enumId = CharStates.Airborne; 
        Init(_business);
    }

    public override void Enter()
    {
        currentWallJumpCoyoteTime = 0f;
        canWallJump = false;
    }

    public override State Tick()
    {
        if(business.rbManager.HasWallOnFront())
        {
            if(business.inputProcessor.IsMainInputBuffered(true))
            {
                business.JumpAction();
                return business.GetState(CharStates.Jumping);
            }       
            canWallJump = true;     
        }
        else if (canWallJump)
        {
            currentWallJumpCoyoteTime += Time.deltaTime;
            canWallJump = currentWallJumpCoyoteTime < business.rbManager.variables.wallJumpCoyoteTime;
        }

        business.rbManager.CheckForTurn();
        
        if(business.rbManager.IsGrounded())
            return business.GetState(CharStates.Running);

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
        if(canWallJump)
            business.JumpAction();
    }


}
