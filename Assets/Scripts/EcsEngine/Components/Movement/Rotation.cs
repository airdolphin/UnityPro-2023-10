using System;
using UnityEngine;

namespace EcsEngine.Components.Movement
{
    [Serializable]
    public struct Rotation
    {
        public Quaternion value;
    }
}