using UnityEngine;

public class BaseSMB : State
{
    public override void Enter()
    {
        return; 
    }
    
    public override State Tick()
    {
        return this; 
    }

    public override State FixedTick()
    {
        return this; 
    }

    public override void Exit()
    {
        return; 
    }  
}
