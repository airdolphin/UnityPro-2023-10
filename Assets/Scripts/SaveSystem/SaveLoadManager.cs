using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using GameEngine;

public class SaveLoadManager : MonoBehaviour
{
    private ISaveLoader[] _saveLoaders;
    private IGameRepository _gameRepository;
    private UnitManager _unitManager;
    private ResourceService _resourceService;

    [Inject]
    public void Construct(
        GameRepository gameRepository,
        ISaveLoader[] saveLoaders,
        UnitManager unitManager,
        ResourceService resourceService
    )
    {
        _gameRepository = gameRepository;
        _saveLoaders = saveLoaders;

        _unitManager = unitManager;
        _resourceService = resourceService;

        _unitManager.SetupUnits(FindObjectsOfType<Unit>());
        _resourceService.SetResources(FindObjectsOfType<Resource>());
    }

    [Button]
    public void SaveGame()
    {
        var sceneContext = FindObjectOfType<SceneContext>();
        foreach (var saveLoader in _saveLoaders)
        {
            saveLoader.SaveGame(_gameRepository, sceneContext);
        }

        _gameRepository.SaveState();
    }

    [Button]
    public void LoadGame()
    {
        _gameRepository.LoadState();
        var sceneContext = FindObjectOfType<SceneContext>();
        foreach (var saveLoader in _saveLoaders)
        {
            saveLoader.LoadGame(_gameRepository, sceneContext);
        }
    }
}