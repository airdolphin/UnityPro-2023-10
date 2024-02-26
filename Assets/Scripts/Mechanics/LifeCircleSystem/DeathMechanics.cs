using Atomic;

namespace Mechanics
{
    public class DeathMechanics
    {
        private readonly AtomicVariable<bool> _isDead;
        private readonly AtomicEvent _deathEvent;

        public DeathMechanics(AtomicVariable<bool> isDead, AtomicEvent deathEvent)
        {
            _isDead = isDead;
            _deathEvent = deathEvent;
        }

        public void OnEnable()
        {
            _deathEvent.Subscribe(OnDeath);
        }

        public void OnDisable()
        {
            _deathEvent.UnSubscribe(OnDeath);
        }

        private void OnDeath()
        {
            if (_isDead.Value)
            {
                return;
            }

            _isDead.Value = true;
        }
        
    }
}