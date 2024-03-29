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
    private Vector3 scaledDistance => distanceToOrigin * origin.localScale;
    private float finalDistance => distanceToOrigin * Vector3.Scale(direction, origin.localScale).magnitude; 

    private Vector3 localDirection => direction * finalDistance;
    private Vector3 localFinalPosition => localDirection +(-localDirection * OFFSET);

    public Vector3 finalScale => Vector3.Scale(scaleModifier, origin.localScale);
    public Vector3 finalDirection => Vector3.Scale(origin.TransformDirection(direction), scaledDistance);
    private Vector3 positionMultiplicator => -finalDirection * OFFSET;
    public Vector3 finalPosition => origin.position + positionMultiplicator;

    public bool CheckOverlap()
    {
        bool boxCast = Physics.BoxCast(finalPosition, finalScale/2 , finalDirection, origin.rotation, finalDistance, collisionLayer);

        return boxCast;
    }

    public void DrawCollision()
    {
        if(CheckOverlap())
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;
        

        Gizmos.matrix = Matrix4x4.TRS(origin.position, origin.rotation, Gizmos.matrix.lossyScale); 

        Gizmos.DrawWireCube(localFinalPosition, finalScale);

    }



}
