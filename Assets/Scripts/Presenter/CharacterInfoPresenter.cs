using UnityEngine;
using System;

namespace MVP
{
    public class CharacterInfoPresenter : IDisposable
    {
        private readonly CharacterInfoView _characterInfoView;
        private readonly UserInfo _userInfo;

        public CharacterInfoPresenter(CharacterInfoView characterInfoView, UserInfo userInfo)
        {
            _characterInfoView = characterInfoView;
            _userInfo = userInfo;
            _userInfo.OnNameChanged += ChangeName;
            _userInfo.OnDescriptionChanged += ChangeDescription;
            _userInfo.OnIconChanged += ChangeIcon;
        }

        private void ChangeName(string name)
        {
            _characterInfoView.ChangeName(name);
        }

        private void ChangeDescription(string description)
        {
            _characterInfoView.ChangeDescription(description);
        }

        private void ChangeIcon(Sprite icon)
        {
            _characterInfoView.ChangeIcon(icon);
        }

        public void Dispose()
        {
            _userInfo.OnNameChanged -= ChangeName;
            _userInfo.OnDescriptionChanged -= ChangeDescription;
            _userInfo.OnIconChanged -= ChangeIcon;
        }
    }
}