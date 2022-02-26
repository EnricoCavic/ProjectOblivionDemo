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
    
    private const float OFFSET = 0.05f;
    private Vector3 positionMultiplicator => -direction * OFFSET;
    public Vector3 finalPosition => origin.position + positionMultiplicator;
    public Vector3 finalScale => origin.localScale + scaleModifier;
    public Vector3 finalDirection => direction * distanceToOrigin;


    public BoxCastCollision() {}

    public bool CheckOverlap()
    {
        bool boxCast = Physics.BoxCast(finalPosition, finalScale/2 , direction, origin.rotation, distanceToOrigin, collisionLayer);

        return boxCast;
    }

    public void DrawCollision()
    {
        if(CheckOverlap())
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;

        Gizmos.DrawWireCube(finalPosition + finalDirection, finalScale);

    }



}
