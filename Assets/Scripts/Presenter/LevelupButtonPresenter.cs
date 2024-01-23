using System;

namespace MVP
{
    public class LevelupButtonPresenter : IDisposable
    {
        private readonly LevelupButtonView _levelupButtonView;
        private readonly CharacterLevel _characterLevel;
        
        public LevelupButtonPresenter(LevelupButtonView levelupButtonView, CharacterLevel characterLevel)
        {
            _levelupButtonView = levelupButtonView;
            _characterLevel = characterLevel;
            _characterLevel.OnExperienceChanged += ChangeExperience;
            _levelupButtonView.AddListener(OnLevelupButtonClick);
        }
        
        private void OnLevelupButtonClick()
        {
            if (!_characterLevel.CanLevelup())
            {
                return;
            }
            _characterLevel.Levelup();
            
            ChangeExperience(_characterLevel.CurrentExperience);
            
        }
        
        private void ChangeExperience(int _)
        {
            _levelupButtonView.ToggleButtonState(_characterLevel.CanLevelup());
        }
        
        public void Dispose()
        {
            _characterLevel.OnExperienceChanged += ChangeExperience;
            _levelupButtonView.RemoveListener(OnLevelupButtonClick);
        }
    }
}