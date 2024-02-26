using EcsEngine.Components;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Spawn;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace EcsEngine.Systems
{
    internal sealed class ArrowSpawnRequestSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<SpawnRequest, Position, Rotation, Prefab>> filter
            = EcsWorlds.Events;
        private readonly EcsWorldInject eventWorld = EcsWorlds.Events;
        private readonly EcsCustomInject<EntityManager> entityManager;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (int @event in filter.Value)
            {
                Vector3 position = filter.Pools.Inc2.Get(@event).value;
                Quaternion rotation = filter.Pools.Inc3.Get(@event).value;
                Entity prefab = filter.Pools.Inc4.Get(@event).value;
                
                entityManager.Value.Create(prefab, position, rotation);
                
                eventWorld.Value.DelEntity(@event);
            }
        }
    }
}