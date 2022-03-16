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

    public override void Enter() => OnStateChange(true);
    public override void Exit() => OnStateChange(false);


    private void OnStateChange(bool _isEntering)
    {
        //refactor to send state type as parameter
        Parameters param = new Parameters();
        param.id = _isEntering ? "OnStateEnter" : "OnStateExit";
        param.enumParam = enumId;

        if(_isEntering)
            onEnter?.Invoke(param);
        else
            onExit?.Invoke(param);
    }
}