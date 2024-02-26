using Character;
using UnityEngine;

namespace Visual
{
    public class CharacterVFX : MonoBehaviour
    {
        [SerializeField] private CharacterModel _character;
        [SerializeField] private ParticleSystem _damageVFX;
        
        public void OnEnable()
        {
            _character.takeDamageEvent.Subscribe(OnTakeDamage);
        }

        public void OnDisable()
        {
            _character.takeDamageEvent.UnSubscribe(OnTakeDamage);
        }


        private void OnTakeDamage(int damage)
        {
            _damageVFX.Play();
        }
        
    }
}