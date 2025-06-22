using System;
using UnityEngine;

namespace Interfaces.Gameplay
{
    public enum EquipmentType
    {
        Main,
        Secondary
    }
    
    public abstract class Equipmentable : MonoBehaviour
    {
        [SerializeField] private EquipmentType _type;
        
        public EquipmentType Type => _type;

        public event Action RequestEquip;
        public event Action RequestUnequip;
        
        protected virtual void Equip(){}
        protected virtual void UnEquip(){}
    }
}