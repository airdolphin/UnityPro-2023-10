using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemySpawnController : MonoBehaviour,
        GameListeners.IGameStartListener,
        GameListeners.IGameFinishListener
    {
        [SerializeField] private EnemyManager enemyManager;

        private Coroutine spawnEnemy;

        public void OnStart()
        {
            spawnEnemy = StartCoroutine(SpawnEnemy());
        }

        public void OnFinish()
        {
            StopCoroutine(spawnEnemy);
        }

        private IEnumerator SpawnEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                enemyManager.Spawn();
            }
        }
    }
}