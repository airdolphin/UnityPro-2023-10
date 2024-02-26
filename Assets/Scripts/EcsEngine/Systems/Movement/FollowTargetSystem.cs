using EcsEngine.Components;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class FollowTargetSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<Team, Position, MoveSpeed, TargetPosition, MoveToTargetTag>, Exc<Inactive>> filter;
        
        private readonly EcsFilterInject<Inc<Team, Position>, Exc<Inactive>> targetFilter;
        private readonly EcsPoolInject<TargetEntity> targetEntityPool;
        
        public void Run(IEcsSystems systems)
        {
            var teamPool = filter.Pools.Inc1;
            var positionPool = filter.Pools.Inc2;
            var targetPositionPool = filter.Pools.Inc4;
        
            var distanceTarget = 0f;
        
            foreach (var entity in filter.Value)
            {
                var target = false;
        
                foreach (var enemy in targetFilter.Value)
                {
                    if (teamPool.Get(entity).value == teamPool.Get(enemy).value) continue;
        
                    if (!target)
                    {
                        distanceTarget = Vector3.Distance(
                            positionPool.Get(entity).value, positionPool.Get(enemy).value
                        );
                        targetPositionPool.Get(entity).value = positionPool.Get(enemy).value;

                        SetTarget(entity, enemy);
                        target = true;
                    }
                    else
                    {
                        var distanceUnitEnemy = Vector3.Distance(
                            positionPool.Get(entity).value, positionPool.Get(enemy).value
                        );
                    
                        if (!(distanceUnitEnemy < distanceTarget)) continue;
                    
                        targetPositionPool.Get(entity).value = positionPool.Get(enemy).value;
                        SetTarget(entity, enemy);
                        distanceTarget = distanceUnitEnemy;
                    }
                }
        
                if (!target)
                {
                    targetPositionPool.Get(entity).value = positionPool.Get(entity).value;
                    targetEntityPool.Value.Get(entity).value = -1;
                }
            }
        }

        private void SetTarget(int entity, int enemy)
        {
            if (targetEntityPool.Value.Has(entity))
            {
                targetEntityPool.Value.Get(entity).value = enemy;
                
            }
        }
    }
}