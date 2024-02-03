namespace ShootEmUp
{
    public class EnemyActionController :
        GameListeners.IGameFixedUpdateListener
    {
        private readonly GameManager _gameManager;
        private readonly EnemyAttackAgent _enemyAttackAgent;
        private readonly EnemyMoveAgent _enemyMoveAgent;

        public EnemyActionController(
            GameManager gameManager,
            EnemyAttackAgent enemyAttackAgent,
            EnemyMoveAgent enemyMoveAgent
        )
        {
            _gameManager = gameManager;
            _enemyAttackAgent = enemyAttackAgent;
            _enemyMoveAgent = enemyMoveAgent;
        }

        public void Initialize()
        {
            _gameManager.AddListener(this);
            _gameManager.AddListener(_enemyMoveAgent);
        }

        public void Dispose()
        {
            _gameManager.RemoveListener(this);
            _gameManager.RemoveListener(_enemyMoveAgent);
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (_enemyMoveAgent.IsReached)
            {
                _enemyAttackAgent.OnFixedUpdate(deltaTime);
            }
        }
    }
}