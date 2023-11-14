//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Settings/InputSystem/MetroMayhemInputSystem.inputactions
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

public partial class @MetroMayhemInputSystem: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MetroMayhemInputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MetroMayhemInputSystem"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""fad07256-0bcc-48ee-b525-426e4ba3b06d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""741bc706-3b41-412c-b5ed-e92951394ab7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""72c556fb-dfab-4a0c-9e03-099b605a99ea"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3486551b-473b-49d3-ba61-3ab268af4bb0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7bf6b857-fbc9-4a07-bd41-87b015e77239"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""82ab5697-0119-42ff-a6eb-24bd19519aa1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e14a959b-6d9f-44e2-98f3-910aa0cc55e5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4d21bbf4-edeb-446f-b005-b2aef0e6f637"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a540f9d5-ed2e-4708-a5e2-586f6002cedb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d1454ddb-6813-4a3f-a069-027120bf230d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d0113c7f-786c-4643-9fe1-a064ce72817b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b1c15548-3a14-4a7f-9d52-eca6422ee274"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e254560d-fce4-4906-9c00-213c70860abf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6620ac0f-4f75-4a41-bc60-927992176875"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""52ed3c77-0e42-456d-b9f1-715ac7583e65"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""699515ca-0b2a-443f-bd29-d9d7df75159d"",
                    ""path"": ""<Keyboard>/#(R)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6abd2fc1-f636-495c-9603-289194c157af"",
                    ""path"": ""<Keyboard>/#(F)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Towers"",
            ""id"": ""9b513b60-d453-490e-be7b-2b1f403e7fbd"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""1f789788-787b-49ef-bbbf-d25ab0fcbf21"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Place"",
                    ""type"": ""Button"",
                    ""id"": ""6b51d400-5c2c-44cd-9e33-dd063f428ce7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""4b1d0e3e-2595-43b6-9eb7-3965174d48f3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Upgrade"",
                    ""type"": ""Button"",
                    ""id"": ""6b873a18-717a-46af-99c8-43377686c64c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dismantle"",
                    ""type"": ""Button"",
                    ""id"": ""7d13a6d4-6e22-43d7-8807-705a5b730f84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""037b9a84-27fe-4419-9478-b6145a98cc18"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63e79aa8-05f9-4b8c-bfba-63f96516eb86"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Place"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9928d375-c746-4339-b81e-992b2ac99bd5"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19fe75ea-9a48-4c82-ab85-acb4f98286d2"",
                    ""path"": ""<Keyboard>/#(U)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Upgrade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""892a59b7-dc61-4b91-be6c-84f8c34cfeea"",
                    ""path"": ""<Keyboard>/#(X)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dismantle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GameControl"",
            ""id"": ""d183d60e-5cea-42bd-a38d-588c0b15488a"",
            ""actions"": [
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""8e6100f0-a9ca-4e7f-9cef-d97d4bfd2785"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""f5aac274-3be8-446a-b9b7-3dcffbe0f816"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""669a0298-ab9b-4d52-ad12-b3131f35eff8"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""be4438ac-4cdc-403b-b45a-776966d68e28"",
                    ""path"": ""<Keyboard>/#(Q)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Movement = m_Camera.FindAction("Movement", throwIfNotFound: true);
        m_Camera_Zoom = m_Camera.FindAction("Zoom", throwIfNotFound: true);
        // Towers
        m_Towers = asset.FindActionMap("Towers", throwIfNotFound: true);
        m_Towers_Fire = m_Towers.FindAction("Fire", throwIfNotFound: true);
        m_Towers_Place = m_Towers.FindAction("Place", throwIfNotFound: true);
        m_Towers_Movement = m_Towers.FindAction("Movement", throwIfNotFound: true);
        m_Towers_Upgrade = m_Towers.FindAction("Upgrade", throwIfNotFound: true);
        m_Towers_Dismantle = m_Towers.FindAction("Dismantle", throwIfNotFound: true);
        // GameControl
        m_GameControl = asset.FindActionMap("GameControl", throwIfNotFound: true);
        m_GameControl_Quit = m_GameControl.FindAction("Quit", throwIfNotFound: true);
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

    // Camera
    private readonly InputActionMap m_Camera;
    private List<ICameraActions> m_CameraActionsCallbackInterfaces = new List<ICameraActions>();
    private readonly InputAction m_Camera_Movement;
    private readonly InputAction m_Camera_Zoom;
    public struct CameraActions
    {
        private @MetroMayhemInputSystem m_Wrapper;
        public CameraActions(@MetroMayhemInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Camera_Movement;
        public InputAction @Zoom => m_Wrapper.m_Camera_Zoom;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void AddCallbacks(ICameraActions instance)
        {
            if (instance == null || m_Wrapper.m_CameraActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CameraActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Zoom.started += instance.OnZoom;
            @Zoom.performed += instance.OnZoom;
            @Zoom.canceled += instance.OnZoom;
        }

        private void UnregisterCallbacks(ICameraActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Zoom.started -= instance.OnZoom;
            @Zoom.performed -= instance.OnZoom;
            @Zoom.canceled -= instance.OnZoom;
        }

        public void RemoveCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICameraActions instance)
        {
            foreach (var item in m_Wrapper.m_CameraActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CameraActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CameraActions @Camera => new CameraActions(this);

    // Towers
    private readonly InputActionMap m_Towers;
    private List<ITowersActions> m_TowersActionsCallbackInterfaces = new List<ITowersActions>();
    private readonly InputAction m_Towers_Fire;
    private readonly InputAction m_Towers_Place;
    private readonly InputAction m_Towers_Movement;
    private readonly InputAction m_Towers_Upgrade;
    private readonly InputAction m_Towers_Dismantle;
    public struct TowersActions
    {
        private @MetroMayhemInputSystem m_Wrapper;
        public TowersActions(@MetroMayhemInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_Towers_Fire;
        public InputAction @Place => m_Wrapper.m_Towers_Place;
        public InputAction @Movement => m_Wrapper.m_Towers_Movement;
        public InputAction @Upgrade => m_Wrapper.m_Towers_Upgrade;
        public InputAction @Dismantle => m_Wrapper.m_Towers_Dismantle;
        public InputActionMap Get() { return m_Wrapper.m_Towers; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TowersActions set) { return set.Get(); }
        public void AddCallbacks(ITowersActions instance)
        {
            if (instance == null || m_Wrapper.m_TowersActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TowersActionsCallbackInterfaces.Add(instance);
            @Fire.started += instance.OnFire;
            @Fire.performed += instance.OnFire;
            @Fire.canceled += instance.OnFire;
            @Place.started += instance.OnPlace;
            @Place.performed += instance.OnPlace;
            @Place.canceled += instance.OnPlace;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Upgrade.started += instance.OnUpgrade;
            @Upgrade.performed += instance.OnUpgrade;
            @Upgrade.canceled += instance.OnUpgrade;
            @Dismantle.started += instance.OnDismantle;
            @Dismantle.performed += instance.OnDismantle;
            @Dismantle.canceled += instance.OnDismantle;
        }

        private void UnregisterCallbacks(ITowersActions instance)
        {
            @Fire.started -= instance.OnFire;
            @Fire.performed -= instance.OnFire;
            @Fire.canceled -= instance.OnFire;
            @Place.started -= instance.OnPlace;
            @Place.performed -= instance.OnPlace;
            @Place.canceled -= instance.OnPlace;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Upgrade.started -= instance.OnUpgrade;
            @Upgrade.performed -= instance.OnUpgrade;
            @Upgrade.canceled -= instance.OnUpgrade;
            @Dismantle.started -= instance.OnDismantle;
            @Dismantle.performed -= instance.OnDismantle;
            @Dismantle.canceled -= instance.OnDismantle;
        }

        public void RemoveCallbacks(ITowersActions instance)
        {
            if (m_Wrapper.m_TowersActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITowersActions instance)
        {
            foreach (var item in m_Wrapper.m_TowersActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TowersActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TowersActions @Towers => new TowersActions(this);

    // GameControl
    private readonly InputActionMap m_GameControl;
    private List<IGameControlActions> m_GameControlActionsCallbackInterfaces = new List<IGameControlActions>();
    private readonly InputAction m_GameControl_Quit;
    public struct GameControlActions
    {
        private @MetroMayhemInputSystem m_Wrapper;
        public GameControlActions(@MetroMayhemInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Quit => m_Wrapper.m_GameControl_Quit;
        public InputActionMap Get() { return m_Wrapper.m_GameControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameControlActions set) { return set.Get(); }
        public void AddCallbacks(IGameControlActions instance)
        {
            if (instance == null || m_Wrapper.m_GameControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameControlActionsCallbackInterfaces.Add(instance);
            @Quit.started += instance.OnQuit;
            @Quit.performed += instance.OnQuit;
            @Quit.canceled += instance.OnQuit;
        }

        private void UnregisterCallbacks(IGameControlActions instance)
        {
            @Quit.started -= instance.OnQuit;
            @Quit.performed -= instance.OnQuit;
            @Quit.canceled -= instance.OnQuit;
        }

        public void RemoveCallbacks(IGameControlActions instance)
        {
            if (m_Wrapper.m_GameControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameControlActions instance)
        {
            foreach (var item in m_Wrapper.m_GameControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameControlActions @GameControl => new GameControlActions(this);
    public interface ICameraActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
    }
    public interface ITowersActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnPlace(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnUpgrade(InputAction.CallbackContext context);
        void OnDismantle(InputAction.CallbackContext context);
    }
    public interface IGameControlActions
    {
        void OnQuit(InputAction.CallbackContext context);
    }
}
