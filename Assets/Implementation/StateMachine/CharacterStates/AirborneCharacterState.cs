using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirborneCharacterState : CharacterState
{

    float currentWallJumpCoyoteTime;
    bool canWallJump;
    bool canCoyote;

    private void Awake()
    {
        Init();
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
            business.rbManager.TurnArround();
            if(business.inputProcessor.IsMainInputBuffered(true))
            {
                business.WallJumpAction(false);
                return business.GetState(typeof(JumpingCharacterState));
            }       
            canWallJump = true;     
        }
        else if(canWallJump)
        {
            currentWallJumpCoyoteTime += Time.deltaTime;
            canWallJump = currentWallJumpCoyoteTime < business.rbManager.variables.wallJumpCoyoteTime;
        }

        
        if(business.rbManager.IsGrounded())
            return business.GetState(typeof(RunningCharacterState));

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
        {
            business.WallJumpAction(true);
        }

    }


}
