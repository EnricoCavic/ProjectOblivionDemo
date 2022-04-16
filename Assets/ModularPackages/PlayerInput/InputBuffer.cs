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

    public void EnqueueInput(InputObject _obj)
    {
        inputQueue.Add(_obj);
        Debug.Log("Input enqueued: "+ _obj.response.name + " / " + _obj.isPressing);
        onInputEnqueued?.Invoke(_obj);

    }

    public void TickBuffer()
    {
        if(inputQueue.Count <= 0)
            return;

        if(Time.time - PeekInput().registeredTime > inputTimeout)
        {
            InputObject _obj = DequeueInput();   
            string processedOut = _obj.wasProcessed ? "Processado" : "Não processado";  
            Debug.Log("Input dequeued: "+ _obj.name + " / " + _obj.isPressing + " / " + processedOut + " / " + _obj.registeredTime);
        }
        
    }

    public InputObject GetNextInputInBuffer(string _responseName, bool _isPressing)
    {
        if(inputQueue.Count <= 0)
            return null;
        
        InputObject targetObj = new InputObject(_responseName, _isPressing, false);
        InputObject foundObj = GetNextByComparison(targetObj);
        if(foundObj != null)
        {

            Debug.Log("Input used: "+ targetObj.name + " / " + targetObj.isPressing);
            foundObj.wasProcessed = true;
            return foundObj;
        }
            
        return null;
    }

    public bool HasInputStored(string _responseName, bool _isPressing)
    {
        if(inputQueue.Count <= 0)
            return false;

        InputObject targetObj = new InputObject(_responseName, _isPressing, false);
        if(targetObj.CompareToObject(PeekInput()))
            return true;

        return false; 
    }

    public InputObject PeekInput() => inputQueue[0];
    public InputObject DequeueInput()
    {
        InputObject returnValue = inputQueue[0];
        inputQueue.RemoveAt(0);
        return returnValue;
    }

    private InputObject GetNextByComparison(InputObject _objToCompare)
    {
        for(int i = 0; i < inputQueue.Count; i++ )
        {
            if(_objToCompare.CompareToObject(inputQueue[i]))
            {
                return inputQueue[i];
            }
        }
        return null;
    }


}
