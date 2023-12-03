using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private BulletConfig bulletConfig;

        private readonly HashSet<Enemy> activeEnemies = new();

        private int delaySpawnTime = 1;

        public void Spawn()
        {
            Enemy enemy = enemyPool.TrySpawnEnemy();

            if (activeEnemies.Add(enemy))
            {
                var enemyMoveAgent = enemy.GetComponent<EnemyMoveAgent>();
                var enemyAttackAgent = enemy.GetComponent<EnemyAttackAgent>();
                
                gameManager.AddListener(enemyMoveAgent);
                gameManager.AddListener(enemyAttackAgent);
                
                enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty += OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            Enemy enemyComponent = enemy.GetComponent<Enemy>();

            if (activeEnemies.Remove(enemyComponent))
            {
                enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty -= OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnFire -= OnFire;

                enemyPool.UnspawnEnemy(enemyComponent);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int)bulletConfig.physicsLayer,
                color = bulletConfig.color,
                damage = bulletConfig.damage,
                position = position,
                velocity = direction * bulletConfig.speed
            });
        }
    }
}