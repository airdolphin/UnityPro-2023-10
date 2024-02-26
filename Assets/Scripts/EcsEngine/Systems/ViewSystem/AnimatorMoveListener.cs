using EcsEngine.Components.Tags;
using EcsEngine.Components.ViewSystem;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.ViewSystems
{
    public class AnimatorMoveListener : IEcsRunSystem
    {
        private static readonly int Move = Animator.StringToHash("Move");

        private readonly EcsFilterInject<Inc<MoveToTargetTag>> filter;
        private readonly EcsPoolInject<AnimatorView> animatorPool;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                if (!animatorPool.Value.Has(entity)) continue;

                animatorPool.Value.Get(entity).value.SetBool(
                    Move,
                    filter.Pools.Inc1.Get(entity).IsMoving
                );
            }
        }
    }
}