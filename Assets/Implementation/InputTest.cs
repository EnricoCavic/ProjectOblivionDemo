using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{

    private InputProcessor inputProcessor;

    private void Awake() 
    {   
        inputProcessor = GetComponent<InputProcessor>();
    }

 
}
