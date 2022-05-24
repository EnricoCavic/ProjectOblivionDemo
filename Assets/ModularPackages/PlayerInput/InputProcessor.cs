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
        inputAsset.Gameplay.MainInput.started += MainInputStarted;
        inputAsset.Gameplay.MainInput.canceled += MainInputCanceled;
    }

    public void MainInputStarted(InputAction.CallbackContext _context)
    {
        mainInputBuffer.x = bufferTime;
        mainInputHeld = true;
    }

    public void MainInputCanceled(InputAction.CallbackContext _context)
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
        inputAsset.Gameplay.MainInput.started -= MainInputStarted;
        inputAsset.Gameplay.MainInput.canceled -= MainInputCanceled;
    }

}
