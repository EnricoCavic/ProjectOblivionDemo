using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRbManager
{    
    void CacheComponents();
    void Move(float _acceleration);
    void Jump(float _jumpForce);
    void ApplyGravityMultiplier(float _gravityMultiplier);

    void UpdateGravity(Vector3 _newGravity);
    void SetDrag();

    bool IsGrounded();
    bool IsFalling();
    bool IsMovingHorizontal();
    bool IsMovingVertical();


}
