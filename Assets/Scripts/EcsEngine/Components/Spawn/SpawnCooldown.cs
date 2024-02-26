using System;

namespace EcsEngine.Components.Spawn
{
    [Serializable]
    public struct SpawnCooldown
    {
        public float spawnTimer;
        public float spawnInterval;
        
    }
}