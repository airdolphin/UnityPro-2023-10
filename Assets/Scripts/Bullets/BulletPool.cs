using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public class BulletPool :
        GameListeners.IGameStartListener
    {
        [SerializeField] private int initialCount = 50;
        [SerializeField] private Bullet prefab;
        [SerializeField] private Transform container;
        [SerializeField] private Transform worldTransform;

        private Pool<Bullet> bulletPool;
        // private readonly Queue<Bullet> bulletPool = new();

        public void OnStart()
        {
            bulletPool = new Pool<Bullet>(prefab, initialCount, container);
        }

        // private void Awake()
        // {
        //     for (var i = 0; i < initialCount; i++)
        //     {
        //         var bullet = Instantiate(prefab, container);
        //         bulletPool.Enqueue(bullet);
        //     }
        // }

        public Bullet SpawnBullet()
        {
            Bullet bullet = bulletPool.Get();
            if (bullet)
            {
                bullet.transform.SetParent(worldTransform);
            }
            // else
            // {
            //     bullet = Instantiate(prefab, worldTransform);
            // }

            return bullet;
        }

        public void UnspawnBullet(Bullet bullet)
        {
            bullet.transform.SetParent(container);
            bulletPool.Release(bullet);
        }
    }
}