using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class BulletSystem :
        GameListeners.IGameFixedUpdateListener
    {
        private LevelBounds _levelBounds;
        private BulletPool _bulletPool;

        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();

        [Inject]
        public void Construct(LevelBounds levelBounds, BulletPool bulletPool)
        {
            _levelBounds = levelBounds;
            _bulletPool = bulletPool;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            CheckBulletInBounds();
        }

        private void CheckBulletInBounds()
        {
            _cache.Clear();
            _cache.AddRange(_activeBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                var bullet = _cache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(Args args)
        {
            var bullet = _bulletPool.SpawnBullet();

            bullet.Init(
                args.isPlayer,
                args.damage,
                args.velocity,
                args.physicsLayer,
                args.position,
                args.color
            );

            if (_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        private void OnBulletCollision(Bullet bullet, GameObject gameObject)
        {
            DealDamage(bullet, gameObject);
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                _bulletPool.UnspawnBullet(bullet);
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