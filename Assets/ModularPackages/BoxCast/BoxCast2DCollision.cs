using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
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

    [NonSerialized] public Vector2 hitOrigin;
    [NonSerialized] public Vector2 hitNormal;
    [NonSerialized] public Vector2 normalPerpendicular;

    Vector2 boxOrigin => origin.bounds.center;
    Vector2 boxSize => Vector3.Scale(origin.bounds.size, sizeScaler);
    Vector2 boxExtends => boxSize/2;

    Vector2 finalDirection => direction * distance;
    Vector2 finalOrigin => boxOrigin + finalDirection;

    public RaycastHit2D CheckOverlap()
    {
        RaycastHit2D hit = Physics2D.BoxCast(finalOrigin, boxSize, angle, direction, 0f, hitMask);
        if(hit)
        {
            hitOrigin = hit.point;
            hitNormal.Set(hit.normal.x, Mathf.Abs(hit.normal.y));
            
            normalPerpendicular = Vector3.Cross(Vector3.back, hitNormal);            
        }

        return hit;
    }

    public void DrawCollision()
    {
        if(CheckOverlap().collider != null)
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;

        Gizmos.DrawWireCube(finalOrigin, boxSize);

        //Gizmos.color = Color.magenta;
        //Gizmos.DrawLine(hitOrigin, hitNormal);
        // Gizmos.DrawLine(hitOrigin, normalPerpendicular);
        //Debug.DrawRay(boxOrigin + origin.bounds.extents * direction, hitNormal, Color.magenta);
        Debug.DrawRay(boxOrigin + origin.bounds.extents * direction, normalPerpendicular, Color.cyan);

    }
}
