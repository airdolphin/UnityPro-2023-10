using Atomic;
using Core;
using UnityEngine;

namespace Visual
{
    public class CharacterAnimatorController
    {
        private static readonly int MainState = Animator.StringToHash("MainState");
        private static readonly int ShootTrigger = Animator.StringToHash("Shoot");

        private const int IDLE = 0;
        private const int Move = 1;
        private const int Death = 2;

        private readonly AtomicVariable<Vector3> _moveDirection;
        private readonly AtomicVariable<bool> _isDead;
        private readonly Animator _animator;
        private readonly AtomicEvent _fireRequest;

        public CharacterAnimatorController(
            AtomicVariable<Vector3> moveDirection,
            AtomicVariable<bool> isDead,
            Animator animator,
            AtomicEvent fireRequest
        )
        {
            _moveDirection = moveDirection;
            _isDead = isDead;
            _animator = animator;
            _fireRequest = fireRequest;
        }

        public void OnEnable()
        {
            _fireRequest.Subscribe(OnFireRequested);
        }

        public void OnDisable()
        {
            _fireRequest.UnSubscribe(OnFireRequested);
        }

        private void OnFireRequested()
        {
            _animator.SetTrigger(ShootTrigger);
        }

        public void Update()
        {
            var animationValue = GetAnimationValue();
            _animator.SetInteger(MainState, animationValue);
        }

        private int GetAnimationValue()
        {
            if (_isDead.Value)
            {
                return Death;
            }

            if (_moveDirection.Value != Vector3.zero)
            {
                return Move;
            }

            return IDLE;
        }
    }
}