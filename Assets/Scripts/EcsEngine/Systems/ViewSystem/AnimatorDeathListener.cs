using EcsEngine.Components.LifeCycle;
using EcsEngine.Components.ViewSystem;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.ViewSystem
{
    public class AnimatorDeathListener : IEcsRunSystem
    {
        private static readonly int Death = Animator.StringToHash("Death");

        private readonly EcsFilterInject<Inc<AnimatorView, DeathEvent>> filter;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                filter.Pools.Inc1.Get(entity).value.SetTrigger(Death);
            }
        }
    }
}