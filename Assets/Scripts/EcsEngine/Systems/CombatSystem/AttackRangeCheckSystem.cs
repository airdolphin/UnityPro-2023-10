using EcsEngine.Components.CombatSystem;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.Attack
{
    public class AttackRangeCheckSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<TargetEntity, Position, AttackRange, MoveToTargetTag>,
            Exc<Inactive, EnemyInRangeTag>> filter;
        
        private readonly EcsPoolInject<EnemyInRangeTag> enemiesInRangePool;
        private readonly EcsPoolInject<Position> positionPool;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                ref var targetEntity = ref filter.Pools.Inc1.Get(entity);
                
                if (targetEntity.value == -1) continue;

                // isMoving
                filter.Pools.Inc4.Get(entity).IsMoving = true;

                ref var entityPos = ref filter.Pools.Inc2.Get(entity);
                ref var targetPos = ref positionPool.Value.Get(targetEntity.value);

                // <- entityPos / targetPos -> ?? <- attackRange ->
                if (Vector3.Distance(entityPos.value, targetPos.value) >= filter.Pools.Inc3.Get(entity).value)
                    continue;

                // isMoving
                filter.Pools.Inc4.Get(entity).IsMoving = false;

                enemiesInRangePool.Value.Add(entity) = new EnemyInRangeTag();
            }
        }
    }
}