using Character;
using UnityEngine;

namespace Visual
{
    public class CharacterVisual : MonoBehaviour
    {
        // data
        [SerializeField] private CharacterModel _character;
        [SerializeField] private Animator _animator;

        // logic
        private CharacterAnimatorController _characterAnimatorController;

        private void Awake()
        {
            _characterAnimatorController = new CharacterAnimatorController(
                _character.moveDirection,
                _character.isDead,
                _animator,
                _character.fireRequest
            );
        }
        
        private void OnEnable()
        {
            _characterAnimatorController.OnEnable();
        }

        private void OnDisable()
        {
            _characterAnimatorController.OnDisable();
        }

        public void Update()
        {
            _characterAnimatorController.Update();
        }
        
    }
}