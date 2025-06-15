using Interfaces;
using ServiceLocatorRelated;
using UnityEngine;

namespace Dependencies
{
    public class InputService : MonoBehaviour, IInputService
    {
        private InputSystem_Actions _inputSystem;
        public InputSystem_Actions InputSystem => _inputSystem;
        public InputSystem_Actions.PlayerActions Player { get; private set; }
        public InputSystem_Actions.UIActions UI { get; private set; }
        public bool IsInitialized { get; private set; }

        private void Awake()
        {
            _inputSystem = new InputSystem_Actions();
            Player = _inputSystem.Player;
            UI = _inputSystem.UI;
            
            _inputSystem.Enable();
            Player.Enable();
            IsInitialized = true;
        }
    }
}