using Character;
using UnityEngine;
using Zenject;
using Zombie;

public sealed class SceneInstaller : MonoInstaller
{
    [SerializeField] private CharacterModel characterModel;
    [SerializeField] private Camera mainCamera;

    public override void InstallBindings()
    {
        Container.Bind<CharacterModel>().FromInstance(characterModel).AsSingle();
        Container.BindInterfacesAndSelfTo<InputController>().AsSingle();
        Container.Bind<Camera>().FromInstance(mainCamera).AsSingle();
        Container.BindInterfacesAndSelfTo<CameraController>().AsSingle();
        Container.BindInterfacesAndSelfTo<ZombieSpawnController>().AsSingle();
        Container.BindInterfacesAndSelfTo<ZombieSpawner>().AsSingle();
    }
}