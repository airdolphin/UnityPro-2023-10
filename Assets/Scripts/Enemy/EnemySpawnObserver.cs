using UnityEngine;
using System;

namespace ShootEmUp
{
    [Serializable]
    // Перенести в Enemy
    public class EnemySpawnObserver :
        GameListeners.IGameStartListener,
        GameListeners.IGameFinishListener
    {
        [SerializeField] private GameObject player;
        private EnemyPool enemyPool;
        
        [Inject]
        public void Construct(EnemyPool _enemyPool)
        {
            enemyPool = _enemyPool;
        }

        public void OnStart()
        {
            enemyPool.OnEnemySpawned += OnEnemySpawn;
        }

        public void OnFinish()
        {
            enemyPool.OnEnemySpawned -= OnEnemySpawn;
        }

        private void OnEnemySpawn(Enemy enemy)
        {
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(player);
        }
    }
}