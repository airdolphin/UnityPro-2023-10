using UnityEngine;

namespace ShootEmUp
{
    public class EnemySpawnObserver : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private EnemyPool enemyPool;

        private void OnEnable()
        {
            enemyPool.OnEnemySpawned += OnEnemySpawn;
        }

        private void OnDisable()
        {
            enemyPool.OnEnemySpawned -= OnEnemySpawn;
        }

        private void OnEnemySpawn(Enemy enemy)
        {
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(player);
        }
    }
}