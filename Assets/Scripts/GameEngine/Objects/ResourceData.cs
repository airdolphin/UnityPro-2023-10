using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public struct ResourceData
    {
        [SerializeField] public string id;

        [SerializeField] public int amount;
    }
}