using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

[Serializable]
public class InputBuffer
{
    public List<InputObject> inputQueue = new List<InputObject>();
    public float inputTimeout;
    public Action<InputObject> onInputEnqueued;

    public void AddInput(InputObject _obj)
    {
        inputQueue.Insert(0, _obj);
        onInputEnqueued?.Invoke(_obj);
        Debug.Log("Input added: "+ _obj.response.name + " / " + _obj.isPressing);
    }

    public void TickBuffer()
    {
        if(inputQueue.Count <= 0)
            return;
        
        InputObject _obj = inputQueue[LastPosition()];
        if(Time.time - _obj.registeredTime > inputTimeout)
        {
            inputQueue.Remove(_obj);
            Debug.Log("Input dequeued: "+ _obj.response.name + " / " + _obj.isPressing + " / " + _obj.wasProcessed);
        }
        
    }

    public InputObject GetNextInputInBuffer(string _responseName, bool _isPressing)
    {
        if(inputQueue.Count <= 0)
            return null;
    
        for(int i = LastPosition(); i >= 0; i-- )
        {
            InputObject _inputObj = !inputQueue[i].wasProcessed ? inputQueue[i] : null;
            if(_inputObj != null)
            {
                if(_inputObj.response.name == _responseName && _isPressing == _inputObj.isPressing)
                {
                    Debug.Log("Input processed: "+ _inputObj.response.name + " / " + _inputObj.isPressing);
                    _inputObj.wasProcessed = true;
                    return _inputObj;
                }
            }
        }   

        return null;
    }

    public bool HasInputStored(string _responseName, bool _isPressing)
    {
        if(inputQueue.Count <= 0)
            return false;
    
        for(int i = LastPosition(); i >= 0; i-- )
        {
            InputObject _inputObj = !inputQueue[i].wasProcessed ? inputQueue[i] : null;
            if(_inputObj != null)
            {
                if(_inputObj.response.name == _responseName && _isPressing == _inputObj.isPressing)
                {
                    return true;
                }
            }
        }   

        return false;           

    }

    private int LastPosition() => inputQueue.Count - 1;

}
