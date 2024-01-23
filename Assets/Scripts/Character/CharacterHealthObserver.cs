using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public class CharacterHealthObserver :
        GameListeners.IGameStartListener,
        GameListeners.IGameFinishListener
    {
        private HitPointsComponent _characterHitPoints;
        private GameManager _gameManager;
        
        [Inject]
        private void Construct(GameManager gameManager, CharacterService characterService)
        {
            _gameManager = gameManager;
            _characterHitPoints = characterService.Character.GetComponent<HitPointsComponent>();
        }

        public void OnStart()
        {
            _characterHitPoints.OnHitPointsEmpty += OnHitPointsEmpty;
        }

        public void OnFinish()
        {
            _characterHitPoints.OnHitPointsEmpty -= OnHitPointsEmpty;
        }

        private void OnHitPointsEmpty(GameObject _)
        {
            _gameManager.FinishGame();
        }
    }
}