using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputProcessor : MonoBehaviour
{

    public MainInputAction inputAsset;
    
    private Vector2 mainInputBuffer;
    [NonSerialized] public bool mainInputHeld = false;

    public float bufferTime = 0.3f;

    public bool IsMainInputBuffered(bool checkForPressed)
    {
        float value = checkForPressed ? mainInputBuffer.x : mainInputBuffer.y;
        return value > 0f;
    }


    private void Awake() 
    {
        inputAsset = new MainInputAction();    
        mainInputBuffer = new Vector2();
    }

    void OnEnable()
    {
        inputAsset.Enable();
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

    public void ResetBuffer(bool checkForPressed)
    {
        if(checkForPressed)
            mainInputBuffer.x = 0f;
        else
            mainInputBuffer.y = 0f;
        
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
