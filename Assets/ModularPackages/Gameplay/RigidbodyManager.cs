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

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        castManager = GetComponent<BoxCastManager>();    
    }

    void Start()
    {
        GRAVITY = Physics.gravity;
    }

    public virtual void UpdateGravity(Vector3 _newGravity)
    {
        GRAVITY = _newGravity;
    }

    public virtual void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, variables.jumpForce, rb.velocity.z);        
    }

    public virtual void Move(Vector3 _moveAxis)
    {
        rb.AddForce(_moveAxis * variables.acceleration, ForceMode.Force);     
    }

    public virtual void Move()
    {
        rb.AddForce(transform.forward * variables.acceleration, ForceMode.Force);     
    }
    
    public virtual void ApplyGravityMultiplier(float _gravityMultiplier)
    {
        Vector3 resultVector = GRAVITY * _gravityMultiplier - GRAVITY;
        rb.AddForce(resultVector, ForceMode.Acceleration);
    }
    
    public virtual bool IsGrounded() => castManager.CheckCast("GroundCheck");

    public virtual bool IsFalling() => rb.velocity.y < 0f;

    public virtual bool IsMovingHorizontal() => Mathf.Abs(rb.velocity.x) > 0.1f;

    public virtual bool IsMovingVertical() => Mathf.Abs(rb.velocity.y) > float.Epsilon;

    public virtual void SetDrag() => rb.drag = variables.defaultDrag;
    public virtual void SetDrag(float _newDrag) => rb.drag = _newDrag;


}