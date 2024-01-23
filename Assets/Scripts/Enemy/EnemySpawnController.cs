using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public class EnemySpawnController :
        GameListeners.IGameStartListener,
        GameListeners.IGameFinishListener,
        GameListeners.IGameUpdateListener
    {
        private EnemyManager enemyManager;

        private int timeBetweenSpawn = 1;
        private float enemуSpawnedTime;
        private bool spawnStatus = true;

        
        [Inject]
        public void Construct(EnemyManager _enemyManager)
        {
            enemyManager = _enemyManager;
        }

        public void OnStart()
        {
            spawnStatus = true;
        }

        public void OnFinish()
        {
            spawnStatus = false;
        }

        public void OnUpdate(float timeDelta)
        {
            // DEBUG: STOP SPAWN
            // spawnStatus = false;
            
            if (!spawnStatus)
            {
                return;
            }
            
            enemуSpawnedTime += timeDelta;

            if (enemуSpawnedTime > timeBetweenSpawn)
            {
                enemyManager.Spawn();
                enemуSpawnedTime = 0;
            }
        }
    }
}