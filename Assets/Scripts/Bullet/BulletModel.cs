using UnityEngine;
using Atomic;
using Mechanics;

namespace Bullet
{
    public class BulletModel : MonoBehaviour
    {
        // data
        public AtomicVariable<float> speed;
        public AtomicVariable<Vector3> moveDirection;
        
        public AtomicVariable<bool> canMove;
        
        public AtomicVariable<int> damage;
        public AtomicVariable<float> lifeTime;
        public AtomicEvent deathEvent;
        
        // logic
        private MovementMechanics _movementMechanics;
        private BulletCollisionMechanics _bulletCollisionMechanics;
        private LifeTimeMechanics _lifeTimeMechanics;
        private DestroyMechanics _destroyMechanics;
        
        private void Awake()
        {
            canMove.Value = true;
            speed.Value = 10;
            lifeTime.Value = 50;
            damage.Value = 1;
            
            _movementMechanics = new MovementMechanics(speed, moveDirection, transform, canMove);
            _bulletCollisionMechanics = new BulletCollisionMechanics(damage, deathEvent);
            _lifeTimeMechanics = new LifeTimeMechanics(lifeTime, deathEvent);
            _destroyMechanics = new DestroyMechanics(deathEvent, gameObject);
        }
        
        private void OnEnable()
        {
            _destroyMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _destroyMechanics.OnDisable();
        }

        private void Update()
        {
            _movementMechanics.Update();
            _lifeTimeMechanics.Update();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            _bulletCollisionMechanics.OnTriggerEnter(other);
        }
    }
}