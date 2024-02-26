using System;
using UnityEngine;

namespace Visual.Zombie
{
    public class ZombieAnimatorDispatcher : MonoBehaviour
    {
        public event Action<string> OnEventReceived;

        public void ReceiveEvent(string key)
        {
            OnEventReceived?.Invoke(key);
        }
    }
}