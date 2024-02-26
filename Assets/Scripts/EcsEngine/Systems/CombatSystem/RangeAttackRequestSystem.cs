using EcsEngine.Components;
using EcsEngine.Components.CombatSystem;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Spawn;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems.Attack
{
    public class RangeAttackRequestSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<AttackRequest, RangeWeapon, TargetEntity>, Exc<Inactive>> filter;
        private readonly EcsWorldInject eventWorld = EcsWorlds.Events;

        private readonly EcsPoolInject<Position> positionPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Rotation> rotationPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Prefab> prefabPool = EcsWorlds.Events;
        
        private readonly EcsPoolInject<SpawnRequest> spawnPool = EcsWorlds.Events;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                var weapon = filter.Pools.Inc2.Get(entity);
                var spawnEvent = eventWorld.Value.NewEntity();

                spawnPool.Value.Add(spawnEvent) = new SpawnRequest();
                
                positionPool.Value.Add(spawnEvent) = new Position { value = weapon.firePoint.position };
                rotationPool.Value.Add(spawnEvent) = new Rotation { value = weapon.firePoint.rotation };
                prefabPool.Value.Add(spawnEvent) = new Prefab { value = weapon.rangeWeaponPrefab };

                filter.Pools.Inc1.Del(entity);
            }
        }
    }
}