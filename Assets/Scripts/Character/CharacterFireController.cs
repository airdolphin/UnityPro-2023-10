using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterFireController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private CharacterFireInteractor characterFireInteractor;

        private void OnEnable()
        {
            inputManager.FireEvent += OnFireEvent;
        }

        private void OnDisable()
        {
            inputManager.FireEvent -= OnFireEvent;
        }

        private void OnFireEvent()
        {
            characterFireInteractor.Fire();
        }
    }
}