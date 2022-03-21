using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputProcessor : MonoBehaviour
{
    public List<InputResponse> inputActions;

    public InputBuffer buffer;

    void OnEnable()
    {
        foreach (InputResponse _response in inputActions)
            _response.action.Enable();
    }

    void FixedUpdate() 
    {
        buffer?.TickBuffer();    
    }

    public InputResponse GetAction(string _name)
    {
        foreach (InputResponse _response in inputActions)
            if(_response.name == _name)
                return _response;

        return null;
    }

    void OnDisable()
    {
        foreach (InputResponse _response in inputActions)
            _response.action.Disable();
    }

}
