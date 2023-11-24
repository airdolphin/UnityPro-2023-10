using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private int initialCount = 50;

        [SerializeField] private Bullet prefab;
        [SerializeField] private Transform container;
        [SerializeField] private Transform worldTransform;

        private readonly Queue<Bullet> bulletPool = new();
        
        private void Awake()
        {
            for (var i = 0; i < initialCount; i++)
            {
                var bullet = Instantiate(prefab, container);
                bulletPool.Enqueue(bullet);
            }
        }
        
        public Bullet SpawnBullet()
        {
            if (bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(worldTransform);
            }
            else
            {
                bullet = Instantiate(prefab, worldTransform);
            }

            return bullet;
        }

        public void UnspawnBullet(Bullet bullet)
        {
            bullet.transform.SetParent(container);
            bulletPool.Enqueue(bullet);
        }
    }
}