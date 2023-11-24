using UnityEngine;

namespace ShootEmUp
{
    public class CharacterHealthObserver: MonoBehaviour
    {
        [SerializeField] private HitPointsComponent characterHitPoints;
        [SerializeField] private GameManager gameManager;

        public void OnEnable()
        {
            characterHitPoints.OnHitPointsEmpty += OnOnHitPointsEmpty;
        }

        public void OnDisable()
        {
            characterHitPoints.OnHitPointsEmpty -= OnOnHitPointsEmpty;
        }

        private void OnOnHitPointsEmpty(GameObject _)
        {
            gameManager.FinishGame();
        }
    }
}