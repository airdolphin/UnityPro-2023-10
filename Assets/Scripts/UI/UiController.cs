using System;
using Character;
using TMPro;
using UI.View;
using UnityEngine;

namespace UI
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _bulletAmountText;
        [SerializeField] private TextMeshProUGUI _healthAmountText;
        [SerializeField] private TextMeshProUGUI _killsAmountText;
        [SerializeField] private EndGamePopupView _endGamePopupView;
        [SerializeField] private CharacterModel _characterModel;

        private void Awake()
        {
            _bulletAmountText.text = $"bullets: {_characterModel.bulletCurrentAmount.Value} / 10";
            _healthAmountText.text = $"hit points: {_characterModel.hitPoints.Value}";
            _killsAmountText.text = $"kills: {_characterModel.killCount.Value}";
        }

        private void OnEnable()
        {
            _characterModel.deathEvent.Subscribe(ShowEndGamePopup);
            _characterModel.bulletCurrentAmount.Subscribe(ChangeBulletAmount);
            _characterModel.hitPoints.Subscribe(ChangeHealthAmount);
            _characterModel.killCount.Subscribe(ChangeKillAmount);
        }

        private void OnDisable()
        {
            _characterModel.deathEvent.UnSubscribe(ShowEndGamePopup);
            _characterModel.bulletCurrentAmount.UnSubscribe(ChangeBulletAmount);
            _characterModel.hitPoints.UnSubscribe(ChangeHealthAmount);
            _characterModel.killCount.UnSubscribe(ChangeKillAmount);
        }

        public void ChangeBulletAmount(int bulletCount)
        {
            _bulletAmountText.text = $"bullets: {bulletCount} / 10";
        }
        
        public void ChangeHealthAmount(int hitPoints)
        {
            _healthAmountText.text = $"hit points: {hitPoints}";
        }
        
        public void ChangeKillAmount(int killCount)
        {
            _killsAmountText.text = $"kills: {killCount}";
        }

        private void ShowEndGamePopup()
        {
            _endGamePopupView.Show();
        }
    }
}