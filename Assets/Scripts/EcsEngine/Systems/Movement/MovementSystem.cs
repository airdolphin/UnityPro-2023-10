using EcsEngine.Components;
using EcsEngine.Components.Movement;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    internal sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<MoveDirection, MoveSpeed, Position>> filter;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            float deltaTime = Time.deltaTime;

            var directionPool = filter.Pools.Inc1;
            var speedPool = filter.Pools.Inc2;
            var positionPool = filter.Pools.Inc3;

            foreach (var entity in filter.Value)
            {
                var moveDirection = directionPool.Get(entity);
                var moveSpeed = speedPool.Get(entity);
                ref var position = ref positionPool.Get(entity);

                position.value += moveDirection.value * moveSpeed.value * deltaTime;
            }
        }
    }
}