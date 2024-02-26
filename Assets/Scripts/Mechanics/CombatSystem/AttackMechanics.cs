using Atomic;
using Character;
using UnityEngine;

namespace Mechanics
{
    public class AttackMechanics
    {
        private readonly AtomicEvent _attackRequest;
        private readonly AtomicVariable<int> _damage;
        private readonly Transform _character;
        
        private float _spawnTimer = 0.0f;
        private float _spawnInterval = 1.5f;

        public AttackMechanics(
            AtomicEvent attackRequest, AtomicVariable<int> damage, Transform character
            )
        {
            _damage = damage;
            _attackRequest = attackRequest;
            _character = character;
        }

        public void OnEnable()
        {
            _attackRequest.Subscribe(Attack);
        }

        public void OnDisable()
        {
            _attackRequest.UnSubscribe(Attack);
        }

        private void Attack()
        {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= _spawnInterval)
            {
                _character.GetComponent<CharacterModel>().takeDamageEvent.Invoke(_damage.Value);
                _spawnTimer = 0.0f;
            }
        }
    }
} 