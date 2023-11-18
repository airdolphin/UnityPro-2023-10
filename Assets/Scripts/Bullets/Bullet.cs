using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        public bool IsPlayer { get; private set; }
        public int Damage { get; private set; }

        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }

        private void SetVelocity(Vector2 velocity)
        {
            rigidbody2D.velocity = velocity;
        }

        private void SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
        }

        private void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        private void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }

        private void SetDamage(int damage)
        {
            Damage = damage;
        }

        private void SetIsPlayer(bool isPlayer)
        {
            IsPlayer = isPlayer;
        }

        public void Init(
            bool isPlayer, int damage, Vector2 velocity, int physicsLayer, Vector3 position, Color color
        )
        {
            SetIsPlayer(isPlayer);
            SetDamage(damage);
            SetVelocity(velocity);
            SetPhysicsLayer(physicsLayer);
            SetPosition(position);
            SetColor(color);
        }
    }
}