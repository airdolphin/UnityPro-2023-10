using UnityEngine;

namespace ShootEmUp
{
    public class CharacterInstaller : GameInstaller
    {
        [Listener, Service(typeof(KeyboardInput))]
        private readonly KeyboardInput _keyboardInput = new();
        
        [SerializeField, Listener]
        private CharacterMoveController _characterMoveController = new();

        [SerializeField, Listener]
        private CharacterHealthObserver _characterHealthObserver = new();
        
        [SerializeField, Service(typeof(CharacterFireInteractor))]
        private CharacterFireInteractor _characterFireInteractor = new();

        [SerializeField, Listener, Service(typeof(CharacterFireController))]
        private CharacterFireController _characterFireController = new();
        
        [SerializeField, Service(typeof(CharacterService))]
        private CharacterService _characterService = new();
    }
}