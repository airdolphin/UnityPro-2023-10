using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletInstaller : GameInstaller
    {
        [SerializeField, Listener, Service(typeof(BulletSystem))]
        private BulletSystem _bulletSystem = new();
        
        [SerializeField, Listener, Service(typeof(BulletPool))]
        private BulletPool _bulletPool;
    }
}