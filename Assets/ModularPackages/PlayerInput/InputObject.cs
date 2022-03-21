using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputObject
{
    public InputResponse response;
    public float registeredTime;
    public bool isPressing;
    public bool wasProcessed;

    public InputObject(InputResponse _response, bool _isPressing)
    {
        response = _response;
        isPressing = _isPressing;
        registeredTime = Time.time; 
        wasProcessed = false;
    }
}
