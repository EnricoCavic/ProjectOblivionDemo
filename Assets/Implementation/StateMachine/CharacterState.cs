using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : State
{
    protected CharacterStateBusiness business;
    public CharStates enumId { get; protected set; }
    public virtual void Init(CharacterStateBusiness _business)
    {
        business = _business;
    }

    public virtual void MainInputStarted() { return; }
    public virtual void MainInputCanceled() { return; }

}