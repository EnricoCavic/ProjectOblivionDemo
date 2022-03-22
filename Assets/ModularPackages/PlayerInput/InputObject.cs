using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputObject
{
    public InputResponse response;
    public string name;
    public float registeredTime;
    public bool wasProcessed;
    public bool isPressing;

    public InputObject(InputResponse _response, bool _isPressing)
    {
        response = _response;
        name = response.name;
        isPressing = _isPressing;
        registeredTime = Time.time;
        wasProcessed = false; 
    }

    public InputObject(string _name, bool _isPressing, bool _wasProcessed)
    {
        name = _name;
        isPressing = _isPressing;
        registeredTime = Time.time;
        wasProcessed = _wasProcessed; 
    }

    public bool CompareToObject(InputObject _objToCompare)
    {
        return _objToCompare.name == name &&
               _objToCompare.isPressing == isPressing && 
               _objToCompare.wasProcessed == wasProcessed;
    }
}
