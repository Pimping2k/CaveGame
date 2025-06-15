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

        private IInputService _inputService;
        
        private Vector2 _input;
        
        private async void Awake()
        {
            _inputService = ServiceLocator.Resolve<IInputService>();

            await UniTask.WaitUntil(() => _inputService.IsInitialized);
            
            _inputService.Player.Attack.performed += OnAttackPerformed;
            _inputService.Player.Move.performed += OnMovePerformed;
            _inputService.Player.Move.canceled += OnMoveCanceled;
        }

        private void FixedUpdate()
        {
            ApplyMovement();
        }

        #region Events

        private void OnMovePerformed(InputAction.CallbackContext obj)
        {
            _input = obj.ReadValue<Vector2>();
        }

        private void OnMoveCanceled(InputAction.CallbackContext obj)
        {
            _input = Vector2.zero;
        }

        private void OnAttackPerformed(InputAction.CallbackContext obj)
        {
            Debug.Log("Attacked");
        }

        #endregion

        #region Movement calculations

        private void ApplyMovement()
        {
            _rigidbody.linearVelocity = new Vector3(_input.x, 0f, _input.y) * _speed;
        }

        private void ApplyRotation()
        {
        }
        
        #endregion
    }
}