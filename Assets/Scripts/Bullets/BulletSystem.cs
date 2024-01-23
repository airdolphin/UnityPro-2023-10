using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class BulletSystem :
        GameListeners.IGameFixedUpdateListener
    {
        private LevelBounds levelBounds;
        private BulletPool bulletPool;

        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> cache = new();

        [Inject]
        public void Construct(LevelBounds _levelBounds, BulletPool _bulletPool)
        {
            levelBounds = _levelBounds;
            bulletPool = _bulletPool;
        }
        
        public void OnFixedUpdate(float deltaTime)
        {
            CheckBulletInBounds();
        }

        private void CheckBulletInBounds()
        {
            cache.Clear();
            cache.AddRange(this.activeBullets);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var bullet = cache[i];
                if (!levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(Args args)
        {
            var bullet = bulletPool.SpawnBullet();

            bullet.Init(
                args.isPlayer,
                args.damage,
                args.velocity,
                args.physicsLayer,
                args.position,
                args.color
            );

            if (activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            DealDamage(bullet, collision.gameObject);
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                bulletPool.UnspawnBullet(bullet);
            }
        }

        private static void DealDamage(Bullet bullet, GameObject other)
        {
            if (!other.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (bullet.IsPlayer == team.IsPlayer)
            {
                return;
            }

            if (other.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(bullet.Damage);
            }
        }

        public struct Args
        {
            public Vector2 position;
            public Vector2 velocity;
            public Color color;
            public int physicsLayer;
            public int damage;
            public bool isPlayer;
        }
    }
}