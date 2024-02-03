using UnityEngine;
using Zenject;

public abstract class SaveLoader<TData, TService> : ISaveLoader
{
    public void SaveGame(IGameRepository gameRepository, SceneContext sceneContext)
    {
        var service = sceneContext.Container.Resolve<TService>();
        var data = ConvertToData(service);
        gameRepository.SetData(data);

        Debug.Log($"<color=green> Data saved for {typeof(TService).Name} </color>");
    }

    public void LoadGame(IGameRepository gameRepository, SceneContext sceneContext)
    {
        var service = sceneContext.Container.Resolve<TService>();

        if (gameRepository.TryGetData(out TData data))
        {
            SetupData(data, service);
            Debug.Log($"<color=green> Data loaded for {typeof(TService).Name} </color>");
        }
        else
        {
            SetupDefaultData(service);
            Debug.Log($"<color=green> Default data loaded for {typeof(TService).Name} </color>");
        }
    }

    protected abstract TData ConvertToData(TService service);
    protected abstract void SetupData(TData data, TService service);
    protected virtual void SetupDefaultData(TService service) { }
}