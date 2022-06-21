using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowState : MonoBehaviour
{
    public CharacterStateBusiness business;
    Text text;
    private void Awake() 
    {
        text = GetComponent<Text>();    
    }
    void Update()
    {
        //text.text = business.stateMachine.currentState.enumId.ToString();
    }
}
