using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class CharacterFireController :
        GameListeners.IGameStartListener,
        GameListeners.IGameResumeListener,
        GameListeners.IGameFinishListener,
        GameListeners.IGamePauseListener
    {
        private KeyboardInput _inputManager;
        private CharacterFireInteractor _characterFireInteractor;

        [Inject]
        public void Construct(KeyboardInput inputManager, CharacterFireInteractor characterFireInteractor)
        {
            _inputManager = inputManager;
            _characterFireInteractor = characterFireInteractor;
        }

        private void OnFire()
        {
            _characterFireInteractor.Fire();
        }

        public void OnStart()
        {
            _inputManager.OnFire += OnFire;
        }

        public void OnFinish()
        {
            _inputManager.OnFire -= OnFire;
        }

        public void OnResume()
        {
            _inputManager.OnFire += OnFire;
        }

        public void OnPause()
        {
            _inputManager.OnFire -= OnFire;
        }
    }
}