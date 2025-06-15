using System;
using Cysharp.Threading.Tasks;
using Interfaces;
using ServiceLocatorRelated;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerComponents
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        private IInputService _inputService;
        
        private Vector2 _movementInput;
        private Vector2 _rotationInput;
        
        private async void Awake()
        {
            _inputService = ServiceLocator.Resolve<IInputService>();

            await UniTask.WaitUntil(() => _inputService.IsInitialized);
            
            _inputService.Player.Move.performed += OnMovePerformed;
            _inputService.Player.Move.canceled += OnMoveCanceled;
            _inputService.Player.Look.performed += OnLookPerformed;
        }

        private void OnDestroy()
        {
            _inputService.Player.Move.performed -= OnMovePerformed;
            _inputService.Player.Move.canceled -= OnMoveCanceled;
            _inputService.Player.Look.performed -= OnLookPerformed;
        }

        private void FixedUpdate()
        {
            ApplyMovement();
        }

        #region Events

        private void OnLookPerformed(InputAction.CallbackContext obj)
        {
            _rotationInput = obj.ReadValue<Vector2>();
            Debug.Log(_rotationInput);
        }

        private void OnMovePerformed(InputAction.CallbackContext obj)
        {
            _movementInput = obj.ReadValue<Vector2>();
        }

        private void OnMoveCanceled(InputAction.CallbackContext obj)
        {
            _movementInput = Vector2.zero;
        }

        #endregion

        #region Movement calculations

        private void ApplyMovement()
        {
            _rigidbody.linearVelocity = new Vector3(_movementInput.x, 0f, _movementInput.y) * _speed;
        }

        private void ApplyRotation()
        {
        }
        
        #endregion
    }
}