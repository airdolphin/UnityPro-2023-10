using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : SerializedMonoBehaviour
    {
        [ShowInInspector] public GameState GameState { get; private set; }

        private readonly List<GameListeners.IGameListener> _listeners = new();
        private readonly List<GameListeners.IGameUpdateListener> _updateListeners = new();
        private readonly List<GameListeners.IGameFixedUpdateListener> _fixedUpdateListeners = new();
        private readonly List<GameListeners.IGameLateUpdateListener> _lateUpdateListeners = new();

        public void AddListeners(IEnumerable<GameListeners.IGameListener> listeners)
        {
            foreach (var listener in listeners)
            {
                AddListener(listener);
            }
        }

        public void AddListener(GameListeners.IGameListener listener)
        {
            _listeners.Add(listener);
            if (listener is GameListeners.IGameUpdateListener updateListener)
                _updateListeners.Add(updateListener);
            if (listener is GameListeners.IGameFixedUpdateListener fixedUpdateListener)
                _fixedUpdateListeners.Add(fixedUpdateListener);
            if (listener is GameListeners.IGameLateUpdateListener lateUpdateListener)
                _lateUpdateListeners.Add(lateUpdateListener);
        }

        public void RemoveListener(GameListeners.IGameListener listener)
        {
            _listeners.Remove(listener);
            if (listener is GameListeners.IGameUpdateListener updateListener)
                _updateListeners.Remove(updateListener);
            if (listener is GameListeners.IGameFixedUpdateListener fixedUpdateListener)
                _fixedUpdateListeners.Remove(fixedUpdateListener);
            if (listener is GameListeners.IGameLateUpdateListener lateUpdateListener)
                _lateUpdateListeners.Remove(lateUpdateListener);
        }

        [Button]
        public void StartGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is GameListeners.IGameStartListener startListener)
                {
                    startListener.OnStart();
                }
            }

            Time.timeScale = 1;
            GameState = GameState.PLAYING;
        }

        [Button]
        public void PauseGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is GameListeners.IGamePauseListener pauseListener)
                {
                    pauseListener.OnPause();
                }
            }

            Time.timeScale = 0;
            GameState = GameState.PAUSED;
        }

        [Button]
        public void ResumeGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is GameListeners.IGameResumeListener resumeListener)
                {
                    resumeListener.OnResume();
                }
            }

            Time.timeScale = 1;
            GameState = GameState.PLAYING;
        }

        [Button]
        public void FinishGame()
        {
            foreach (var gameListener in _listeners)
            {
                if (gameListener is GameListeners.IGameFinishListener finishListener)
                {
                    finishListener.OnFinish();
                }
            }

            Debug.Log("GAME OVER :(");
            Time.timeScale = 0;
            GameState = GameState.FINISHED;
        }

        private void Update()
        {
            if (GameState != GameState.PLAYING)
            {
                return;
            }

            for (int i = 0; i < _updateListeners.Count; i++)
            {
                _updateListeners[i].OnUpdate(Time.deltaTime);
            }
        }
        
        private void FixedUpdate()
        {
            if (GameState != GameState.PLAYING)
            {
                return;
            }
            
            for (int i = 0; i < _fixedUpdateListeners.Count; i++)
            {
                _fixedUpdateListeners[i].OnFixedUpdate(Time.fixedDeltaTime);
            }
        }

        private void LateUpdate()
        {
            if (GameState != GameState.PLAYING)
            {
                return;
            }
            
            for (int i = 0; i < _lateUpdateListeners.Count; i++)
            {
                _lateUpdateListeners[i].OnLateUpdate(Time.deltaTime);
            }
        }
    }
}