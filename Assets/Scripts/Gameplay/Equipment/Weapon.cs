using Configs.Gameplay;
using Cysharp.Threading.Tasks;
using Interfaces.Gameplay;
using Interfaces.Services;
using ObjectPooling.BulletPooling;
using ServiceLocatorRelated;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

namespace Gameplay.Equipment
{
    public class Weapon : Equipmentable
    {
        [SerializeField] private GunConfig _config;
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private Transform _muzzle;
        
        private IInputService _inputService;

        private bool _inputSubscribed;
        
        private void Awake()
        {
            _inputService = ServiceLocator.Resolve<IInputService>();

            gameObject.SetActive(false);
        }

        private void ToggleSubscriptions(bool state)
        {
            if (state && !_inputSubscribed)
            {
                _inputSubscribed = true;
                _inputService.Player.MainAction.performed += OnMainActionPerformed;
                _inputService.Player.MainAction.started += OnMainActionStarted;
                _inputService.Player.MainAction.canceled += OnMainActionCanceled;
            }
            else if(!state && _inputSubscribed)
            {
                _inputSubscribed = false;
                _inputService.Player.MainAction.performed -= OnMainActionPerformed;
                _inputService.Player.MainAction.started -= OnMainActionStarted;
                _inputService.Player.MainAction.canceled -= OnMainActionCanceled;
            }
        }

        #region Input Events

        private void OnMainActionStarted(InputAction.CallbackContext ctx)
        {
            Shoot();
        }

        private async void OnMainActionPerformed(InputAction.CallbackContext ctx)
        {
            while (ctx.ReadValue<float>() > 0.5f)
            {
                Shoot();
                await UniTask.WaitForSeconds(_config.ShootingSpeed);
            }
        }

        private void OnMainActionCanceled(InputAction.CallbackContext ctx)
        {
        }

        #endregion

        #region Actions

        public override void Equip()
        {
            ToggleSubscriptions(true);
            gameObject.SetActive(true);
        }

        public override void UnEquip()
        {
            ToggleSubscriptions(false);
            gameObject.SetActive(false);
        }

        #endregion

        #region Shooting Logic

        private void Shoot()
        {
            _bulletPool.ReleaseBullet(_muzzle, _muzzle.forward);
        }

        #endregion
    }
}