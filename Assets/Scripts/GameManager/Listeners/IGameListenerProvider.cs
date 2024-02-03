using System.Collections.Generic;

namespace ShootEmUp
{
    public interface IGameListenerProvider
    {
        IEnumerable<GameListeners.IGameListener> ProvideListeners();
    }
}