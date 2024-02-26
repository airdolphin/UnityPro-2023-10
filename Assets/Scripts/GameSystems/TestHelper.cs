using System;
using UnityEngine;
using Sirenix.OdinInspector;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Spawn;
using Leopotam.EcsLite.Entities;

namespace GameSystems
{
    public class TestHelper : MonoBehaviour
    {
        [SerializeField] private TeamType teamType;
        [SerializeField] private UnitType unitType;

        [SerializeField] private Material redMaterial;
        [SerializeField] private Material blueMaterial;

        [SerializeField] private Entity redBase;
        [SerializeField] private Entity blueBase;

        [SerializeField] private Entity archer;
        [SerializeField] private Entity swordsman;

        [Button]
        public void Spawn()
        {
            Entity teamBase;
            var unitSpawnData = new UnitSpawnData();

            if (unitType == UnitType.Archer)
            {
                unitSpawnData.spawnPrefab = archer;
            }
            else
            {
                unitSpawnData.spawnPrefab = swordsman;
            }

            if (teamType == TeamType.Blue)
            {
                teamBase = blueBase;
                unitSpawnData.spawnMaterial = blueMaterial;
                unitSpawnData.teamID = 0;
            }
            else
            {
                teamBase = redBase;
                unitSpawnData.spawnMaterial = redMaterial;
                unitSpawnData.teamID = 1;
            }

            unitSpawnData.spawnPoint = teamBase.GetData<SpawnPosition>().value;
            unitSpawnData.rotation = teamBase.GetData<Rotation>().value;
            
            teamBase.SetData(unitSpawnData);
            teamBase.SetData(new SpawnRequest());
        }

        private enum TeamType
        {
            Blue, // 0
            Red // 1
        }

        private enum UnitType
        {
            Archer,
            Swordsman
        }
    }
}