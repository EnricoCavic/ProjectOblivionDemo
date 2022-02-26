using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual void Enter() { return; }

    public virtual State Tick() { return this; }

    public virtual State FixedTick() { return this; }

    public virtual void Exit() { return; }

}


