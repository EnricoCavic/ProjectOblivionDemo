using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Gameplay Variables", menuName = "ScriptableObjects/Gameplay Variables")]
public class GameplayVariablesObject : ScriptableObject
{
    [Header("Movement")]
    public float jumpForce = 15f;
    public float movementSpeed = 40f;
    public float defaultDrag = 6f;
    public float coyoteTime = 0.2f;


    [Header("Airborne")]
    public float airDrag = 4f;
    public float airbourneGravityMultiplier = 8f;
    public float jumpingGravityMultiplier = 0.5f;


}
