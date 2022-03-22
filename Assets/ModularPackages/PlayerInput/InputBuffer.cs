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
            Debug.Log("Input dequeued: "+ _obj.name + " / " + _obj.isPressing + " / " + _obj.wasProcessed);
        }
        
    }

    public InputObject GetNextInputInBuffer(string _responseName, bool _isPressing)
    {
        if(inputQueue.Count <= 0)
            return null;
        
        InputObject targetObj = new InputObject(_responseName, _isPressing, false);
        if(targetObj.CompareToObject(inputQueue.Peek()))
        {                        
            Debug.Log("Input used: "+ targetObj.name + " / " + targetObj.isPressing);
            return inputQueue.Dequeue();
        }
            
        return null;
    }

    public bool HasInputStored(string _responseName, bool _isPressing)
    {
        if(inputQueue.Count <= 0)
            return false;

        InputObject targetObj = new InputObject(_responseName, _isPressing, false);

        return targetObj.CompareToObject(inputQueue.Peek()); 
    }

}
