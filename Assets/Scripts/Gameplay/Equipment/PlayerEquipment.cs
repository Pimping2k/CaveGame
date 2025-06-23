using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces.Gameplay;
using Interfaces.Services;
using ServiceLocatorRelated;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Equipment
{
    public class PlayerEquipment : MonoBehaviour
    {
        [SerializeField] private List<Equipmentable> _equipment = new();

        private IInputService _inputService;

        private bool _equipped;
        private Equipmentable _currentEquipment;

        private void Awake()
        {
            _inputService = ServiceLocator.Resolve<IInputService>();
            
            _inputService.Player.EquipMain.performed += OnMainEquip;
            _inputService.Player.EquipSecondary.performed += OnSecondaryEquip;
        }

        private void OnDestroy()
        {
            _inputService.Player.EquipMain.performed -= OnMainEquip;
            _inputService.Player.EquipSecondary.performed -= OnSecondaryEquip;
        }

        private void OnMainEquip(InputAction.CallbackContext ctx)
        {
            ChangeEquipment(EquipmentType.Secondary, EquipmentType.Main);
        }

        private void OnSecondaryEquip(InputAction.CallbackContext ctx)
        {
            ChangeEquipment(EquipmentType.Main, EquipmentType.Secondary);
        }

        private void ChangeEquipment(EquipmentType previousType,EquipmentType neededType)
        {
            _equipped = !_equipped;

            if (_currentEquipment == null)
                _currentEquipment = _equipment.First(e => e.Type == neededType);
            
            if(_currentEquipment.Type == previousType)
                _currentEquipment.UnEquip();
            
            if(_equipped)
                _currentEquipment.Equip();
            else
                _currentEquipment.UnEquip();
        }
    }
}