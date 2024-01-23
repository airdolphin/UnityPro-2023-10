using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class CharacterService
    {
        [field: SerializeField] public GameObject Character { get; private set; }
        // [field: SerializeField] public BulletConfig BulletConfig { get; set; }
    }
}