// GENERATED AUTOMATICALLY FROM 'Assets/Implementation/MainInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainInputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainInputAction"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""f72ed18b-d9d5-425f-8ce8-49dad07487a9"",
            ""actions"": [
                {
                    ""name"": ""MainInput"",
                    ""type"": ""Button"",
                    ""id"": ""db2e4803-958b-48ae-bad1-7e034fa22536"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ee965e27-809a-4d11-9c11-387e55116ec5"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MainInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""933fcdd7-0145-4de6-8cff-e5f1c66ed8e6"",
                    ""path"": ""*/{PrimaryAction}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MainInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd1a46e2-fe32-4444-9510-a8b1c5b29c37"",
                    ""path"": ""*/{SecondaryAction}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MainInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_MainInput = m_Gameplay.FindAction("MainInput", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_MainInput;
    public struct GameplayActions
    {
        private @MainInputAction m_Wrapper;
        public GameplayActions(@MainInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @MainInput => m_Wrapper.m_Gameplay_MainInput;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @MainInput.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMainInput;
                @MainInput.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMainInput;
                @MainInput.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMainInput;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MainInput.started += instance.OnMainInput;
                @MainInput.performed += instance.OnMainInput;
                @MainInput.canceled += instance.OnMainInput;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMainInput(InputAction.CallbackContext context);
    }
}
