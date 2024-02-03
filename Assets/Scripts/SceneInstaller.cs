using System.Collections.Generic;
using GameEngine;
using Zenject;
using SaveLoaders;
using UnityEngine;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Transform _unitsContainer;
    public List<Unit> UnitPrefabList;

    public override void InstallBindings()
    {
        Container.Bind<List<Unit>>().FromInstance(UnitPrefabList).AsSingle();
        Container.Bind<GameRepository>().AsSingle();
        Container.Bind<SaveLoadManager>().AsSingle();

        Container.Bind<UnitManager>().FromInstance(new UnitManager(_unitsContainer)).AsSingle();
        Container.Bind<ResourceService>().FromInstance(new ResourceService()).AsSingle();
        
        Container.BindInterfacesTo<UnitSaveLoader>().AsSingle().NonLazy();
        Container.BindInterfacesTo<ResourcesSaveLoader>().AsSingle().NonLazy();
    }
}