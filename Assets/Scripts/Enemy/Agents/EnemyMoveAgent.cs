using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : GameListeners.IGameFixedUpdateListener
    {
        public bool IsReached { get; private set; }
        
        private MoveComponent _moveComponent;
        private Vector2 _destination;
        private readonly Transform _transform;
        private float _targetDistance = 0.25f;

        public EnemyMoveAgent(MoveComponent moveComponent, Transform transform)
        {
            _moveComponent = moveComponent;
            _transform = transform;
        }

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            IsReached = false;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (IsReached)
            {
                return;
            }

            var vector = _destination - (Vector2)_transform.position;
            if (vector.magnitude <= _targetDistance)
            {
                IsReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            _moveComponent.Move(direction);
        }
    }
}