using System;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterHealthObserver: MonoBehaviour
    {
        [SerializeField] private HitPointsComponent characterHitPoints;
        [SerializeField] private GameManager gameManager;

        public void OnEnable()
        {
            characterHitPoints.HpEmpty += OnHpEmpty;
        }

        public void OnDisable()
        {
            characterHitPoints.HpEmpty -= OnHpEmpty;
        }

        private void OnHpEmpty(GameObject _)
        {
            gameManager.FinishGame();
        }
    }
}