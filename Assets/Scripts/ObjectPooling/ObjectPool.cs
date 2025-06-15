using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private T _baseItem;
        [SerializeField] private int _poolSize;
        
        private readonly List<T> _pool = new();

        private void Awake()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                var poolInstance = Instantiate(_baseItem, _poolContainer);
                poolInstance.gameObject.SetActive(false);
                _pool.Add(poolInstance);
            }
        }

        public T GetObjectFromPool()
        {
            foreach (var poolItem in _pool)
            {
                if (!poolItem.gameObject.activeSelf)
                {
                    poolItem.gameObject.SetActive(true);
                    return poolItem;
                }
            }

            return CreateNewItem();
        }

        public void ReturnObjectInPool(T poolItem)
        {
            poolItem.gameObject.SetActive(false);
        }
        
        private T CreateNewItem()
        {
            var newItem = Instantiate(_pool[0]);
            _pool.Add(newItem);
            return newItem;
        }
    }
}