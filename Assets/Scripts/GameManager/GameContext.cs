using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public sealed class GameContext : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;
        
        [SerializeField]
        private ServiceLocator _serviceLocator;

        [SerializeField]
        private MonoBehaviour[] _modules;

        // инит модулей (GM -> добавление лисенеров; SL -> регистрация сервисов)
        private void Awake()
        {
            foreach (var module in _modules)
            {
                if (module is IGameListenerProvider listenerProvider)
                {
                    _gameManager.AddListeners(listenerProvider.ProvideListeners());
                }
                
                if (module is IServiceProvider serviceProvider)
                {
                    var services = serviceProvider.ProvideServices();
                    foreach (var (type, service)  in services)
                    {
                        _serviceLocator.BindService(type, service);
                    }
                }
            }  
        }

        private void Start()
        {
            foreach (var module in _modules)
            {
                if (module is IInjectProvider injectProvider)
                {
                    injectProvider.Inject(_serviceLocator);
                }
            }
            
            InjectGameObjectsOnScene();
        }

        private void InjectGameObjectsOnScene()
        {
            GameObject[] gameObjects = gameObject.scene.GetRootGameObjects();

            foreach (var go in gameObjects)
            {
                Inject(go.transform);
            }
        }

        private void Inject(Transform targetTransform)
        {
            var targets = targetTransform.GetComponents<MonoBehaviour>();
            foreach (var target in targets)
            {
                DependencyInjector.Inject(target, _serviceLocator);
            }

            foreach (Transform child in targetTransform)
            {
                Inject(child);
            }
        }
    }
}