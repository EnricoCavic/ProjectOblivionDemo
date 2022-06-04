using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject virtualCam;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
            virtualCam.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
            virtualCam.SetActive(false);        
    }
}
