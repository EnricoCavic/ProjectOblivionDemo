using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : State
{
    protected CharacterStateBusiness business;
    public virtual void Init(CharacterStateBusiness _business)
    {
        business = _business;
    }
}