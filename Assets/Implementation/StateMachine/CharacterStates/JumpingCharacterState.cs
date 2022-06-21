using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingCharacterState : CharacterState
{

    float currentJumpTime;
    bool canEndJump;
    private void Awake()
    {
        Init();
    }

    public override void Enter()
    {
        currentJumpTime = 0f;
        canEndJump = false;

        business.rbManager.OnStateEnter(this);
    }

    public override State Tick()
    {
        currentJumpTime += Time.deltaTime;
        canEndJump = currentJumpTime > business.rbManager.variables.minJumpTime;
        if(canEndJump && !business.inputProcessor.mainInputHeld)
            return business.GetState(typeof(AirborneCharacterState)); 
        

        business.rbManager.CheckForTurn();
        
        if(business.rbManager.IsFalling())
            return business.GetState(typeof(AirborneCharacterState)); 
             
        if(!business.rbManager.IsMovingVertical() && business.rbManager.IsGrounded())
            return business.GetState(typeof(RunningCharacterState));

        return this;
    }

    public override State FixedTick()
    {
        business.rbManager.Move(business.rbManager.variables.acceleration);
        business.rbManager.ApplyGravityMultiplier(this);
        return this;
    }


    public override void MainInputCanceled()
    {
        if(canEndJump)
            business.stateMachine.NewState(business.GetState(typeof(AirborneCharacterState)));
    }

}
