using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace EcsEngine.Components.Spawn
{
    public struct UnitSpawnData
    {
        public Vector3 spawnPoint;
        public Quaternion rotation;
        public Entity spawnPrefab;
        public Material spawnMaterial;
        public int teamID;
    }
}