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

    public override State Tick()
    {
        business.rbManager.CheckForTurn();
        if(!business.rbManager.IsGrounded())
            return business.GetState(CharStates.Airborne);

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
                if(_input.boolParam)
                {
                    Parameters param = new Parameters();
                    param.id = "Jump";
                    onInputProcessed?.Invoke(param);
                    business.stateMachine.NewState(business.GetState(CharStates.Jumping));
                }
                    
                break;

            default:
                break;
        }
    }
}
