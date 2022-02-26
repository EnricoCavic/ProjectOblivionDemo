using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager 
{
    public GameplayVariablesObject variables;
    public Rigidbody rb;
    public Transform myTransform;
    private BoxCastManager castManager;
    private Vector3 GRAVITY;


    public GameplayManager(Transform _transform, Rigidbody _rb, BoxCastManager _bm, GameplayVariablesObject _variables)
    {
        myTransform = _transform;
        rb = _rb;
        castManager = _bm;
        variables = _variables;
        GRAVITY = Physics.gravity;
    }


    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, variables.jumpForce, rb.velocity.z);        
    }

    public void Move(float _moveAxis)
    {
        rb.AddForce(_moveAxis * variables.movementSpeed, 0, 0, ForceMode.Force);     
    }
    
    public void ApplyGravityMultiplier(float _gravityMultiplier)
    {
        Vector3 resultVector = GRAVITY * _gravityMultiplier - GRAVITY;
        rb.AddForce(resultVector, ForceMode.Acceleration);
    }
    
    public bool IsGrounded() => castManager.CheckCast("GroundCheck");

    public bool CanMoveForward() => !castManager.CheckCast("RightWallCheck");

    public bool IsFalling() => rb.velocity.y < 0.5f;

    public bool IsMoving() => Mathf.Abs(rb.velocity.x) > 0.1f;

    public void SetDragToDefault() => rb.drag = variables.defaultDrag;


}