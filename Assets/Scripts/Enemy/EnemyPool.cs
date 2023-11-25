using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private Transform worldTransform;

        [Header("Pool")] 
        [SerializeField] private Transform container;
        [SerializeField] private Enemy prefab;
        [SerializeField] private int enemyCount = 50;

        private Pool<Enemy> enemyPool;
        public event Action<Enemy> OnEnemySpawned;

        private void Awake()
        {
            enemyPool = new Pool<Enemy>(prefab, enemyCount, container);
        }

        public Enemy TrySpawnEnemy()
        {
            Enemy enemy = enemyPool.Get();
            InitializeEnemy(enemy);
            return enemy;
        }

        private void InitializeEnemy(Enemy enemy)
        {
            enemy.transform.SetParent(worldTransform);
            var spawnPosition = enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            var attackPosition = enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            OnEnemySpawned?.Invoke(enemy);
        }

        public void UnspawnEnemy(Enemy enemy)
        {
            enemyPool.Release(enemy);
            enemy.transform.SetParent(container);
        }
    }
}