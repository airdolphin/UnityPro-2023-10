using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class EnemyManager
    {
        private EnemyPool _enemyPool;

        [Inject]
        public void Construct(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
        }

        public void Spawn()
        {
            Enemy enemy = _enemyPool.TrySpawnEnemy();

            enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty += OnDestroyed;
            enemy.Initialize();
        }

        private void OnDestroyed(GameObject enemy)
        {
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            
            enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty -= OnDestroyed;
            
            enemyComponent.Dispose();
            _enemyPool.UnspawnEnemy(enemyComponent);
        }
    }
}