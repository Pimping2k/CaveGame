using UnityEngine;

namespace ObjectPooling.BulletPooling
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;

        public Rigidbody Rigidbody => _rigidbody;
        public float Speed => _speed;
        public float LifeTime => _lifeTime;
    }
}