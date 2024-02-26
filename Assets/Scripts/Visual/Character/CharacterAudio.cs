using Character;
using UnityEngine;

namespace Visual
{
    public class CharacterAudio : MonoBehaviour
    {
        [SerializeField] private CharacterModel _character;
        [SerializeField] private AudioSource _shootAudio;

        private void OnEnable()
        {
            _character.fireEvent.Subscribe(OnShoot);
        }

        private void OnDisable()
        {
            _character.fireEvent.UnSubscribe(OnShoot);
        }

        private void OnShoot()
        {
            _shootAudio.Play();
        }

    }
}