using System;

namespace ShootEmUp
{
    [Serializable]
    public class EnemySpawnController :
        GameListeners.IGameStartListener,
        GameListeners.IGameFinishListener,
        GameListeners.IGameUpdateListener
    {
        private EnemyManager _enemyManager;

        private int _timeBetweenSpawn = 1;
        private float _enemуSpawnedTime;
        private bool _spawnStatus = true;

        
        [Inject]
        public void Construct(EnemyManager enemyManager)
        {
            _enemyManager = enemyManager;
        }

        public void OnStart()
        {
            _spawnStatus = true;
        }

        public void OnFinish()
        {
            _spawnStatus = false;
        }

        public void OnUpdate(float timeDelta)
        {
            if (!_spawnStatus)
            {
                return;
            }
            
            _enemуSpawnedTime += timeDelta;

            if (_enemуSpawnedTime > _timeBetweenSpawn)
            {
                _enemyManager.Spawn();
                _enemуSpawnedTime = 0;
            }
        }
    }
}