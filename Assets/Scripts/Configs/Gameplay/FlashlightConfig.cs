using CustomEditorAttributes;
using UnityEngine;

namespace Configs.Gameplay
{
    [CreateAssetMenu(fileName = "Flashlight Config", menuName = Data.Paths.GAMEPLAY + "Flashlight Config")]
    public class FlashlightConfig : ScriptableObject
    {
        [PimpingHeader("Settings", HeaderColor.Navy)]
        [SerializeField] private float _decreaseValue;
        [SerializeField] private float _increaseValue;
        [SerializeField] private float _maxBatteryCharge;
        [SerializeField] private float _delayForReplenish;

        public float DecreaseValue => _decreaseValue;
        public float IncreaseValue => _increaseValue;
        public float MaxBatteryCharge => _maxBatteryCharge;
        public float DelayForReplenish => _delayForReplenish;
    }
}