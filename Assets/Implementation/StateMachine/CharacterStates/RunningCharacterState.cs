using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningCharacterState : CharacterState
{
    public RunningCharacterState(CharacterStateBusiness _business)
    {
        enumId = CharStates.Running;
        Init(_business);
    }

    public override void Enter()
    {
        if(business.inputProcessor.mainInputBuffer.x > 0f)
        {
            MainInputStarted();
            return;
        }

        business.rbManager.OnStateEnter(this);
    }

    public override State Tick()
    {
        business.rbManager.CheckForTurn();
        if(!business.rbManager.IsGrounded())
            return business.GetState(CharStates.Airborne);

        return this;
    }

    public override State FixedTick()
    {
        business.rbManager.Move(business.rbManager.variables.acceleration);
        return this;
    }


    public override void MainInputStarted()
    {
        business.inputProcessor.mainInputBuffer.x = 0f;
        business.rbManager.Jump(business.rbManager.variables.jumpForce);
        business.stateMachine.NewState(business.GetState(CharStates.Jumping));
    }
}
