using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectOblivionRBM : RigidbodyManager
{

    public bool HasWallOnFront() => castManager.CheckCast("FrontCheck");

    public void TurnArround() => transform.rotation = Quaternion.LookRotation(transform.forward * -1f);

    public void CheckForTurn()
    {
        if(HasWallOnFront())
            TurnArround();
    }

    public void SetDrag(Parameters _param)
    {
        
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
