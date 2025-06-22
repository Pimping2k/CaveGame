using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ObjectPooling.BulletPooling
{
    public class BulletPool : ObjectPool<Bullet>
    {
        public override void Awake()
        {
            base.Awake();
            foreach (var bullet in _pool)
            {
                ReturnObjectInPool(bullet);
                bullet.Hitted += OnHitted;
            }
        }

        private void OnHitted(Bullet bullet)
        {
            ReturnObjectInPool(bullet);
        }

        public async void ReleaseBullet(Transform releasePosition, Vector3 direction)
        {
            var bullet = GetObjectFromPool();
            bullet.transform.position = releasePosition.position;
            
            Vector3 shootDirection = direction.normalized;
            bullet.Rigidbody.linearVelocity = shootDirection * bullet.Speed;

            await UniTask.WaitForSeconds(bullet.LifeTime);
            ReturnObjectInPool(bullet);
        }
    }
}