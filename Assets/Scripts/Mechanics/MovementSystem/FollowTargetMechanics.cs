using Atomic;
using Character;
using UnityEngine;
using Zombie;

namespace Mechanics
{
    public class FollowTargetMechanics
    {
        private readonly Transform _target;
        private readonly Transform _entity;
        private readonly AtomicVariable<Vector3> _moveDirection;
        private readonly AtomicEvent _attackEvent;
        
        private readonly AtomicVariable<bool> _attackDistanceReached;
        
        public FollowTargetMechanics(
            Transform target,
            Transform entity,
            AtomicVariable<Vector3> moveDirection,
            AtomicEvent attackEvent,
            AtomicVariable<bool> attackDistanceReached
        )
        {
            _target = target;
            _entity = entity;
            _moveDirection = moveDirection;
            _attackEvent = attackEvent;
            _attackDistanceReached = attackDistanceReached;
        }
        
        public void Update()
        {
            if (_target == null || _target.GetComponent<CharacterModel>().isDead.Value)
            {
                _entity.GetComponent<ZombieModel>().canMove.Value = false;
                return;
            }

            var direction = _target.position - _entity.position;
            var distance = direction.magnitude;

            if (distance <= 1.5f)
            {
                _entity.LookAt(new Vector3(
                    _target.position.x, _entity.position.y, _target.position.z)
                );
                _moveDirection.Value = Vector3.zero;
                _attackDistanceReached.Value = true;
                _attackEvent.Invoke();
            }
            else
            {
                _entity.LookAt(new Vector3(
                    _target.position.x, _entity.position.y, _target.position.z)
                );
                _moveDirection.Value = direction.normalized;
                _attackDistanceReached.Value = false;
            }
        }
    }
}