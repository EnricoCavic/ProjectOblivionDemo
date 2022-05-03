using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputProcessor : MonoBehaviour
{

    public MainInputAction inputAsset;
    
    [NonSerialized] public Vector2 mainInputBuffer;
    [NonSerialized] public bool mainInputHeld = false;

    public float bufferTime = 0.3f;

    private void Awake() 
    {
        inputAsset = new MainInputAction();    
        mainInputBuffer = new Vector2();
    }

    void OnEnable()
    {
        inputAsset.Enable();
    }

    private void Start() 
    {
        
    }

    public void MainInputStarted()
    {
        mainInputBuffer.x = bufferTime;
        mainInputHeld = true;
    }

    public void MainInputCanceled()
    {
        mainInputBuffer.y = bufferTime;
        mainInputHeld = false;
    }

    void Update() 
    {
        mainInputBuffer.x -= Time.deltaTime;
        mainInputBuffer.y -= Time.deltaTime;    
    }


    void OnDisable()
    {
        inputAsset.Disable();
    }

}
