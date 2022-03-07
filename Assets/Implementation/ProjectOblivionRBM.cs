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

}
