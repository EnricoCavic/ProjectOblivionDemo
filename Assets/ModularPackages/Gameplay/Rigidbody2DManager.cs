using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rigidbody2DManager : MonoBehaviour, IRbManager
{
    public GameplayVariablesObject variables;
    public LayerMask solidLayerMask;
    protected Rigidbody2D rb;
    protected CapsuleCollider2D capsuleCollider2D;
    protected Vector3 GRAVITY;


    public void CacheComponents()
    {
        rb = GetComponent<Rigidbody2D>();
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
        rb.velocity = new Vector3(rb.velocity.x, _jumpForce);      
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
    
    public bool IsGrounded()
    {
        float extraHeight = .5f;
        Vector3 boxSize = capsuleCollider2D.bounds.size/1.5f;
        RaycastHit2D hit = Physics2D.BoxCast(capsuleCollider2D.bounds.center, boxSize, 0f, -transform.up, extraHeight, solidLayerMask);
        return hit.collider != null;
    }

    public bool IsFalling() => rb.velocity.y < 0f;

    public bool IsMovingHorizontal() => Mathf.Abs(rb.velocity.x) > 0.1f;

    public bool IsMovingVertical() => Mathf.Abs(rb.velocity.y) > float.Epsilon;

    public void SetDrag() => rb.drag = variables.defaultDrag;
    public void SetDrag(float _newDrag) => rb.drag = _newDrag;

}