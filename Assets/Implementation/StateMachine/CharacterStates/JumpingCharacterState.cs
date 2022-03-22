using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingCharacterState : CharacterState
{
    public JumpingCharacterState(CharacterStateBusiness _business)
    {
        enumId = CharStates.Jumping; 
        Init(_business);
    }

    public override State Tick()
    {
        business.rbManager.CheckForTurn();
        if(business.rbManager.IsFalling())
        {
            if(business.rbManager.IsGrounded())
                return business.GetState(CharStates.Running);
            else
                return business.GetState(CharStates.Airborne); 
        }
            

        return this;
    }

    public override State FixedTick()
    {
        business.rbManager.Move();
        business.rbManager.ApplyGravityMultiplier(this);
        return this;
    }

    public override void ProcessInput(Parameters _input)
    {
        switch(_input.id)
        {
            case "MainInput":
                if(!_input.boolParam)
                {    
                    Parameters param = new Parameters();
                    param.id = "JumpReleased";
                    onInputProcessed?.Invoke(param);
                    business.stateMachine.NewState(business.GetState(CharStates.Airborne));
                }
                break;

            default:
                break;
        }
    }
}
