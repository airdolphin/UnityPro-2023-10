using UnityEngine;

namespace Zombie
{
    public class ZombieSpawnController : MonoBehaviour
    {
        [SerializeField] private float _spawnTimer;
        [SerializeField] private float _spawnInterval;
        [SerializeField] private ZombieSpawner _zombiesSpawner;

        private int _zombieCount;
        
        private void Awake()
        {
            var _zombieCount = 0;
            _spawnTimer = 0;
            _spawnInterval = 2;
        }

        private void Update()
        {
            _spawnTimer += Time.deltaTime;

            if (_spawnTimer >= _spawnInterval)
            {
                SpawnZombie();
                _spawnTimer = 0.0f;
            }
        }

        private void SpawnZombie()
        {
            if (_zombieCount == 10)
            {
                return;
            }

            _zombiesSpawner.Spawn();
            _zombieCount += 1;
        }
    }
}