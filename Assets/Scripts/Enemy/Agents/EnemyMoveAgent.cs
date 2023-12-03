using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour,
        GameListeners.IGameFixedUpdateListener
    {
        [SerializeField] private MoveComponent moveComponent;

        public bool IsReached { get; private set; }
        private Vector2 destination;
        private float targetDistance = 0.25f;

        public void SetDestination(Vector2 endPoint)
        {
            destination = endPoint;
            IsReached = false;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (IsReached)
            {
                return;
            }

            var vector = destination - (Vector2)transform.position;
            if (vector.magnitude <= targetDistance)
            {
                IsReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            moveComponent.Move(direction);
        }
    }
}