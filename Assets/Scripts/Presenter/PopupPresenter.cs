using System;
using System.Collections.Generic;

namespace MVP
{
    public class PopupPresenter
    {
        private readonly PopupView _popupView;
        private readonly UserInfo _userInfo;
        private readonly CloseButtonPresenter _closeButtonPresenter;
        private readonly List<IDisposable> _presenters = new();

        public PopupPresenter(
            PopupView popupView,
            UserInfo userInfo,
            CharacterInfo characterInfo,
            CharacterLevel characterLevel
        )
        {
            _popupView = popupView;
            _popupView.gameObject.SetActive(true);

            _closeButtonPresenter = new CloseButtonPresenter(_popupView.CloseButtonView);
            _closeButtonPresenter.OnExitButton += ClosePopup;
            _presenters.Add(_closeButtonPresenter);

            var _levelUpButtonPresenter = new LevelupButtonPresenter(_popupView.LevelupButtonView, characterLevel);
            _presenters.Add(_levelUpButtonPresenter);

            var _levelProgressBarPresenter =
                new LevelProgressBarPresenter(
                    characterLevel, _popupView.LevelProgressBarView, _popupView.CharacterInfoView
                    );
            _presenters.Add(_levelProgressBarPresenter);

            var _characterInfoPresenter = new CharacterInfoPresenter(
                _popupView.CharacterInfoView, userInfo
            );
            _presenters.Add(_characterInfoPresenter);

            var _characterStatPresenter = new CharacterStatPresenter(
                _popupView.CharacterStatView, _popupView.CharacterStatMainView, characterInfo
            );
            _presenters.Add(_characterStatPresenter);
        }

        private void ClosePopup()
        {
            _popupView.gameObject.SetActive(false);
            _popupView.CloseButtonView.RemoveListener(ClosePopup);
            _closeButtonPresenter.OnExitButton -= ClosePopup;

            foreach (var presenter in _presenters)
            {
                presenter.Dispose();
            }
        }
    }
}