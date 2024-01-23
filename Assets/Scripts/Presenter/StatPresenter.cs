using System;

namespace MVP
{
    public class StatPresenter : IDisposable
    {
        public CharacterStatView CharacterStatView { get; }
        private readonly CharacterStat _characterStat;
        
        public string StatName => _characterStat.Name;
        
        public StatPresenter(CharacterStat characterStat, CharacterStatView characterStatView)
        {
            _characterStat = characterStat;
            CharacterStatView = characterStatView;
        }
        
        public void Dispose()
        {
        }
    }
}