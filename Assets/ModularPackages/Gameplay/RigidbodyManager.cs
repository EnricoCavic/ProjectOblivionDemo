using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCastManager))]
public class RigidbodyManager : MonoBehaviour
{
    public GameplayVariablesObject variables;
    private Rigidbody rb;
    private BoxCastManager castManager;
    private Vector3 GRAVITY;


    void Start()
    {
        GRAVITY = Physics.gravity;
    }

    public void UpdateGravity(Vector3 _newGravity)
    {
        GRAVITY = _newGravity;
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, variables.jumpForce, rb.velocity.z);        
    }

    public void Move(float _moveAxis)
    {
        rb.AddForce(_moveAxis * variables.acceleration, 0, 0, ForceMode.Force);     
    }
    
    public void ApplyGravityMultiplier(float _gravityMultiplier)
    {
        Vector3 resultVector = GRAVITY * _gravityMultiplier - GRAVITY;
        rb.AddForce(resultVector, ForceMode.Acceleration);
    }
    
    public bool IsGrounded() => castManager.CheckCast("GroundCheck");

    public bool CanMoveForward() => !castManager.CheckCast("RightWallCheck");

    public bool IsFalling() => rb.velocity.y < 0f;

    public bool IsMovingHorizontal() => Mathf.Abs(rb.velocity.x) > 0.1f;

    public bool IsMovingVertical() => Mathf.Abs(rb.velocity.y) > float.Epsilon;

    public void SetDrag() => rb.drag = variables.defaultDrag;
    public void SetDrag(float _newDrag) => rb.drag = _newDrag;


}