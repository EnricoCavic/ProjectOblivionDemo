using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirborneCharacterState : CharacterState
{
    public AirborneCharacterState(CharacterStateBusiness _business)
    {
        enumId = CharStates.Airborne; 
        Init(_business);
    }

    public override State Tick()
    {
        business.rbManager.CheckForTurn();
        if(business.rbManager.IsGrounded() && !business.rbManager.IsMovingVertical())
            return business.GetState(CharStates.Running);

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
                break;

            default:
                break;
        }
    }
}
