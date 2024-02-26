using Atomic;
using UnityEngine;

namespace Mechanics
{
    public class LifeTimeMechanics
    {
        private readonly AtomicVariable<float> _lifeTime;
        private readonly AtomicEvent _deathEvent;

        public LifeTimeMechanics(AtomicVariable<float> lifeTime, AtomicEvent deathEvent)
        {
            _lifeTime = lifeTime;
            _deathEvent = deathEvent;
        }

        public void Update()
        {
            _lifeTime.Value -= Time.deltaTime;

            if (_lifeTime.Value <= 0)
            {
                _deathEvent.Invoke();
            }
        }
    }
}