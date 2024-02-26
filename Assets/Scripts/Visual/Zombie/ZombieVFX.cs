using UnityEngine;
using Zombie;

namespace Visual.Zombie
{
    public sealed class ZombieVFX : MonoBehaviour
    {
        [SerializeField] private ZombieModel _zombie;
        [SerializeField] private ParticleSystem _zombieDamageVFX;

        public void OnEnable()
        {
            _zombie.takeDamageEvent.Subscribe(OnTakeDamage);
        }

        public void OnDisable()
        {
            _zombie.takeDamageEvent.UnSubscribe(OnTakeDamage);
        }


        private void OnTakeDamage(int damage)
        {
            _zombieDamageVFX.Play();
        }
    }
}