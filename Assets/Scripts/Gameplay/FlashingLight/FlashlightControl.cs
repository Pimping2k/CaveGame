using System;
using Cysharp.Threading.Tasks;
using Interfaces.Services;
using ServiceLocatorRelated;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.FlashingLight
{
    public class FlashlightControl : MonoBehaviour
    {
        [SerializeField] private Flashlight _flashlight;
        
        private IInputService _inputService;

        private bool _isTurnedOn;

        public event Action<bool> ChangedState;
        
        private void Awake()
        {
            _inputService = ServiceLocator.Resolve<IInputService>();
            
            _inputService.Player.ToggleFlashlight.performed += OnToggleFlashlightPerformed;
            _flashlight.Discharged += OnDischarged;
        }

        private void OnDestroy()
        {
            _inputService.Player.ToggleFlashlight.performed -= OnToggleFlashlightPerformed;
            _flashlight.Discharged -= OnDischarged;
        }

        private void OnToggleFlashlightPerformed(InputAction.CallbackContext ctx)
        {
            _isTurnedOn = !_isTurnedOn;
            
            ChangedState?.Invoke(_isTurnedOn);
        }

        private void OnDischarged()
        {
            _isTurnedOn = false;
            ChangedState?.Invoke(false);
        }
    }
}