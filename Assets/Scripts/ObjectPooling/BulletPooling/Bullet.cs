using System;
using Configs.Gameplay;
using UnityEngine;

namespace ObjectPooling.BulletPooling
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private BulletConfig _config;

        public Rigidbody Rigidbody => _rigidbody;
        public float Speed => _config.Speed;
        public float LifeTime => _config.LifeTime;

        public event Action<Bullet> Hitted;

        private void OnTriggerEnter(Collider other)
        {
            Hitted?.Invoke(this);
        }
    }
}