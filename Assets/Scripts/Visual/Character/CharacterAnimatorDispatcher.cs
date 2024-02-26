using System;
using Character;
using UnityEngine;

namespace Visual
{
    public class CharacterAnimatorDispatcher : MonoBehaviour
    {
        [SerializeField] private CharacterModel _character;

        public void ReceiveEvent(string value)
        {
            if (value == "shoot")
            {
                _character.fireEvent.Invoke();
            }
        }
    }
}