// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""33ca09d9-2c27-4178-80e4-ef8c1b78bb35"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ac3bd231-5226-4a8a-83f8-c9ad2de8e5db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Left"",
                    ""type"": ""Button"",
                    ""id"": ""c5b94caa-e88a-40a0-9a00-8b25d55d6edb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Right"",
                    ""type"": ""Button"",
                    ""id"": ""420431aa-a1eb-4b97-827e-f5910f814dc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""d9785d1b-e90f-4246-a48e-5195b41de15e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""e1199875-913d-4e9c-919b-c693dd293833"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""79b74379-9cdb-439f-8674-040868f70200"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24ed3a68-c58a-455d-846c-fbb5dbe3533f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""789f4b23-75d9-48b6-a307-1c405997df9d"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e947b27-6214-42f6-91c7-b18c9dbf071e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d2478b3-863d-456e-b7dc-0f99505c87c9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6aab3fc9-e2cc-43eb-99d5-1f99a022d19d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77e414cf-c1b8-45e9-bc31-53fba8e98e4e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e90b8a00-ccf8-4d50-ad49-ec4c9d9556d3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c78497fd-d9c5-4e2b-97f6-265984f91526"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f5c7a7f-44b5-4125-beab-b27660420601"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4381073-6f7e-4870-9068-c9b94da67551"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acca5f50-cd67-4fae-a328-a393935d09a0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fe19986-bca3-4728-b803-5ea3870465eb"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcdea89c-15ff-4e1e-87a7-70ba0be24960"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Jump = m_GamePlay.FindAction("Jump", throwIfNotFound: true);
        m_GamePlay_MoveLeft = m_GamePlay.FindAction("Move Left", throwIfNotFound: true);
        m_GamePlay_MoveRight = m_GamePlay.FindAction("Move Right", throwIfNotFound: true);
        m_GamePlay_MoveUp = m_GamePlay.FindAction("MoveUp", throwIfNotFound: true);
        m_GamePlay_MoveDown = m_GamePlay.FindAction("MoveDown", throwIfNotFound: true);
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Jump;
    private readonly InputAction m_GamePlay_MoveLeft;
    private readonly InputAction m_GamePlay_MoveRight;
    private readonly InputAction m_GamePlay_MoveUp;
    private readonly InputAction m_GamePlay_MoveDown;
    public struct GamePlayActions
    {
        private @PlayerControls m_Wrapper;
        public GamePlayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_GamePlay_Jump;
        public InputAction @MoveLeft => m_Wrapper.m_GamePlay_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_GamePlay_MoveRight;
        public InputAction @MoveUp => m_Wrapper.m_GamePlay_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_GamePlay_MoveDown;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @MoveLeft.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMoveRight;
                @MoveUp.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMoveUp;
                @MoveUp.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMoveUp;
                @MoveUp.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMoveUp;
                @MoveDown.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMoveDown;
                @MoveDown.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMoveDown;
                @MoveDown.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMoveDown;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @MoveUp.started += instance.OnMoveUp;
                @MoveUp.performed += instance.OnMoveUp;
                @MoveUp.canceled += instance.OnMoveUp;
                @MoveDown.started += instance.OnMoveDown;
                @MoveDown.performed += instance.OnMoveDown;
                @MoveDown.canceled += instance.OnMoveDown;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
    }
}
