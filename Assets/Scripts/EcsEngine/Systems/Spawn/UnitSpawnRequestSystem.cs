using EcsEngine.Components;
using EcsEngine.Components.Spawn;
using EcsEngine.Components.ViewSystem;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class UnitSpawnRequestSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<SpawnRequest, UnitSpawnData>> filter;
        private readonly EcsCustomInject<EntityManager> entityManager;
        private readonly EcsWorldInject eventWorld = EcsWorlds.Events;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            var requestPool = filter.Pools.Inc1;
            var unitSpawnDataPool = filter.Pools.Inc2;

            foreach (var entity in filter.Value)
            {
                var unitSpawnData = unitSpawnDataPool.Get(entity);

                var createdEntity = entityManager.Value.Create(
                    unitSpawnData.spawnPrefab,
                    unitSpawnData.spawnPoint,
                    unitSpawnData.rotation
                );

                createdEntity.SetData(
                    new MaterialView() { value = unitSpawnData.spawnMaterial }
                );
                createdEntity.SetData(
                    new Team() { value = unitSpawnData.teamID }
                );

                unitSpawnDataPool.Del(entity);
                requestPool.Del(entity);
            }
        }
    }
}