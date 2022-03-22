using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum CharStates { Running, Jumping, Airborne }

public class CharacterStateBusiness : StateMachineBusiness<CharacterState>
{
    public InputProcessor inputProcessor;
    public ProjectOblivionRBM rbManager;

    private void Awake() 
    {
        InitializeStates();    
    }

    private void OnEnable()
    {
        SubUnsubInputs(true);
        SubUnsubRbResponses(true);
    }

    private void Update() 
    {
        stateMachine.TickCurrentState();    
        //Debug.Log(stateMachine.currentState.enumId);
    }

    private void FixedUpdate() 
    {
        stateMachine.TickCurrentStateFixed();    
    }

    private void OnDisable() 
    {
        SubUnsubInputs(false);
        SubUnsubRbResponses(false);
    }

    public override void InitializeStates()
    {
        base.InitializeStates();

        AddState(CharStates.Running, new RunningCharacterState(this));
        AddState(CharStates.Jumping, new JumpingCharacterState(this));
        AddState(CharStates.Airborne, new AirborneCharacterState(this));
        
        stateMachine = new StateMachine<CharacterState>(GetState(CharStates.Running));
    }

   private void SubUnsubInputs(bool _isSubscribing)
    {
        InputAction mainInput = inputProcessor.GetAction("MainInput").action;

        if(_isSubscribing)
        {
            //mainInput.started += MainInput;
            //mainInput.canceled += MainInput;
            mainInput.started += BufferMainInput;
            mainInput.canceled += BufferMainInput;
            inputProcessor.buffer.onInputEnqueued += MainInput;
            return;
        }

        //mainInput.started -= MainInput;
        //mainInput.canceled -= MainInput;

    }

    private void SubUnsubRbResponses(bool _isSubscribing)
    {
        if(_isSubscribing)
        {
            GetState(CharStates.Running).onInputProcessed += ApplyInput;
            GetState(CharStates.Running).onEnter += rbManager.OnStateEnter;
            GetState(CharStates.Jumping).onEnter += rbManager.OnStateEnter; 
            GetState(CharStates.Airborne).onEnter += rbManager.OnStateEnter;   

            GetState(CharStates.Running).onEnter += OnRunningStateEnter;
            GetState(CharStates.Jumping).onEnter += OnJumpingStateEnter;         
            return;
        }    

        GetState(CharStates.Running).onEnter -= rbManager.OnStateEnter;
        GetState(CharStates.Running).onInputProcessed -= ApplyInput;       
        GetState(CharStates.Jumping).onEnter -= rbManager.OnStateEnter;    
        GetState(CharStates.Airborne).onEnter -= rbManager.OnStateEnter;    
    }

    public void BufferMainInput(InputAction.CallbackContext _context)
    {
        InputObject iOjb = new InputObject(inputProcessor.GetAction("MainInput"), _context.ReadValue<float>() > float.Epsilon);
        inputProcessor.buffer.EnqueueInput(iOjb);
    }

    public void MainInput(InputObject _inputObj)
    {
        StateInput stateInput = new StateInput();
        stateInput.id = "MainInput";
        stateInput.boolParam = _inputObj.isPressing;
        stateMachine.FeedInput(stateInput);
    }

    public void ApplyInput(Parameters _param)
    {
        switch(_param.id)  
        {
            case "Jump":
                inputProcessor.buffer.GetNextInputInBuffer("MainInput", true);
                rbManager.Jump(_param);
                break;

            default:
                break;
        }
    }

    public void OnRunningStateEnter(Parameters _param)
    {   
        if(inputProcessor.buffer.HasInputStored("MainInput", true))
        {
            Debug.Log("Possui input no buffer");
            stateMachine.FeedInput(GerenateParam("MainInput", true));
        }
            
    }

    public void OnJumpingStateEnter(Parameters _param)
    {   
        if(inputProcessor.buffer.HasInputStored("MainInput", false))
        {
            Debug.Log("Possui input no buffer");
            stateMachine.FeedInput(GerenateParam("MainInput", false));
        }
            
    }

    private Parameters GerenateParam(string _id, bool _boolParam)
    {
            Parameters param = new Parameters();
            param.id = _id;
            param.boolParam = _boolParam;     
            return param;
    }

}
