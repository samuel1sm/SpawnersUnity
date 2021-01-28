// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Terrain"",
            ""id"": ""d99d61f7-57bd-42df-8a9c-7cf88a54793e"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""e378a813-aaff-4592-9cde-952c89e4e513"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9c8e04ff-73bc-41dd-a18d-c91f32e3e210"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""df8b0a56-cde3-46ff-b6b8-444533d10cf9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5ecde753-d58d-4751-bf43-50ed3d3480b3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""02e49453-4255-40f3-bfd1-64b8aba15049"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d0b472df-b6ec-4d83-b0f1-195f130cc4c2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Terrain
        m_Terrain = asset.FindActionMap("Terrain", throwIfNotFound: true);
        m_Terrain_Move = m_Terrain.FindAction("Move", throwIfNotFound: true);
        m_Terrain_Jump = m_Terrain.FindAction("Jump", throwIfNotFound: true);
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

    // Terrain
    private readonly InputActionMap m_Terrain;
    private ITerrainActions m_TerrainActionsCallbackInterface;
    private readonly InputAction m_Terrain_Move;
    private readonly InputAction m_Terrain_Jump;
    public struct TerrainActions
    {
        private @PlayerController m_Wrapper;
        public TerrainActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Terrain_Move;
        public InputAction @Jump => m_Wrapper.m_Terrain_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Terrain; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TerrainActions set) { return set.Get(); }
        public void SetCallbacks(ITerrainActions instance)
        {
            if (m_Wrapper.m_TerrainActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_TerrainActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_TerrainActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_TerrainActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_TerrainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public TerrainActions @Terrain => new TerrainActions(this);
    public interface ITerrainActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
