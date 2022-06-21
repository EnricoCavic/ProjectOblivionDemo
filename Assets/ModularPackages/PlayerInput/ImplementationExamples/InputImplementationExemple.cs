using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputImplementationExemple : MonoBehaviour
{
    private InputProcessor inputProcessor;
    private InputBuffer buffer;

    private void Awake() => inputProcessor = GetComponent<InputProcessor>();
    
    private void OnEnable() 
    {
        
    }

    private void TryInput(InputObject _obj)
    {
        
    }


}
