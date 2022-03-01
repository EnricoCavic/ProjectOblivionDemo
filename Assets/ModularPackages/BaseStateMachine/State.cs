using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class State
{
    public Action onInputProcessed;
    public Action onEnter;
    public Action onExit;
    public virtual void Enter() => onEnter?.Invoke(); 
    
    public virtual State Tick() { return this; }

    public virtual State FixedTick() { return this; }

    public virtual void Exit() => onExit?.Invoke();

    public virtual void ProcessInput(StateInput _input) { return; }
}


