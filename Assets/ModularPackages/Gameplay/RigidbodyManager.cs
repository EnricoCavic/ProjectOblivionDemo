using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCastManager))]
public class RigidbodyManager : MonoBehaviour, IRbManager
{
    public GameplayVariablesObject variables;
    protected Rigidbody rb;
    protected BoxCastManager castManager;
    protected Vector3 GRAVITY;

    public void CacheComponents()
    {
        rb = GetComponent<Rigidbody>();
        castManager = GetComponent<BoxCastManager>();
    }

    void Start()
    {
        GRAVITY = Physics.gravity;
    }

    public void UpdateGravity(Vector3 _newGravity)
    {
        GRAVITY = _newGravity;
    }


    public void Jump(float _jumpForce)
    {
        rb.velocity = new Vector3(rb.velocity.x, _jumpForce);      
    }

    public void Move(Vector3 _moveAxis, float _acceleration)
    {
        rb.AddForce(_moveAxis * _acceleration, ForceMode.Force);     
    }

    public void Move(float _acceleration)
    {
        rb.AddForce(transform.forward * _acceleration, ForceMode.Force);     
    }
    
    public void ApplyGravityMultiplier(float _gravityMultiplier)
    {
        Vector3 resultVector = GRAVITY * _gravityMultiplier - GRAVITY;
        rb.AddForce(resultVector, ForceMode.Acceleration);
    }
    
    public bool IsGrounded() => castManager.CheckCast("GroundCheck");

    public bool IsFalling() => rb.velocity.y < 0f;

    public bool IsMovingHorizontal() => Mathf.Abs(rb.velocity.x) > 0.1f;

    public bool IsMovingVertical() => Mathf.Abs(rb.velocity.y) > float.Epsilon;

    public void SetDrag() => rb.drag = variables.defaultDrag;
    public void SetDrag(float _newDrag) => rb.drag = _newDrag;

}