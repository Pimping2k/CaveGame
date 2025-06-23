using UnityEngine;

namespace EnemyFactory
{
    public class DummyEnemy : MonoBehaviour, IEnemyProduct
    {
        [SerializeField] private float _maxHealth;
        public float Health { get; private set; }
        
        public void Initialize()
        {
            Health = _maxHealth;
        }
    }
}