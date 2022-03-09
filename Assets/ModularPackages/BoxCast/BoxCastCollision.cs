using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BoxCastCollision
{
    public string id;
    public Transform origin;
    public Vector3 direction;
    public float distanceToOrigin;
    public Vector3 scaleModifier;
    public LayerMask collisionLayer;
    public bool toggleDraw;

    private const float OFFSET = 0.1f;
    private Vector3 positionMultiplicator => -origin.InverseTransformDirection(direction) * OFFSET;
    public Vector3 finalPosition => origin.position + positionMultiplicator;
    public Vector3 finalScale => Vector3.Scale(scaleModifier, origin.localScale);
    public Vector3 finalDirection => origin.TransformDirection(direction) * distanceToOrigin;


    public BoxCastCollision() {}

    public bool CheckOverlap()
    {
        bool boxCast = Physics.BoxCast(finalPosition, finalScale/2 , finalDirection, origin.rotation, distanceToOrigin, collisionLayer);

        return boxCast;
    }

    public void DrawCollision()
    {
        if(CheckOverlap())
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;

        Vector3 center = finalPosition + finalDirection;
        Vector3 maxPoint = center + Vector3.Scale(finalDirection, finalScale/2);
        Vector3 pointR = maxPoint + Vector3.Scale(Vector3.Cross(finalDirection, origin.up), finalScale/2);
        Vector3 rightUpV = pointR + Vector3.Scale(origin.up, finalScale/2);
        /*
        Vector3 point1 = finalPosition + finalDirection + finalScale/2;
        Vector3 point2 = finalPosition + finalDirection - finalScale/2;
        Vector3 point3 = point1 + origin.TransformVector(new Vector3(0,0,-1));
        Vector3 point4 = finalPosition + finalDirection;
        */

        Gizmos.DrawLine(origin.position, center);
        Gizmos.DrawLine(center, maxPoint);
        Gizmos.DrawLine(maxPoint, pointR);
        Gizmos.DrawLine(pointR, rightUpV);
        //Gizmos.DrawLine(origin.position, point3);
        //Gizmos.DrawLine(origin.position, point4);
        
        
        Gizmos.DrawWireCube(finalPosition + finalDirection, finalScale);

    }



}
