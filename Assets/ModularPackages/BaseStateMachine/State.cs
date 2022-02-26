using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class State
{
    public Action inputResponse;
    public virtual void Enter() { return; }

    public virtual State Tick() { return this; }

    public virtual State FixedTick() { return this; }

    public virtual void Exit() { return; }

    public virtual void ProcessInput(StateInput _input) { return; }
}


