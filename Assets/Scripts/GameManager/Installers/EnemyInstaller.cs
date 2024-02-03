using UnityEngine;

namespace ShootEmUp

{
    public class EnemyInstaller : GameInstaller
    {
        [SerializeField, Listener, Service(typeof(EnemyPool))]
        private EnemyPool _enemyPool;

        [SerializeField, Listener, Service(typeof(EnemyPositions))]
        private EnemyPositions _enemyPositions = new();
        
        [SerializeField, Listener]
        private EnemySpawnController _enemySpawnController = new();
        
        [SerializeField, Listener, Service(typeof(EnemyManager))]
        private EnemyManager _enemyManager;
    }
}