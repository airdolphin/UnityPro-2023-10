using Character;
using UnityEngine;
using Zombie;

namespace Mechanics
{
    public class KillCountMechanics
    {
        private readonly CharacterModel _character;
        private readonly ZombieModel _zombie;

        public KillCountMechanics(Transform characterTransform, ZombieModel zombie)
        {
            _character = characterTransform.GetComponent<CharacterModel>();
            _zombie = zombie;
        }

        public void OnEnable()
        {
            _zombie.zombieDeathEvent.Subscribe(OnDeath);
        }

        public void OnDisable()
        {
            _zombie.zombieDeathEvent.UnSubscribe(OnDeath);
        }

        private void OnDeath()
        {
            _character.killCount.Value += 1;
        }
    }
}