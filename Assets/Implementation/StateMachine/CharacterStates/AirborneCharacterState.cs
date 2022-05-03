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

}
