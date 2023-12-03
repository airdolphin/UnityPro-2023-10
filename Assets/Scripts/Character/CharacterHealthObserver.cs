using UnityEngine;

namespace ShootEmUp
{
    public class CharacterHealthObserver: MonoBehaviour
    {
        [SerializeField] private HitPointsComponent characterHitPoints;
        [SerializeField] private GameManager gameManager;

        public void OnEnable()
        {
            characterHitPoints.OnHitPointsEmpty += OnHitPointsEmpty;
        }

        public void OnDisable()
        {
            characterHitPoints.OnHitPointsEmpty -= OnHitPointsEmpty;
        }

        private void OnHitPointsEmpty(GameObject _)
        {
            gameManager.FinishGame();
        }
    }
}