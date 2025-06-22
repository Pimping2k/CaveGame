using CustomEditorAttributes;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Configs.Gameplay
{
    [CreateAssetMenu(fileName = "GunConfig_00", menuName = Data.Paths.GAMEPLAY + "Gun Config")]
    public class GunConfig : ScriptableObject
    {
        [PimpingHeader("Damage Settings", HeaderColor.Indigo)]
        [SerializeField] private float _damage;
        [SerializeField] private float _weakSpotDamageMultiplier;
        [SerializeField] [MinMaxRangeSlider(0f,5f)] private Vector2 _heatDamageMultiplier;

        [PimpingHeader("Heat Settings", HeaderColor.Indigo)] 
        [SerializeField] private float _heatCooldown;
        [SerializeField] private float _heatStartTime;
    }
}