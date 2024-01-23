using System;

namespace MVP
{
    public class CloseButtonPresenter : IDisposable
    {
        public Action OnExitButton;
        private readonly CloseButtonView _closeButtonView;

        public CloseButtonPresenter(CloseButtonView view)
        {
            _closeButtonView = view;
            _closeButtonView.AddListener(ClosePopup);
        }

        private void ClosePopup()
        {
            OnExitButton?.Invoke();
        }

        public void Dispose()
        {
            _closeButtonView.RemoveListener(ClosePopup);
        }
    }
}