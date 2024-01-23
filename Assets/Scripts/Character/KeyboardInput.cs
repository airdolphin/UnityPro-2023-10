using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class KeyboardInput :
        GameListeners.IGameUpdateListener
    {
        public float HorizontalDirection { get; private set; }
        public event Action OnFire;

        public void OnUpdate(float deltaTime)
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                OnFire?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                HorizontalDirection = -1;
                
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                HorizontalDirection = 1;
            }
            else
            {
                HorizontalDirection = 0;
            }
        }
    }
}