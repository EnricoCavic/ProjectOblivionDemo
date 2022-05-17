using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProjectOblivionRBM : Rigidbody2DManager
{

    private void Awake() 
    {
        CacheComponents();
    }

    public bool HasWallOnFront()
    {
        float extraLen = 0.2f;
        Vector3 boxSize = capsuleCollider2D.bounds.size/1.5f;
        Vector3 boxCenter = capsuleCollider2D.bounds.center;
        Vector3 boxExtends = boxSize/2f;
        RaycastHit2D hit = Physics2D.BoxCast(boxCenter, boxSize, 0f, transform.right, extraLen, solidLayerMask);
        Color boxColor;
        if(hit.collider != null)
        {
            boxColor = Color.green;
        }
        else 
        {
            boxColor = Color.red;
        }
        Debug.DrawRay(boxCenter + transform.up * boxExtends.y, transform.right * (boxExtends.x + extraLen), boxColor);
        Debug.DrawRay(boxCenter - transform.up * boxExtends.y, transform.right * (boxExtends.x + extraLen), boxColor);
        Debug.DrawRay(boxCenter + (transform.right * (boxExtends.x + extraLen) + transform.up * -boxExtends.y ), transform.up * boxSize.y, boxColor);
        
        return hit.collider != null;
    }

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
