using Atomic;
using Character;
using TMPro;
using UnityEngine;
using Zenject;
using Zombie;

namespace Visual.Zombie
{
    public class ZombieAnimatorController
    {
        private static readonly int MainState = Animator.StringToHash("MainState");
        private static readonly int AttackTrigger = Animator.StringToHash("Attack");

        private const int IDLE = 0;
        private const int Move = 1;
        private const int Attack = 1;
        private const int Death = 2;

        private readonly ZombieModel _zombie;
        private readonly Animator _animator;
        private readonly AtomicEvent _attackRequest;
        
        private float _spawnTimer = 0.0f;
        private float _spawnInterval = 2f;

        public ZombieAnimatorController(
            ZombieModel zombie,
            Animator animator,
            AtomicEvent attackRequest
        )
        {
            _zombie = zombie;
            _animator = animator;
            _attackRequest = attackRequest;
        }
        
        public void OnEnable()
        {
            _attackRequest.Subscribe(OnAttackRequested);
        }

        public void OnDisable()
        {
            _attackRequest.UnSubscribe(OnAttackRequested);
        }

        private void OnAttackRequested()
        {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= _spawnInterval)
            {
                _animator.SetTrigger(AttackTrigger);
                _spawnTimer = 0.0f;
            }
        }


        public void Update()
        {
            var animationValue = GetAnimationValue();
            _animator.SetInteger(MainState, animationValue);
        }

        private int GetAnimationValue()
        {
            if (_zombie.isDead.Value)
            {
                return Death;
            }

            if (_zombie.moveDirection.Value != Vector3.zero)
            {
                return Move;
            }

            return IDLE;
        }
    }
}