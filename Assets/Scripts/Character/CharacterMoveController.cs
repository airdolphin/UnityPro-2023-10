using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterMoveController : MonoBehaviour,
        GameListeners.IGameFixedUpdateListener
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private MoveComponent moveComponent;

        public void OnFixedUpdate(float deltaTime)
        {
            moveComponent.Move(
                new Vector2(inputManager.HorizontalDirection, 0) * Time.fixedDeltaTime
            );
        }
    }
}