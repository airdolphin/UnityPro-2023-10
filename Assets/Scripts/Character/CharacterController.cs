using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private WeaponComponent weapon;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private BulletConfig bulletConfig;
        
        [SerializeField] private InputManager inputManager;
        [SerializeField] private MoveComponent moveComponent;
        

        private void FixedUpdate()
        {
            Move();
        }

        public void Fire()
        {
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int)bulletConfig.physicsLayer,
                color = bulletConfig.color,
                damage = bulletConfig.damage,
                position = weapon.Position,
                velocity = weapon.Rotation * Vector3.up * bulletConfig.speed
            });
        }

        public void Move()
        {
            moveComponent.MoveByRigidbodyVelocity(
                new Vector2(inputManager.HorizontalDirection, 0) * Time.fixedDeltaTime
            );
        }
    }
}