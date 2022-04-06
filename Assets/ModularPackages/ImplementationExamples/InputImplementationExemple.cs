using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputImplementationExemple : MonoBehaviour
{
    InputProcessor inputProcessor;
    InputAction actionToSubscribe;

    void Awake() => inputProcessor = GetComponent<InputProcessor>();
    
    void Start() => actionToSubscribe = inputProcessor.GetAction("MainInput").action;


    void OnEnable()
    {
        actionToSubscribe.started += InputStarted;
        actionToSubscribe.canceled += InputCanceled;
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
        actionToSubscribe.started -= InputStarted;
        actionToSubscribe.canceled -= InputCanceled;
    }

}
