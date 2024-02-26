using Character;
using UnityEngine;
using Zenject;

public sealed class CameraController : ITickable
{
    private readonly Camera camera;
    private readonly CharacterModel characterModel;
    private readonly Vector3 initialPosition;

    public CameraController(Camera camera, CharacterModel characterModel)
    {
        this.camera = camera;
        this.characterModel = characterModel;
        initialPosition = camera.transform.position;
    }

    public void Tick()
    {
        camera.transform.position = characterModel.transform.position + initialPosition;
    }
}