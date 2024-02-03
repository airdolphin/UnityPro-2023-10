using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : GameListeners.IGameFixedUpdateListener
    {
        private WeaponComponent _weaponComponent;
        private readonly BulletSystem _bulletSystem;
        private BulletConfig _bulletConfig;
        private HitPointsComponent _characterTarget;
        private float _countdown = 1f;
        private float _currentTime;

        public EnemyAttackAgent(WeaponComponent weaponComponent, BulletSystem bulletSystem, BulletConfig bulletConfig)
        {
            _weaponComponent = weaponComponent;
            _bulletSystem = bulletSystem;
            _bulletConfig = bulletConfig;
        }

        public void SetTarget(HitPointsComponent target)
        {
            _characterTarget = target;
        }

        public void Reset()
        {
            _currentTime = _countdown;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (!_characterTarget.IsHitPointsExists())
            {
                return;
            }

            _currentTime -= Time.fixedDeltaTime;
            if (_currentTime <= 0)
            {
                Fire();
                _currentTime += _countdown;
            }
        }

        private void Fire()
        {
            var startPosition = _weaponComponent.Position;
            var vector = (Vector2)_characterTarget.transform.position - startPosition;
            var direction = vector.normalized;

            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int)_bulletConfig.physicsLayer,
                color = _bulletConfig.color,
                damage = _bulletConfig.damage,
                position = startPosition,
                velocity = direction * _bulletConfig.speed
            });
        }
    }
}