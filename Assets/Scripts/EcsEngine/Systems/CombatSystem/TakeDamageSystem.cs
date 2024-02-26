using EcsEngine.Components;
using EcsEngine.Components.Tags;
using EcsEngine.Components.CombatSystem;
using EcsEngine.Components.LifeCycle;
using EcsEngine.Components.Movement;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class TakeDamageSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<TakeDamageRequest, TargetEntity, Damage>,
            Exc<Inactive>> filter = EcsWorlds.Events;

        private readonly EcsPoolInject<TakeDamageEvent> eventPool = EcsWorlds.Events;
        private readonly EcsPoolInject<OneFrame> oneFramePool = EcsWorlds.Events;

        private readonly EcsWorldInject world;
        private readonly EcsPoolInject<Health> healthPool;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (int @event in filter.Value)
            {
                int target = filter.Pools.Inc2.Get(@event).value;
                int damage = filter.Pools.Inc3.Get(@event).value;

                if (world.Value.IsEntityAlive(target) && healthPool.Value.Has(target))
                {
                    ref int health = ref healthPool.Value.Get(target).value;
                    health = Mathf.Max(0, health - damage);
                }

                filter.Pools.Inc1.Del(@event);
                eventPool.Value.Add(@event) = new TakeDamageEvent();
                oneFramePool.Value.Add(@event) = new OneFrame();
            }
        }
    }
}