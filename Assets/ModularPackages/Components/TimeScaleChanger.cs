using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeScaleChanger : MonoBehaviour
{
    public InputAction timeScaleToggle;
    public float slowMotionMultiplier = 0.5f;

    private void OnEnable() 
    {
        timeScaleToggle.Enable();
        timeScaleToggle.started += ToggleTimeScale;
    }

    public void ToggleTimeScale(InputAction.CallbackContext _context)
    {
        if(Time.timeScale == 1f)
            Time.timeScale = slowMotionMultiplier;
        else
            Time.timeScale = 1f;
    }

    private void OnDisable() 
    {
        timeScaleToggle.Disable();
        timeScaleToggle.started -= ToggleTimeScale;
    }
}
