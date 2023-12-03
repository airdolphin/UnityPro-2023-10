using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        [ShowInInspector] public GameState GameState { get; private set; }


        // [ShowInInspector]
        private readonly List<GameListeners.IGameListener> listeners = new();
        // [ShowInInspector]
        private readonly List<GameListeners.IGameUpdateListener> updateListeners = new();
        // [ShowInInspector]
        private readonly List<GameListeners.IGameFixedUpdateListener> fixedUpdateListeners = new();
        // [ShowInInspector]
        private readonly List<GameListeners.IGameLateUpdateListener> lateUpdateListeners = new();

        public void AddListener(GameListeners.IGameListener listener)
        {
            listeners.Add(listener);

            if (listener is GameListeners.IGameUpdateListener updateListener)
            {
                updateListeners.Add(updateListener);
            }

            if (listener is GameListeners.IGameFixedUpdateListener fixedUpdateListener)
            {
                fixedUpdateListeners.Add(fixedUpdateListener);
            }

            if (listener is GameListeners.IGameLateUpdateListener lateUpdateListener)
            {
                lateUpdateListeners.Add(lateUpdateListener);
            }
        }

        [Button]
        public void StartGame()
        {
            foreach (var listener in listeners)
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
            foreach (var listener in listeners)
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
            foreach (var listener in listeners)
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
            foreach (var gameListener in listeners)
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

            for (int i = 0; i < updateListeners.Count; i++)
            {
                updateListeners[i].OnUpdate(Time.deltaTime);
            }
        }
        
        private void FixedUpdate()
        {
            if (GameState != GameState.PLAYING)
            {
                return;
            }
            
            for (int i = 0; i < fixedUpdateListeners.Count; i++)
            {
                fixedUpdateListeners[i].OnFixedUpdate(Time.fixedDeltaTime);
            }
        }

        private void LateUpdate()
        {
            if (GameState != GameState.PLAYING)
            {
                return;
            }
            
            for (int i = 0; i < lateUpdateListeners.Count; i++)
            {
                lateUpdateListeners[i].OnLateUpdate(Time.deltaTime);
            }
        }
    }
}