using UnityEngine;

namespace ShootEmUp
{
    public sealed class Enemy : MonoBehaviour
    {
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private HitPointsComponent _character;
        [SerializeField] private BulletConfig _bulletConfig;
        
        private EnemyAttackAgent _enemyAttackAgent;
        private EnemyMoveAgent _enemyMoveAgent;
        private EnemyActionController _enemyActionController;
        
        public void Construct(
            GameManager gameManager,
            BulletSystem bulletSystem,
            Vector3 attackPositionPosition
            )
        {
            _enemyMoveAgent = new EnemyMoveAgent(_moveComponent,transform);
            _enemyAttackAgent = new EnemyAttackAgent(_weaponComponent, bulletSystem, _bulletConfig);
            
            _enemyMoveAgent.SetDestination(attackPositionPosition);
            _enemyAttackAgent.SetTarget(_character);
            
            _enemyActionController = new EnemyActionController(
                gameManager, _enemyAttackAgent, _enemyMoveAgent
                );
        }
        
        public void Initialize()
        {
            _enemyActionController.Initialize();
        }

        public void Dispose()
        {
            _enemyActionController.Dispose();
        }
    }
}