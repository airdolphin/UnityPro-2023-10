using EcsEngine.Components.Movement;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    internal sealed class MoveTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Position, TargetPosition, MoveSpeed, MoveToTargetTag, Rotation>,
            Exc<Inactive>> filter;

        public void Run(IEcsSystems systems)
        {
            var deltaTime = Time.deltaTime;

            var positionPool = filter.Pools.Inc1;
            var targetPositionPool = filter.Pools.Inc2;
            var speedPool = filter.Pools.Inc3;
            var rotationPool = filter.Pools.Inc5;

            foreach (var entity in filter.Value)
            {
                if (!filter.Pools.Inc4.Get(entity).IsMoving) continue;

                ref var unitPos = ref positionPool.Get(entity).value;
                ref var targetPos = ref targetPositionPool.Get(entity).value;
                rotationPool.Get(entity).value = Quaternion.LookRotation(targetPos - unitPos);
                var moveSpeed = speedPool.Get(entity).value;

                unitPos = Vector3.MoveTowards(unitPos, targetPos, moveSpeed * deltaTime);
                
            }
        }
    }
}