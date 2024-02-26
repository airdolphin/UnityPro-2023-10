using Atomic;
using UnityEngine;
using Zombie;

namespace Mechanics
{
    public class BulletCollisionMechanics
    {
        private readonly AtomicVariable<int> _damage;
        private readonly AtomicEvent _deathEvent;

        public BulletCollisionMechanics(AtomicVariable<int> damage, AtomicEvent deathEvent)
        {
            _damage = damage;
            _deathEvent = deathEvent;
        }

        public void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out ZombieModel target))
            {
                target.takeDamageEvent.Invoke(_damage.Value);
                _deathEvent.Invoke();
            }
        }
    }
}