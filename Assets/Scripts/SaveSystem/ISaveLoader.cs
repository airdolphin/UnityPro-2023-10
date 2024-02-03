using Zenject;

public interface ISaveLoader
{
    public void LoadGame(IGameRepository gameRepository, SceneContext sceneContext);
    public void SaveGame(IGameRepository gameRepository, SceneContext sceneContext);
}