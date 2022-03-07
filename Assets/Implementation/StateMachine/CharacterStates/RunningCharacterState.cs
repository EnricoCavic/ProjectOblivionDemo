using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningCharacterState : CharacterState
{
    public RunningCharacterState(CharacterStateBusiness _business)
    {
        Init(_business);
    }

    public override void Enter()
    {
        base.Enter();
        business.rbManager.SetDrag();
    }

    public override State Tick()
    {
        business.rbManager.CheckForTurn();
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
                }
                    
                break;

            default:
                break;
        }
    }
}
