using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterFireObserver : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private CharacterController characterController;

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
            characterController.Fire();
        }
    }
}