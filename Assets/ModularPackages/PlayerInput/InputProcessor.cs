using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputProcessor : MonoBehaviour
{
    public List<InputResponse> inputActions;
    private List<InputObject> inputObjects = new List<InputObject>();

    public InputBuffer buffer;

    void OnEnable()
    {
        foreach (InputResponse _response in inputActions)
            _response.action.Enable();
    }

    private void Start() 
    {
        foreach (InputResponse _response in inputActions)
        {
            inputObjects.Add(new InputObject(_response));
            _response.action.started += RegisterToBuffer;
            _response.action.canceled += RegisterToBuffer;
        }
    }

    void FixedUpdate() 
    {
        buffer?.TickBuffer();    
    }

    private void RegisterToBuffer(InputAction.CallbackContext _context)
    {
        InputObject obj = GetObject(_context.action);
        obj.registeredTime = Time.time;
        obj.isPressing = _context.ReadValue<float>() > float.Epsilon;
        buffer.EnqueueInput(obj);

    }

    public InputResponse GetAction(string _name)
    {
        foreach (InputResponse _response in inputActions)
            if(_response.name == _name)
                return _response;

        return null;
    }
    
    public InputResponse GetAction(InputAction _action)
    {
        foreach (InputResponse _response in inputActions)
            if(_response.action == _action)
                return _response;

        return null;
    }

    public InputObject GetObject(InputAction _action)
    {
        foreach (InputObject _obj in inputObjects)
            if(_obj.response.action == _action)
                return new InputObject(_obj);

        return null;
    }

    void OnDisable()
    {
        foreach (InputResponse _response in inputActions)
            _response.action.Disable();
    }

}
