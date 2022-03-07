using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingCharacterState : CharacterState
{
    public JumpingCharacterState(CharacterStateBusiness _business)
    {
        Init(_business);
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override State Tick()
    {
        business.rbManager.CheckForTurn();
        if(business.rbManager.IsGrounded() && business.rbManager.IsFalling())
            return business.GetState("Running");

        return this;
    }

    public override State FixedTick()
    {
        business.rbManager.Move();
        return this;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void ProcessInput(Parameters _input)
    {
        switch(_input.id)
        {
            case "MainInput":
                break;

            default:
                break;
        }
    }
}
