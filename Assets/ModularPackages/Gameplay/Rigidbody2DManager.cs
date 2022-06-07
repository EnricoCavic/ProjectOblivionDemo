using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rigidbody2DManager : MonoBehaviour, IRbManager
{
    public GameplayVariablesObject variables;
    protected Rigidbody2D rb;
    protected CapsuleCollider2D capsuleCollider2D;
    protected BoxCast2DManager cast2DManager;
    protected Vector3 GRAVITY;


    public void CacheComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        cast2DManager = GetComponent<BoxCast2DManager>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
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
        rb.velocity = new Vector2(rb.velocity.x, _jumpForce);      
    }

    public void HorizontalVelocity(float _impulseForce, float direction)
    {
        rb.velocity = new Vector2(_impulseForce * direction, rb.velocity.y);
    }
    

    public void Move(Vector3 _moveAxis, float _acceleration)
    {
        rb.AddForce(_moveAxis * _acceleration, ForceMode2D.Force);     
    }

    public void Move(float _acceleration)
    {
        rb.AddForce(transform.right * _acceleration, ForceMode2D.Force);     
    }
    
    public void ApplyGravityMultiplier(float _gravityMultiplier)
    {
        Vector3 resultVector = GRAVITY * _gravityMultiplier - GRAVITY;
        rb.AddForce(resultVector, ForceMode2D.Force);
    }
    
    public bool IsGrounded() => cast2DManager.CheckCast("GroundCheck");

    public bool IsFalling() => rb.velocity.y < 0f;

    public bool IsMovingHorizontal() => Mathf.Abs(rb.velocity.x) > 0.1f;

    public bool IsMovingVertical() => Mathf.Abs(rb.velocity.y) > 0.05f;

    public void SetDrag() => rb.drag = variables.defaultDrag;
    public void SetDrag(float _newDrag) => rb.drag = _newDrag;

}