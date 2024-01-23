using UnityEngine;

namespace ShootEmUp
{
    public class LevelInstaller : GameInstaller
    {
        [SerializeField, Listener]
        private LevelBackground levelBackground = new();
        
        [SerializeField]
        private Transform levelBackgroundTransform;
        
        [SerializeField, Service(typeof(LevelBounds))]
        private LevelBounds levelBounds;
        
        public override void Inject(ServiceLocator serviceLocator)
        {
            levelBackground.Construct(levelBackgroundTransform);
        }
    }
}