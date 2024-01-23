using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Sirenix.OdinInspector;

namespace MVP
{
    public class PopupHelper : MonoBehaviour
    {
        private PopupView _popupView;
        private UserInfo _userInfo;
        private CharacterInfo _characterInfo;
        private CharacterStatMainView _characterStatMainView;
        private CharacterLevel _characterLevel;
        private int _characterStatCount = 6;

        [FoldoutGroup("Character Info")] public string userName;
        [FoldoutGroup("Character Info")] public string userDescription;
        [FoldoutGroup("Character Info")] public Sprite userIcon;

        [FoldoutGroup("Level Progress")] public int XPValue = 100;

        [FoldoutGroup("Character Stats")] public string statName;
        [FoldoutGroup("Character Stats")] public int statValue;

        public List<CharacterStat> CharacterStatList = new();

        [Inject]
        private void Construct(
            PopupView popupView,
            UserInfo userInfo,
            CharacterLevel characterLevel,
            CharacterInfo characterInfo
        )
        {
            _popupView = popupView;
            _userInfo = userInfo;
            _characterInfo = characterInfo;
            _characterLevel = characterLevel;
        }

        [Button(ButtonSizes.Large), GUIColor(1, 0.6f, 0.4f)]
        public void ShowPopup()
        {
            if (!_popupView.gameObject.activeSelf)
            {
                var _ = new PopupPresenter(
                    _popupView,
                    _userInfo,
                    _characterInfo,
                    _characterLevel
                );
            }
        }

        [FoldoutGroup("Character Info")]
        [Button]
        public void ChangeName()
        {
            _userInfo.ChangeName(userName);
        }

        [FoldoutGroup("Character Info")]
        [Button]
        public void ChangeUserDescription()
        {
            _userInfo.ChangeDescription(userDescription);
        }

        [FoldoutGroup("Character Info")]
        [Button]
        public void ChangeUserIcon()
        {
            _userInfo.ChangeIcon(userIcon);
        }

        [FoldoutGroup("Level Progress")]
        [Button]
        public void AddExperience()
        {
            _characterLevel.AddExperience(XPValue);
        }

        [FoldoutGroup("Character Stats")]
        [Button]
        public void AddNewStat()
        {
            if (CharacterStatList.Count == _characterStatCount)
            {
                return;
            }

            if (CharacterStatList.Any(t => t.Name == statName))
            {
                return;
            }

            var stat = new CharacterStat(statName, statValue);
            CharacterStatList.Add(stat);
            _characterInfo.AddStat(stat);
        }

        [FoldoutGroup("Character Stats")]
        [Button]
        public void RemoveStat(string statName)
        {
            try
            {
                var stat = _characterInfo.GetStat(statName);

                CharacterStatList = CharacterStatList.Where(t => t.Name != stat.Name).ToList();

                _characterInfo.RemoveStat(stat);
            }
            catch (Exception e)
            {
                Debug.Log("Stat doesn't exist");
            }
        }
    }
}