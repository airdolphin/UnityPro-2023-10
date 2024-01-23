using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletInstaller : GameInstaller
    {
        [SerializeField, Listener, Service(typeof(BulletSystem))]
        private BulletSystem bulletSystem = new();
        
        [SerializeField, Listener, Service(typeof(BulletPool))]
        private BulletPool bulletPool;
    }
}