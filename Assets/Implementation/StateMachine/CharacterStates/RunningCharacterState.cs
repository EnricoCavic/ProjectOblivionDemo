using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningCharacterState : CharacterState
{
    float currentCoyoteTime;
    bool canEndRun;
    Vector3 groundMagnet => Vector3.down * business.rbManager.variables.runningGroundMagnet;
    Vector3 moveDirection = new Vector3();
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
            business.JumpAction();
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
        Vector3 gDir = business.rbManager.GroundDirection();
        moveDirection = gDir != Vector3.zero ? gDir : business.rbManager.transform.right;
        if(currentCoyoteTime > 0f)
            moveDirection += groundMagnet;
        Debug.Log(gDir + " / " + moveDirection);
        

        business.rbManager.Move(moveDirection ,business.rbManager.variables.acceleration);
        business.rbManager.ApplyGravityMultiplier(this);
        return this;
    }


    public override void MainInputStarted()
    {
        business.JumpAction();
    }
}
