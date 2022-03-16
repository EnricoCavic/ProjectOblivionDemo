using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProjectOblivionRBM : RigidbodyManager
{

    public bool HasWallOnFront() => castManager.CheckCast("FrontCheck");

    public void TurnArround() => transform.rotation = Quaternion.LookRotation(transform.forward * -1f);

    public void CheckForTurn()
    {
        if(HasWallOnFront())
            TurnArround();

    }

    public void ApplyGravityMultiplier(JumpingCharacterState s) => ApplyGravityMultiplier(variables.jumpingGravityMultiplier);
    public void ApplyGravityMultiplier(AirborneCharacterState s) => ApplyGravityMultiplier(variables.airbourneGravityMultiplier);

    public void OnStateEnter(Parameters _param)
    {

        switch (_param.enumParam)
        {
            case CharStates.Running:
                rb.drag = variables.defaultDrag;
                break;

            case CharStates.Jumping:
                rb.drag = variables.airDrag;
                break;

            default:
                break;
        }
    }

    public void ApplyInput(Parameters _param)
    {
        switch(_param.id)  
        {
            case "Jump":
                Jump(_param);
                break;

            default:
                break;
        }
    }



}
