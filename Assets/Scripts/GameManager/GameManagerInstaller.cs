using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManagerInstaller : GameInstaller
    {
        [SerializeField, Listener, Service(typeof(GameManager))]
        private GameManager gameManager;
    }
}