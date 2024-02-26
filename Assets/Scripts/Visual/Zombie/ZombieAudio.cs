using System;
using UnityEngine;
using Zombie;

namespace Visual.Zombie
{
    public class ZombieAudio : MonoBehaviour
    {
        [SerializeField] private ZombieModel _zombie;
        [SerializeField] private AudioSource _damageAudio;
        [SerializeField] private AudioSource _attackAudio;

        private void OnEnable()
        {
            _zombie.takeDamageEvent.Subscribe(OnTakeDamage);
            _zombie.attackEvent.Subscribe(OnAttack);
        }

        private void OnDisable()
        {
            _zombie.takeDamageEvent.UnSubscribe(OnTakeDamage);
            _zombie.attackEvent.UnSubscribe(OnAttack);
        }

        private void OnTakeDamage(int obj)
        {
            _damageAudio.Play();
        }
        
        private void OnAttack()
        {
            _attackAudio.Play();
        }

    }
}