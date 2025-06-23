using UnityEngine;

namespace EnemyFactory
{
    public abstract class EnemyBase : MonoBehaviour, IEnemyProduct
    {
        public float Health { get; }
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}