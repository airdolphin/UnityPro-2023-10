using UnityEngine;
using System;
using TMPro;

namespace ShootEmUp
{
    [Serializable]
    public sealed class CharacterMoveController :
        GameListeners.IGameFixedUpdateListener
    {
        private KeyboardInput _inputManager;
        private MoveComponent _moveComponent;

        [Inject]
        public void Construct(KeyboardInput inputManager, CharacterService characterService)
        {
            _inputManager = inputManager;
            _moveComponent = characterService.Character.GetComponent<MoveComponent>();
        }

        public void OnFixedUpdate(float deltaTime)
        {
            _moveComponent.Move(
                new Vector2(_inputManager.HorizontalDirection, 0) * Time.fixedDeltaTime
            );
        }
    }
}