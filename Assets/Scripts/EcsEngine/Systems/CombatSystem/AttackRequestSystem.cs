using EcsEngine.Components.CombatSystem;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Spawn;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.Attack
{
    public class AttackRequestSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<TargetEntity, EnemyInRangeTag, SpawnCooldown>,
            Exc<Inactive, AttackRequest>> filter;
        
        private readonly EcsPoolInject<AttackRequest> attackPool;
        private EcsPoolInject<AttackEvent> eventPool;
        
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            var enemyInRangePool = filter.Pools.Inc2;
            var spawnCooldownPool = filter.Pools.Inc3;

            foreach (var entity in filter.Value)
            {
                spawnCooldownPool.Get(entity).spawnTimer += Time.deltaTime;

                if (spawnCooldownPool.Get(entity).spawnTimer >= spawnCooldownPool.Get(entity).spawnInterval)
                {
                    attackPool.Value.Add(entity) = new AttackRequest();
                    eventPool.Value.Add(entity) = new AttackEvent();
                    enemyInRangePool.Del(entity);
                    
                    spawnCooldownPool.Get(entity).spawnTimer = 0;
                }
            }
        }
    }
}