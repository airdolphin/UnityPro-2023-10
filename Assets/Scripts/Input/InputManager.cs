using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public float HorizontalDirection { get; private set; }
        public event Action FireEvent;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FireEvent?.Invoke();
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