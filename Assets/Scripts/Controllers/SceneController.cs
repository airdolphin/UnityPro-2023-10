using Character;
using UnityEngine;

namespace Controllers
{
    public class SceneController:MonoBehaviour
    {
        [SerializeField] private CharacterModel _characterModel;

        private void OnEnable()
        {
            _characterModel.deathEvent.Subscribe(OnPlayerDeath);
        }

        private void OnDisable()
        {
            _characterModel.deathEvent.UnSubscribe(OnPlayerDeath);
        }

        private void OnPlayerDeath()
        {
            Finish();
        }
        
        public void Finish()
        {
            // _characterModel.SetActive(false);
        }
    }
}