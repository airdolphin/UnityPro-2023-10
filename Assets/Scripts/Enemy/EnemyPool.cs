using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    [Serializable]
    public sealed class EnemyPool :
        GameListeners.IGameStartListener

    {
        [Header("Spawn")] [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private Transform _worldTransform;

        [Header("Pool")] [SerializeField] private Transform _container;
        [SerializeField] private Enemy _prefab;
        [SerializeField] private int _enemyCount = 7;

        private GameManager _gameManager;
        private BulletSystem _bulletSystem;
        private Pool<Enemy> _enemyPool;

        public void OnStart()
        {
            _enemyPool = new Pool<Enemy>(_prefab, _enemyCount, _container);
        }

        [Inject]
        public void Construct(GameManager gameManager, BulletSystem bulletSystem)
        {
            _gameManager = gameManager;
            _bulletSystem = bulletSystem;
        }

        public Enemy TrySpawnEnemy()
        {
            Enemy enemy = _enemyPool.Get();
            InitializeEnemy(enemy);
            return enemy;
        }

        private void InitializeEnemy(Enemy enemy)
        {
            enemy.transform.SetParent(_worldTransform);
            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            var attackPosition = _enemyPositions.RandomAttackPosition();

            enemy.Construct(_gameManager, _bulletSystem, attackPosition.position);
        }

        public void UnspawnEnemy(Enemy enemy)
        {
            _enemyPool.Release(enemy);
            enemy.transform.SetParent(_container);
        }
    }
}