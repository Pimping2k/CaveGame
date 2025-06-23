using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Interfaces.Services;
using ServiceLocatorRelated;
using Unity.Mathematics;
using UnityEngine;

namespace EnemyFactory
{
    public enum EnemyType
    {
        Dummy,
    }
    public class EnemyFactoryManager : EnemyFactory, IEnemyService 
    {
        [SerializeField] private SerializedDictionary<EnemyType,EnemyBase> _enemyDictionary = new();
        
        public bool IsInitialized { get; set; }
        public IReadOnlyDictionary<EnemyType, EnemyBase> EnemyDictionary => _enemyDictionary;
        
        public override IEnemyProduct GetEnemy(EnemyType type,Vector3 position)
        {
            if (_enemyDictionary.TryGetValue(type, out var enemy))
            {
                var enemyInstance = Instantiate(enemy, position, quaternion.identity);
                enemyInstance.Initialize();
                return enemyInstance;
            }

            return null;
        }
    }
}