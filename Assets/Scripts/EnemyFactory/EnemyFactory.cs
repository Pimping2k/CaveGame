using UnityEngine;

namespace EnemyFactory
{
    public abstract class EnemyFactory : MonoBehaviour
    {
        public abstract IEnemyProduct GetEnemy(EnemyType type,Vector3 position);
    }
}