using UnityEngine;

namespace ShootEmUp

{
    public class EnemyInstaller : GameInstaller
    {
        [SerializeField, Listener, Service(typeof(EnemyPool))]
        private EnemyPool enemyPool;

        [SerializeField, Listener, Service(typeof(EnemySpawnObserver))]
        private EnemySpawnObserver enemySpawnObserver = new();
        
        [SerializeField, Listener, Service(typeof(EnemyPositions))]
        private EnemyPositions enemyPositions = new();
        
        [SerializeField, Listener]
        private EnemySpawnController enemySpawnController = new();
        
        [SerializeField, Listener, Service(typeof(EnemyManager))]
        private EnemyManager enemyManager;
    }
}