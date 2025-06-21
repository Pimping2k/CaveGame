using System;
using Cysharp.Threading.Tasks;
using Interfaces.Gameplay;
using Interfaces.Services;
using ServiceLocatorRelated;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Equipment
{
    public class Gun : MonoBehaviour, IEquipmentable
    {
        private IInputService _inputService;

        private async void Awake()
        {
            _inputService = ServiceLocator.Resolve<IInputService>();

            await UniTask.WaitUntil(() => _inputService.IsInitialized);
            
            _inputService.Player.EquipMain.performed += OnMainEquip;
        }

        private void OnDestroy()
        {
            _inputService.Player.EquipMain.performed -= OnMainEquip;
        }

        private void OnMainEquip(InputAction.CallbackContext ctx)
        {
            
        }

        public void Equip()
        {
            throw new System.NotImplementedException();
        }

        public void UnEquip()
        {
            throw new System.NotImplementedException();
        }
    }
}