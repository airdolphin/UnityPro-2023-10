using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterFireController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private CharacterFireInteractor characterFireInteractor;

        private void OnEnable()
        {
            inputManager.OnFire += OnFire;
        }

        private void OnDisable()
        {
            inputManager.OnFire -= OnFire;
        }

        private void OnFire()
        {
            characterFireInteractor.Fire();
        }
    }
}