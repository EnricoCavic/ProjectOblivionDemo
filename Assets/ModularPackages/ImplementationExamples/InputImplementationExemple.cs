using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputImplementationExemple : MonoBehaviour
{
    InputProcessor inputProcessor;
    InputAction response;

    void Awake() => inputProcessor = GetComponent<InputProcessor>();
    
    void Start() => response = inputProcessor.GetAction("MainInput").action;


    void OnEnable()
    {
        response.started += InputStarted;
        response.canceled += InputCanceled;
    }

    public void InputStarted(InputAction.CallbackContext _context)
    {
        Debug.Log("Main input started");
    }

    public void InputCanceled(InputAction.CallbackContext _context)
    {
        Debug.Log("Main input released");
    }

    void OnDisable()
    {
        response.started -= InputStarted;
        response.canceled -= InputCanceled;
    }

}
