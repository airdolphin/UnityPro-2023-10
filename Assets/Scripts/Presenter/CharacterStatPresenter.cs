using System.Collections.Generic;
using System;

namespace MVP
{
    public class CharacterStatPresenter : IDisposable
    {
        public CharacterStatView CharacterStatView { get; private set; }
        
        private readonly CharacterStatMainView _characterStatMainView;
        private readonly CharacterInfo _characterInfo;
        private readonly List<StatPresenter> _statPresenterList = new();

        private CharacterStat _currentStat;

        public CharacterStatPresenter(
            CharacterStatView characterStatView,
            CharacterStatMainView characterStatMainView,
            CharacterInfo characterInfo
        )
        {
            CharacterStatView = characterStatView;
            _characterStatMainView = characterStatMainView;
            _characterInfo = characterInfo;

            _characterInfo.OnStatAdded += AddStat;
            _characterInfo.OnStatRemoved += RemoveStat;
        }

        private void AddStat(CharacterStat stat)
        {
            CharacterStatView = _characterStatMainView.CreateStat(stat);
            var StatPresenter = new StatPresenter(stat, CharacterStatView);
            _statPresenterList.Add(StatPresenter);
        }

        private void RemoveStat(CharacterStat stat)
        {
            foreach (var statPresenter in _statPresenterList)
            {
                if (statPresenter.StatName == stat.Name)
                {
                    _characterStatMainView.DestroyStat(statPresenter.CharacterStatView);
                    _statPresenterList.Remove(statPresenter);
                    break;
                }
            }
        }

        // private void OnStatValueChanged(int value)
        // {
        //     _characterStatView.ChangeStatData(_currentStat.Name, value);
        // }

        public void Dispose()
        {
            _characterInfo.OnStatAdded -= AddStat;
            _characterInfo.OnStatRemoved -= RemoveStat;
        }
    }
}