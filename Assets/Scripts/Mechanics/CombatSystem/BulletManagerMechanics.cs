using Atomic;
using Core;
using UnityEngine;

namespace Mechanics
{
    public class BulletManagerMechanics
    {
        private readonly AtomicVariable<bool> _canShoot;
        private readonly AtomicVariable<int> _bulletCurrentAmount;
        private readonly AtomicVariable<int> _bulletMaxAmount;
        private AtomicVariable<float> _bulletReloadCooldown;
        private AtomicVariable<float> _bulletReloadTimer;
        private readonly AtomicEvent _fireEvent;
        
        private float _spawnTimer = 0;
        private float _spawnInterval = 2;

        public BulletManagerMechanics(
            AtomicVariable<bool> canShoot,
            AtomicVariable<int> bulletCurrentAmount,
            AtomicVariable<int> bulletMaxAmount,
            AtomicVariable<float> bulletReloadCooldown,
            AtomicVariable<float> bulletReloadTimer,
            AtomicEvent fireEvent
        )
        {
            _canShoot = canShoot;
            _bulletCurrentAmount = bulletCurrentAmount;
            _bulletMaxAmount = bulletMaxAmount;
            _bulletReloadCooldown = bulletReloadCooldown;
            _bulletReloadTimer = bulletReloadTimer;
            _fireEvent = fireEvent;
        }

        public void Update()
        {
            if (_bulletCurrentAmount.Value >= _bulletMaxAmount.Value)
            {
                return;
            }
            
            _bulletReloadTimer.Value += Time.deltaTime;

            if (_bulletReloadTimer.Value >= _bulletReloadCooldown.Value)
            {
                _bulletCurrentAmount.Value++;
                _canShoot.Value = true;
                _bulletReloadTimer.Value = 0.0f;
            }

            if (_bulletCurrentAmount.Value == 0)
            {
                _canShoot.Value = false;
            }

            _canShoot.Value = true;
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
            _bulletCurrentAmount.Value--;
            _bulletCurrentAmount.Value = Mathf.Max(0, _bulletCurrentAmount.Value);
        }
    }
}