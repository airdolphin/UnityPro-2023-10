using EcsEngine.Components.CombatSystem;
using EcsEngine.Components.ViewSystem;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems.ViewSystem
{
    public class AnimatorAttackListener : IEcsRunSystem
    {
        private static readonly int Attack = Animator.StringToHash("Attack");

        private readonly EcsFilterInject<Inc<AnimatorView, AttackEvent>> filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                filter.Pools.Inc1.Get(entity).value.SetTrigger(Attack);
            }
        }
    }
}