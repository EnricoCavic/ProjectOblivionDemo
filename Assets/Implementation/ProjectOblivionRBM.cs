using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProjectOblivionRBM : Rigidbody2DManager
{

    public bool HasWallOnFront() => true;

    public void TurnArround() => transform.rotation = Quaternion.LookRotation(transform.forward * -1f);

    public void CheckForTurn()
    {
        if(HasWallOnFront())
            TurnArround();

    }

    public void ApplyGravityMultiplier(JumpingCharacterState s) => ApplyGravityMultiplier(variables.jumpingGravityMultiplier);
    public void ApplyGravityMultiplier(AirborneCharacterState s) => ApplyGravityMultiplier(variables.airbourneGravityMultiplier);

    public void OnStateEnter(RunningCharacterState s)
    {
        rb.drag = variables.defaultDrag;
    }

    public void OnStateEnter(JumpingCharacterState s)
    {
        rb.drag = variables.airDrag;
    }
}
