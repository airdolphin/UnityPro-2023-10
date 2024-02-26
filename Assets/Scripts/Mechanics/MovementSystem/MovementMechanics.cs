using UnityEngine;

namespace Atomic
{
    public class MovementMechanics
    {
        private readonly AtomicVariable<float> _speed;
        private readonly AtomicVariable<Vector3> _moveDirection;
        private readonly AtomicVariable<bool> _canMove;
        private readonly Transform _target;

        public MovementMechanics(
            AtomicVariable<float> speed,
            AtomicVariable<Vector3> moveDirection,
            Transform target,
            AtomicVariable<bool> canMove
            )
        {
            _speed = speed;
            _moveDirection = moveDirection;
            _target = target;
            _canMove = canMove;
        }

        public void Update()
        {
            if (!_canMove.Value)
            {
                return;
            }
            
            _target.position += _moveDirection.Value * _speed.Value * Time.deltaTime;
        }
    }
}