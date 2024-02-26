using Atomic;
using Core;
using UnityEngine;
using Zombie;

namespace Mechanics
{
    public class TakeDamageMechanics
    {
        private readonly ICharacter _damageTarget;
        private readonly AtomicVariable<int> _hitPoints;
        private readonly AtomicEvent<int> _takeDamageEvent;
        private readonly AtomicEvent _deathEvent;

        public TakeDamageMechanics(
            ICharacter damageTarget,
            AtomicVariable<int> hitPoints, AtomicEvent<int> takeDamageEvent, AtomicEvent deathEvent
        )
        {
            _damageTarget = damageTarget; 
            _hitPoints = hitPoints;
            _takeDamageEvent = takeDamageEvent;
            _deathEvent = deathEvent;
        }

        public void OnEnable()
        {
            _takeDamageEvent.Subscribe(OnTakeDamage);
        }

        public void OnDisable()
        {
            _takeDamageEvent.UnSubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(int damage)
        {
            if (_damageTarget is ZombieModel zombieModel && zombieModel.isDead.Value)
            {
                return;
            }
            
            var hitPoint = _hitPoints.Value - damage;
            _hitPoints.Value = Mathf.Max(0, hitPoint);
            
            if (_hitPoints.Value == 0)
            {
                if (_damageTarget is ZombieModel)
                {
                    ((ZombieModel)_damageTarget).zombieDeathEvent?.Invoke();
                }
                _deathEvent?.Invoke();
            }
        }
    }
}