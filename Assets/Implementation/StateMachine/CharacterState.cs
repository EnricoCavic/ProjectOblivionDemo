using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : State
{
    protected CharacterStateBusiness business;
    public void Init()
    {
        business = GetComponent<CharacterStateBusiness>();
    }

    public virtual void MainInputStarted() { return; }
    public virtual void MainInputCanceled() { return; }
}