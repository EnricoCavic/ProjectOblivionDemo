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

    }

    public override State FixedTick()
    {
        //business.rbManager.Move();
        return this;
    }

}
