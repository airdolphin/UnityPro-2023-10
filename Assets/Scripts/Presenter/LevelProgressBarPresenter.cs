using UnityEngine;
using System;

namespace MVP
{
    public class LevelProgressBarPresenter : IDisposable
    {
        private readonly LevelProgressBarView _levelProgressBarView;
        private readonly CharacterLevel _characterLevel;
        private readonly CharacterInfoView _characterInfoView;
        private int _defaultExperience = 0;

        public LevelProgressBarPresenter(
            CharacterLevel characterLevel,
            LevelProgressBarView levelProgressBarView,
            CharacterInfoView characterInfoView
        )
        {
            _characterLevel = characterLevel;
            _levelProgressBarView = levelProgressBarView;
            _characterInfoView = characterInfoView;

            _characterLevel.OnLevelUp += ChangeLevel;
            _characterLevel.OnExperienceChanged += ChangeExperience;

            _characterLevel.AddExperience(_defaultExperience);
            ChangeLevel();
        }

        private void ChangeLevel()
        {
            _characterInfoView.ChangeLevelText($"Level: {_characterLevel.CurrentLevel}");
            ChangeExperience(_characterLevel.CurrentExperience);
        }

        private void ChangeExperience(int xpValue)
        {
            var maxXPValue = _characterLevel.RequiredExperience;
            _levelProgressBarView.ChangeExperienceValue(
                xpValue,
                maxXPValue,
                $"XP: {Mathf.Min(xpValue, 1000)}/{maxXPValue}",
                _characterLevel.CanLevelup()
            );
        }

        public void Dispose()
        {
            _characterLevel.OnLevelUp -= ChangeLevel;
            _characterLevel.OnExperienceChanged -= ChangeExperience;
        }
    }
}