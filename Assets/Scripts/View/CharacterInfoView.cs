using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVP
{
    public class CharacterInfoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _characterName;
        [SerializeField] private TMP_Text _characterDescription;
        [SerializeField] private Image _characterIcon;
        [SerializeField] private TMP_Text _levelText;

        public void ChangeName(string characterName)
        {
            _characterName.text = characterName;
        }

        public void ChangeDescription(string description)
        {
            _characterDescription.text = description;
        }
        
        public void ChangeIcon(Sprite icon)
        {
            _characterIcon.sprite = icon;
        }
        
        public void ChangeLevelText(string text)
        {
            _levelText.text = text;
        }
    }
}