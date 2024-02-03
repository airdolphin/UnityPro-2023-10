using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

public class GameRepository : IGameRepository
{
    private const string _SAVE_KEY = "Lesson/GameState";
    private Dictionary<string, string> _gameState = new();

    public T GetData<T>()
    {
        var keyName = typeof(T).Name;
        var data = JsonConvert.DeserializeObject<T>(AESEncryptionService.Decrypt(_gameState[keyName]));
        return data;
    }

    public bool TryGetData<T>(out T value)
    {
        var keyName = typeof(T).Name;

        if (_gameState.TryGetValue(keyName, out var serializedData))
        {
            value = JsonConvert.DeserializeObject<T>(AESEncryptionService.Decrypt(serializedData));
            return true;
        }

        value = default;
        return false;
    }

    public void SetData<T>(T value)
    {
        var keyName = typeof(T).Name;
        var encryptedData = AESEncryptionService.Encrypt(JsonConvert.SerializeObject(value));
        _gameState[keyName] = encryptedData;
    }

    public void LoadState()
    {
        if (PlayerPrefs.HasKey(_SAVE_KEY))
        {
            var data = PlayerPrefs.GetString(_SAVE_KEY);
            _gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
        }
    }

    public void SaveState()
    {
        var data = JsonConvert.SerializeObject(_gameState);
        PlayerPrefs.SetString(_SAVE_KEY, data);
    }
}