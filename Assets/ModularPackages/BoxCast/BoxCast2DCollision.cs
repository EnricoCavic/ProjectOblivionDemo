using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoxCast2DCollision
{
    public string id;
    public Collider2D origin;
    public Vector2 sizeScaler = new Vector2(1f, 1f);
    public float angle = 0f;
    public Vector2 direction;
    public float distance;
    public LayerMask hitMask;
    public bool toggleDraw;

    Vector2 boxOrigin => origin.bounds.center;
    Vector2 boxSize => Vector3.Scale(origin.bounds.size, sizeScaler);
    Vector2 boxExtends => boxSize/2;

    Vector2 finalDirection => direction * distance;
    Vector2 finalOrigin => boxOrigin + finalDirection;

    public RaycastHit2D CheckOverlap()
    {
        return Physics2D.BoxCast(boxOrigin, boxSize, angle, direction, distance, hitMask);
    }

    public void DrawCollision()
    {
        if(CheckOverlap().collider != null)
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;

        Gizmos.DrawWireCube(finalOrigin, boxSize);

        Gizmos.DrawLine(boxOrigin + Vector2.Scale(boxExtends, -direction),
                        finalOrigin + Vector2.Scale(boxExtends, direction));

    }
}
