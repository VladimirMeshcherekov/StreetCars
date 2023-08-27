//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Player/Input/Player.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""241f54be-0163-4f3f-bc22-93e3f048e8ec"",
            ""actions"": [
                {
                    ""name"": ""PlayerMoveDirection"",
                    ""type"": ""Value"",
                    ""id"": ""84329184-5e2c-4e99-9d79-88eb7103d71f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PlayerGas"",
                    ""type"": ""Button"",
                    ""id"": ""1991c11f-73a1-4da0-b80d-9824bb8b968d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""87c8eaa8-662c-4e69-bc65-ab41c576edfc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMoveDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""398eb9c1-37db-488b-a672-131b8d85e5a8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Standalone"",
                    ""action"": ""PlayerMoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7953d59f-ecc7-444c-b92a-7ef15b57f441"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Standalone"",
                    ""action"": ""PlayerMoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c5fd1c69-bdba-4140-a9f0-d307558e9996"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Standalone"",
                    ""action"": ""PlayerMoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""75b756e7-44a2-4dbc-9648-cf5ef1a929fa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Standalone"",
                    ""action"": ""PlayerMoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0f227ee0-a699-4b3e-bdb4-8fad6492f497"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Standalone"",
                    ""action"": ""PlayerGas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Standalone"",
            ""bindingGroup"": ""Standalone"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_PlayerMoveDirection = m_Player.FindAction("PlayerMoveDirection", throwIfNotFound: true);
        m_Player_PlayerGas = m_Player.FindAction("PlayerGas", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_PlayerMoveDirection;
    private readonly InputAction m_Player_PlayerGas;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerMoveDirection => m_Wrapper.m_Player_PlayerMoveDirection;
        public InputAction @PlayerGas => m_Wrapper.m_Player_PlayerGas;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @PlayerMoveDirection.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerMoveDirection;
                @PlayerMoveDirection.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerMoveDirection;
                @PlayerMoveDirection.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerMoveDirection;
                @PlayerGas.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerGas;
                @PlayerGas.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerGas;
                @PlayerGas.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerGas;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlayerMoveDirection.started += instance.OnPlayerMoveDirection;
                @PlayerMoveDirection.performed += instance.OnPlayerMoveDirection;
                @PlayerMoveDirection.canceled += instance.OnPlayerMoveDirection;
                @PlayerGas.started += instance.OnPlayerGas;
                @PlayerGas.performed += instance.OnPlayerGas;
                @PlayerGas.canceled += instance.OnPlayerGas;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_StandaloneSchemeIndex = -1;
    public InputControlScheme StandaloneScheme
    {
        get
        {
            if (m_StandaloneSchemeIndex == -1) m_StandaloneSchemeIndex = asset.FindControlSchemeIndex("Standalone");
            return asset.controlSchemes[m_StandaloneSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnPlayerMoveDirection(InputAction.CallbackContext context);
        void OnPlayerGas(InputAction.CallbackContext context);
    }
}
