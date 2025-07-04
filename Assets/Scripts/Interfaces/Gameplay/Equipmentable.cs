﻿using System;
using CustomEditorAttributes;
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
        [PimpingHeader("Gun settings", HeaderColor.Cyan)]
        [SerializeField] private EquipmentType _type;
        
        public EquipmentType Type => _type;

        public event Action RequestEquip;
        public event Action RequestUnequip;
        
        public virtual void Equip(){}
        public virtual void UnEquip(){}
    }
}