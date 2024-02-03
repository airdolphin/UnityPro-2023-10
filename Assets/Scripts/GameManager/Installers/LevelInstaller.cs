using UnityEngine;

namespace ShootEmUp
{
    public class LevelInstaller : GameInstaller
    {
        [SerializeField, Listener]
        private LevelBackground _levelBackground = new();
        
        [SerializeField]
        private Transform _levelBackgroundTransform;
        
        [SerializeField, Service(typeof(LevelBounds))]
        private LevelBounds _levelBounds;
        
        public override void Inject(ServiceLocator serviceLocator)
        {
            _levelBackground.Construct(_levelBackgroundTransform);
        }
    }
}