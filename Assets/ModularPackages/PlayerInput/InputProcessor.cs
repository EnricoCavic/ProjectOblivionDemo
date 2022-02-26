using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

[RequireComponent(typeof(PlayerInput))]
public class InputProcessor : MonoBehaviour
{
    private PlayerInput playerInput;

    public List<InputAction> inputActions;
    public InputAction changeLaneAction;
    /*public InputAction jumpAction;
    public InputAction dashAction;
    
    public InputAction timeScaleAction;*/

    //public InputBuffer buffer { get; private set; }

    public InputAction mousePosAction;
    public InputProcessor(PlayerInput _playerInput, MonoBehaviour _coroutineStarter, float _bufferTimeout)
    {
        playerInput = _playerInput;
        SetAllInputActions();
        DelegateInputs();
        //buffer = new InputBuffer(_coroutineStarter, _bufferTimeout);
    }

    private void SetAllInputActions()
    {
        /*changeLaneAction = playerInput.actions["ChangeLane"];
        jumpAction = playerInput.actions["Jump"];
        dashAction = playerInput.actions["Dash"];
        timeScaleAction = playerInput.actions["TimeScale"];
        mousePosAction = playerInput.actions["MousePosition"];*/
        
    }

    private void DelegateInputs()
    {
        /*jumpAction.started += JumpInput;
        jumpAction.canceled += EndJump;*/
    }

    public void UnsubscribeInputs()
    {
        /*jumpAction.started -= JumpInput;
        jumpAction.canceled -= EndJump;*/
        foreach (InputAction _inputAction in inputActions)
        {
            
        }
    }

    public Vector3 GetMouseWorldPosition(Camera _mainCam, float _targetZ)
    {
        Vector3 mousePosition = mousePosAction.ReadValue<Vector2>();
        mousePosition.z = _targetZ - _mainCam.transform.position.z;

        return _mainCam.ScreenToWorldPoint(mousePosition);
    }

    public void JumpInput(InputAction.CallbackContext _context)
    {        
        
    }

    public void EndJump(InputAction.CallbackContext _context)
    {        
        
    }
 

}
