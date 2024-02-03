using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    [Serializable]
    public class BulletPool :
        GameListeners.IGameStartListener
    {
        [SerializeField] private int _initialCount = 50;
        [SerializeField] private Bullet _prefab;
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _worldTransform;

        private Pool<Bullet> bulletPool;

        public void OnStart()
        {
            bulletPool = new Pool<Bullet>(_prefab, _initialCount, _container);
        }

        public Bullet SpawnBullet()
        {
            Bullet bullet = bulletPool.Get();
            if (bullet)
            {
                bullet.transform.SetParent(_worldTransform);
            }

            return bullet;
        }

        public void UnspawnBullet(Bullet bullet)
        {
            bullet.transform.SetParent(_container);
            bulletPool.Release(bullet);
        }
    }
}