using Atomic;
using Core;
using Mechanics;
using Mechanics.MovementSystem;
using UnityEngine;
using AtomicEvent = Atomic.AtomicEvent;

namespace Zombie
{
    public class ZombieModel : MonoBehaviour, ICharacter
    {
        //Data
        public AtomicVariable<int> hitPoints;
        public AtomicEvent<int> takeDamageEvent;
        public AtomicEvent attackEvent;
        public AtomicVariable<int> damage;
        public AtomicEvent deathEvent;
        public AtomicVariable<bool> isDead;
        public AtomicEvent zombieDeathEvent;

        public AtomicVariable<bool> attackDistanceReached;

        public Transform playerTransform;
        public AtomicVariable<Vector3> moveDirection;
        public AtomicVariable<float> speed;
        public AtomicVariable<bool> canMove;
        public AtomicVariable<Vector3> rotationTargetPoint = new();
        public AtomicVariable<int> rotationSpeed = new();

        // Logic
        private MovementMechanics _movementMechanics;
        private RotateMechanics _rotateMechanics;
        private FollowTargetMechanics _followTargetMechanics;

        private TakeDamageMechanics _takeDamageMechanics;
        private DeathMechanics _deathMechanics;
        private CanMoveMechanics _canMoveMechanics;
        private AttackMechanics _attackMechanics;
        private KillCountMechanics _killCountMechanics;


        private void Awake()
        {
            playerTransform = GameObject.FindWithTag("Player").transform;
            
            hitPoints.Value = 1;
            damage.Value = 1;

            speed.Value = 3;
            rotationSpeed.Value = 5;
            canMove.Value = true;

            var zombieTransform = transform;

            _movementMechanics = new MovementMechanics(speed, moveDirection, zombieTransform, canMove);
            _rotateMechanics = new RotateMechanics(
                rotationTargetPoint, zombieTransform, rotationSpeed
            );
            _followTargetMechanics = new FollowTargetMechanics(
                playerTransform, zombieTransform, moveDirection, attackEvent, attackDistanceReached
            );

            _takeDamageMechanics = new TakeDamageMechanics(this, hitPoints, takeDamageEvent, deathEvent);
            _deathMechanics = new DeathMechanics(isDead, deathEvent);
            _canMoveMechanics = new CanMoveMechanics(isDead, canMove);

            _attackMechanics = new AttackMechanics(attackEvent, damage, playerTransform);
            _killCountMechanics = new KillCountMechanics(playerTransform, this);
        }

        private void Update()
        {
            if (isDead.Value)
            {
                return;
            }

            _rotateMechanics.Update();
            _followTargetMechanics.Update();
            _movementMechanics.Update();
        }

        public void OnEnable()
        {
            if (isDead.Value)
            {
                return;
            }

            _attackMechanics.OnEnable();
            _canMoveMechanics.OnEnable();
            _deathMechanics.OnEnable();
            _takeDamageMechanics.OnEnable();
            _killCountMechanics.OnEnable();
        }

        public void OnDisable()
        {
            _attackMechanics.OnDisable();
            _canMoveMechanics.OnDisable();
            _deathMechanics.OnDisable();
            _takeDamageMechanics.OnDisable();
            _killCountMechanics.OnDisable();
        }
    }
}