using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingMono : MonoBehaviour
{
    InputProcessor inputProcessor;
    InputAction response;

    void Awake()
    {
        inputProcessor = GetComponent<InputProcessor>();
    }

    void Start()
    {
        response = inputProcessor.GetAction("Main").relatedAction;

        response.started += InputStarted;
        response.canceled += InputReleased;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputStarted(InputAction.CallbackContext _context)
    {
        Debug.Log("Inicio do input registrado");
    }

    public void InputReleased(InputAction.CallbackContext _context)
    {
        Debug.Log("fim do input registrado");
    }
}
