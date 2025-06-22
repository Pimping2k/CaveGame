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
            }
        }

        public async void ReleaseBullet(Transform releasePosition)
        {
            var bullet = GetObjectFromPool();
            bullet.transform.position = releasePosition.position;
            bullet.Rigidbody.AddForce(releasePosition.forward * bullet.Speed, ForceMode.Acceleration);
            await UniTask.WaitForSeconds(bullet.LifeTime);
            ReturnObjectInPool(bullet);
        }
    }
}