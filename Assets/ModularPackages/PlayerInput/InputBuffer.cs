using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

[Serializable]
public class InputBuffer
{
    public Queue<InputObject> inputQueue = new Queue<InputObject>();
    public float inputTimeout;
    public Action<InputObject> onInputEnqueued;

    public void EnqueueInput(InputObject _obj)
    {
        inputQueue.Enqueue(_obj);
        onInputEnqueued?.Invoke(_obj);
        Debug.Log("Input enqueued: "+ _obj.response.name + " / " + _obj.isPressing);
    }

    public void TickBuffer()
    {
        if(inputQueue.Count <= 0)
            return;

        if(Time.time - inputQueue.Peek().registeredTime > inputTimeout)
        {
            InputObject _obj = inputQueue.Dequeue();     
            Debug.Log("Input dequeued: "+ _obj.response.name + " / " + _obj.isPressing + " / " + _obj.wasProcessed);
        }
        
    }

    public InputObject GetNextInputInBuffer(string _responseName, bool _isPressing)
    {
        if(inputQueue.Count <= 0)
            return null;

        foreach(InputObject _input in inputQueue)
        {
            InputObject _inputObj = _input.wasProcessed ? null : _input;
            if(_inputObj != null)
            {
                if(_inputObj.response.name == _responseName && _isPressing == _inputObj.isPressing)
                {
                    _inputObj.wasProcessed = true;
                    Debug.Log("Input used: "+ _inputObj.response.name + " / " + _inputObj.isPressing);
                    return _inputObj;
                }
            }   
        }

        return null;
    }

    public bool HasInputStored(string _responseName, bool _isPressing)
    {
        if(inputQueue.Count < 1)
            return false;

        foreach(InputObject _input in inputQueue)
        {
            InputObject _inputObj = _input.wasProcessed ? null : _input;
            if(_inputObj != null)                               
                return _inputObj.response.name == _responseName && _isPressing == _inputObj.isPressing; 
        }

        return false;    
    }

}
