using Atomic;
using Bullet;
using UnityEngine;

namespace Mechanics
{
    public class ShootMechanics
    {
        private readonly AtomicVariable<bool> _canShoot;
        private readonly AtomicVariable<int> _bulletCurrentAmount;
        private readonly AtomicEvent _fireEvent;
        private readonly Transform _firePoint;
        private readonly BulletModel _bulletPrefab;
        private readonly Transform _root;

        public ShootMechanics(
            AtomicVariable<bool> canShoot, AtomicVariable<int> bulletCurrentAmount,
            AtomicEvent fireEvent, Transform firePoint, BulletModel bulletPrefab, Transform root
        )
        {
            _canShoot = canShoot;
            _bulletCurrentAmount = bulletCurrentAmount;
            _fireEvent = fireEvent;
            _firePoint = firePoint;
            _bulletPrefab = bulletPrefab;
            _root = root;
        }

        public void OnEnable()
        {
            _fireEvent.Subscribe(OnFire);
        }

        public void OnDisable()
        {
            _fireEvent.UnSubscribe(OnFire);
        }

        private void OnFire()
        {
            if (!_canShoot.Value)
            {
                return;
            }

            var bullet = Object.Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            bullet.moveDirection.Value = _root.forward;
        }
    }
}