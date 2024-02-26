using Atomic;
using UnityEngine;

namespace Mechanics
{
    public class DestroyMechanics
    {
        private readonly AtomicEvent _deathEvent;
        private readonly GameObject _gameObject;

        public DestroyMechanics(AtomicEvent deathEvent, GameObject gameObject)
        {
            _deathEvent = deathEvent;
            _gameObject = gameObject;
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
            Object.Destroy(_gameObject);
        }
    }
}