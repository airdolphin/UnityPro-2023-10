using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(GameManager))]
    public sealed class GameManagerInstaller : MonoBehaviour
    {
        [SerializeField] private List<GameObject> listenersGameObjects = new();

        private void Awake()
        {
            var gameManager = GetComponent<GameManager>();

            if (listenersGameObjects.Count == 0)
            {
                return;
            }

            foreach (var listenerObject in listenersGameObjects)
            {
                foreach (var listener in listenerObject.GetComponents<GameListeners.IGameListener>())
                {
                    gameManager.AddListener(listener);
                }
            }
        }
    }
}