using Atomic;
using Bullet;
using Core;
using Mechanics;
using UnityEngine;


namespace Character
{
    public class CharacterModel : MonoBehaviour, ICharacter
    {
        //Data:
        public AtomicVariable<int> hitPoints;
        public AtomicEvent<int> takeDamageEvent;
        public AtomicVariable<bool> isDead;
        public AtomicEvent deathEvent;
        public AtomicVariable<int> killCount = new();

        public AtomicVariable<float> speed;
        public AtomicVariable<bool> canMove;
        public AtomicVariable<Vector3> moveDirection;
        public AtomicVariable<Vector3> rotationTargetPoint = new();
        public AtomicVariable<int> rotationSpeed = new();

        public AtomicVariable<bool> canShoot;
        public AtomicEvent fireRequest;
        public AtomicEvent fireEvent;
        public Transform firePoint;
        public BulletModel bulletPrefab;
        public AtomicVariable<int> bulletCurrentAmount;
        public AtomicVariable<int> bulletMaxAmount;
        public AtomicVariable<float> bulletReloadCooldown;
        public AtomicVariable<float> bulletReloadTimer;

        //Logic:
        private MovementMechanics _movementMechanics;
        private RotateMechanics _rotateMechanics;
        private ShootMechanics _shootMechanics;

        private TakeDamageMechanics _takeDamageMechanics;
        private DeathMechanics _deathMechanics;
        private BulletManagerMechanics _bulletManagerMechanics;

        private void Awake()
        {
            killCount.Value = 0;
            canShoot.Value = true;

            hitPoints.Value = 10;
            speed.Value = 5;
            rotationSpeed.Value = 5;
            canMove.Value = true;
            var characterTransform = transform;

            _movementMechanics = new MovementMechanics(speed, moveDirection, characterTransform, canMove);
            _rotateMechanics = new RotateMechanics(rotationTargetPoint, transform, rotationSpeed);
            _shootMechanics = new ShootMechanics(
                canShoot, bulletCurrentAmount, fireEvent, firePoint, bulletPrefab, transform
            );

            _takeDamageMechanics = new TakeDamageMechanics(this, hitPoints, takeDamageEvent, deathEvent);
            _deathMechanics = new DeathMechanics(isDead, deathEvent);
            _bulletManagerMechanics = new BulletManagerMechanics(
                canShoot,
                bulletCurrentAmount,
                bulletMaxAmount,
                bulletReloadCooldown,
                bulletReloadTimer,
                fireEvent
            );
        }

        private void Update()
        {
            if (isDead.Value)
            {
                return;
                
            }
            
            _movementMechanics.Update();
            _rotateMechanics.Update();
            _bulletManagerMechanics.Update();
        }

        private void OnEnable()
        {
            _shootMechanics.OnEnable();
            _deathMechanics.OnEnable();
            _takeDamageMechanics.OnEnable();
            _bulletManagerMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _shootMechanics.OnDisable();
            _deathMechanics.OnDisable();
            _takeDamageMechanics.OnDisable();
            _bulletManagerMechanics.OnDisable();
        }
    }
}