//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/PlayerController.inputactions
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

public partial class @PlayerController : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""8a430202-18af-44f8-a351-d067eb2a629c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7f198511-cad9-420c-9276-78635784d58e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cursor"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e139b82f-c5de-4af3-8ea3-bd1c4bce77d3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""12ff638c-9ea6-4dcc-a153-91ea8f9c4125"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RunPressed"",
                    ""type"": ""Button"",
                    ""id"": ""8651c670-d437-4510-a652-50b4d867833b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DashPressed"",
                    ""type"": ""Button"",
                    ""id"": ""4ca03ae0-4c65-436f-a408-141934fb64ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FirePressed"",
                    ""type"": ""Button"",
                    ""id"": ""86252a4f-acc0-4dff-941a-c4c43e75fb77"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TalentOne"",
                    ""type"": ""Button"",
                    ""id"": ""f6462a3a-bb27-4a98-b0c4-cb4c3fdcc085"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TalentSecond"",
                    ""type"": ""Button"",
                    ""id"": ""33b5c36b-8fd5-4427-b88e-7cfb466674d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TalentThird"",
                    ""type"": ""Button"",
                    ""id"": ""7f90e993-b8ee-42b8-8d52-b8d9608d679f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TalentFourth"",
                    ""type"": ""Button"",
                    ""id"": ""16c1c3e6-24a3-4c16-b22a-0384f61aebad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Punch"",
                    ""type"": ""Button"",
                    ""id"": ""6b1fa6a8-f8e7-4d56-be82-7c5351da89c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Explode"",
                    ""type"": ""Button"",
                    ""id"": ""ea73758d-c501-46e9-a304-8e32003a897e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""07fb408c-67d1-453d-b76e-26428ca755a0"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cca54d83-4e44-4b58-8c00-fcdf303818fa"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b55d55ee-a9ca-468c-9137-50feaed9cda2"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfe3cc44-94c4-4f96-8641-86e3d3d5566f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RunPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d293e627-7b0d-41e0-9382-7d510bd08158"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43dc4122-42d6-4488-9f4f-4a664154a480"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirePressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5dc69c2c-1050-40f5-a25b-2b897902cfc2"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TalentOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8832fa70-6fb7-45e8-8f26-1edcfcf3aac3"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TalentSecond"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff7fbf39-3af1-49f2-b655-84118ed7d96b"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TalentThird"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8184a455-a743-45ae-805c-bc75ae81b786"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TalentFourth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4846caa4-2f5d-43fd-98f8-f9ec54deef83"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Punch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37c8b35a-fb1f-4047-be0c-2b52f47d8d6b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Explode"",
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
        m_GamePlay_Move = m_GamePlay.FindAction("Move", throwIfNotFound: true);
        m_GamePlay_Cursor = m_GamePlay.FindAction("Cursor", throwIfNotFound: true);
        m_GamePlay_Jump = m_GamePlay.FindAction("Jump", throwIfNotFound: true);
        m_GamePlay_RunPressed = m_GamePlay.FindAction("RunPressed", throwIfNotFound: true);
        m_GamePlay_DashPressed = m_GamePlay.FindAction("DashPressed", throwIfNotFound: true);
        m_GamePlay_FirePressed = m_GamePlay.FindAction("FirePressed", throwIfNotFound: true);
        m_GamePlay_TalentOne = m_GamePlay.FindAction("TalentOne", throwIfNotFound: true);
        m_GamePlay_TalentSecond = m_GamePlay.FindAction("TalentSecond", throwIfNotFound: true);
        m_GamePlay_TalentThird = m_GamePlay.FindAction("TalentThird", throwIfNotFound: true);
        m_GamePlay_TalentFourth = m_GamePlay.FindAction("TalentFourth", throwIfNotFound: true);
        m_GamePlay_Punch = m_GamePlay.FindAction("Punch", throwIfNotFound: true);
        m_GamePlay_Explode = m_GamePlay.FindAction("Explode", throwIfNotFound: true);
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Move;
    private readonly InputAction m_GamePlay_Cursor;
    private readonly InputAction m_GamePlay_Jump;
    private readonly InputAction m_GamePlay_RunPressed;
    private readonly InputAction m_GamePlay_DashPressed;
    private readonly InputAction m_GamePlay_FirePressed;
    private readonly InputAction m_GamePlay_TalentOne;
    private readonly InputAction m_GamePlay_TalentSecond;
    private readonly InputAction m_GamePlay_TalentThird;
    private readonly InputAction m_GamePlay_TalentFourth;
    private readonly InputAction m_GamePlay_Punch;
    private readonly InputAction m_GamePlay_Explode;
    public struct GamePlayActions
    {
        private @PlayerController m_Wrapper;
        public GamePlayActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GamePlay_Move;
        public InputAction @Cursor => m_Wrapper.m_GamePlay_Cursor;
        public InputAction @Jump => m_Wrapper.m_GamePlay_Jump;
        public InputAction @RunPressed => m_Wrapper.m_GamePlay_RunPressed;
        public InputAction @DashPressed => m_Wrapper.m_GamePlay_DashPressed;
        public InputAction @FirePressed => m_Wrapper.m_GamePlay_FirePressed;
        public InputAction @TalentOne => m_Wrapper.m_GamePlay_TalentOne;
        public InputAction @TalentSecond => m_Wrapper.m_GamePlay_TalentSecond;
        public InputAction @TalentThird => m_Wrapper.m_GamePlay_TalentThird;
        public InputAction @TalentFourth => m_Wrapper.m_GamePlay_TalentFourth;
        public InputAction @Punch => m_Wrapper.m_GamePlay_Punch;
        public InputAction @Explode => m_Wrapper.m_GamePlay_Explode;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Cursor.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCursor;
                @Cursor.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCursor;
                @Cursor.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCursor;
                @Jump.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @RunPressed.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRunPressed;
                @RunPressed.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRunPressed;
                @RunPressed.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRunPressed;
                @DashPressed.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDashPressed;
                @DashPressed.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDashPressed;
                @DashPressed.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDashPressed;
                @FirePressed.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFirePressed;
                @FirePressed.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFirePressed;
                @FirePressed.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFirePressed;
                @TalentOne.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTalentOne;
                @TalentOne.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTalentOne;
                @TalentOne.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTalentOne;
                @TalentSecond.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTalentSecond;
                @TalentSecond.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTalentSecond;
                @TalentSecond.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTalentSecond;
                @TalentThird.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTalentThird;
                @TalentThird.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTalentThird;
                @TalentThird.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTalentThird;
                @TalentFourth.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTalentFourth;
                @TalentFourth.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTalentFourth;
                @TalentFourth.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTalentFourth;
                @Punch.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPunch;
                @Punch.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPunch;
                @Punch.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPunch;
                @Explode.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnExplode;
                @Explode.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnExplode;
                @Explode.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnExplode;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Cursor.started += instance.OnCursor;
                @Cursor.performed += instance.OnCursor;
                @Cursor.canceled += instance.OnCursor;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @RunPressed.started += instance.OnRunPressed;
                @RunPressed.performed += instance.OnRunPressed;
                @RunPressed.canceled += instance.OnRunPressed;
                @DashPressed.started += instance.OnDashPressed;
                @DashPressed.performed += instance.OnDashPressed;
                @DashPressed.canceled += instance.OnDashPressed;
                @FirePressed.started += instance.OnFirePressed;
                @FirePressed.performed += instance.OnFirePressed;
                @FirePressed.canceled += instance.OnFirePressed;
                @TalentOne.started += instance.OnTalentOne;
                @TalentOne.performed += instance.OnTalentOne;
                @TalentOne.canceled += instance.OnTalentOne;
                @TalentSecond.started += instance.OnTalentSecond;
                @TalentSecond.performed += instance.OnTalentSecond;
                @TalentSecond.canceled += instance.OnTalentSecond;
                @TalentThird.started += instance.OnTalentThird;
                @TalentThird.performed += instance.OnTalentThird;
                @TalentThird.canceled += instance.OnTalentThird;
                @TalentFourth.started += instance.OnTalentFourth;
                @TalentFourth.performed += instance.OnTalentFourth;
                @TalentFourth.canceled += instance.OnTalentFourth;
                @Punch.started += instance.OnPunch;
                @Punch.performed += instance.OnPunch;
                @Punch.canceled += instance.OnPunch;
                @Explode.started += instance.OnExplode;
                @Explode.performed += instance.OnExplode;
                @Explode.canceled += instance.OnExplode;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCursor(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRunPressed(InputAction.CallbackContext context);
        void OnDashPressed(InputAction.CallbackContext context);
        void OnFirePressed(InputAction.CallbackContext context);
        void OnTalentOne(InputAction.CallbackContext context);
        void OnTalentSecond(InputAction.CallbackContext context);
        void OnTalentThird(InputAction.CallbackContext context);
        void OnTalentFourth(InputAction.CallbackContext context);
        void OnPunch(InputAction.CallbackContext context);
        void OnExplode(InputAction.CallbackContext context);
    }
}
