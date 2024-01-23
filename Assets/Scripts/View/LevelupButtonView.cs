using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MVP
{
    public class LevelupButtonView : MonoBehaviour
    {
        [SerializeField] private Button levelupButton;
        [SerializeField] private Sprite inactiveSprite;
        [SerializeField] private Sprite activeSprite;


        public void AddListener(UnityAction action)
        {
            levelupButton.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            levelupButton.onClick.RemoveListener(action);
        }

        public void ToggleButtonState(bool value)
        {
            levelupButton.interactable = value;
            levelupButton.image.sprite = value ? activeSprite : inactiveSprite;
        }
    }
}