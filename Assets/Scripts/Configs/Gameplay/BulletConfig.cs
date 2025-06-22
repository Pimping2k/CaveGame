using CustomEditorAttributes;
using UnityEngine;

namespace Configs.Gameplay
{
    [CreateAssetMenu(fileName = "BulletConfig_00", menuName = Data.Paths.GAMEPLAY + "Bullet Config")]
    public class BulletConfig : ScriptableObject
    {
        [PimpingHeader("Settings", HeaderColor.Indigo)]
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;

        public float Speed => _speed;
        public float LifeTime => _lifeTime;
    }
}