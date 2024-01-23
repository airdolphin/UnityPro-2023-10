using UnityEngine;
using Zenject;

namespace MVP
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PopupHelper popupHelper;
        [SerializeField] private PopupView popupView;

        public override void InstallBindings()
        {
            Container.Bind<PopupHelper>().FromInstance(popupHelper).AsSingle();
            Container.Bind<PopupView>().FromInstance(popupView).AsSingle();
            Container.Bind<CharacterInfo>().AsSingle();
            Container.Bind<UserInfo>().AsSingle();
            Container.Bind<CharacterLevel>().AsSingle();
        }
    }
}