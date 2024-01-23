using UnityEngine;

namespace ShootEmUp
{
    public class CharacterInstaller : GameInstaller
    {
        [Listener, Service(typeof(KeyboardInput))]
        private readonly KeyboardInput keyboardInput = new();
        
        [SerializeField, Listener]
        private CharacterMoveController characterMoveController = new();

        [SerializeField, Listener]
        private CharacterHealthObserver characterHealthObserver = new();
        
        [SerializeField, Service(typeof(CharacterFireInteractor))]
        private CharacterFireInteractor characterFireInteractor = new();

        [SerializeField, Listener, Service(typeof(CharacterFireController))]
        private CharacterFireController characterFireController = new();
        
        [SerializeField, Service(typeof(CharacterService))]
        private CharacterService characterService = new();
    }
}