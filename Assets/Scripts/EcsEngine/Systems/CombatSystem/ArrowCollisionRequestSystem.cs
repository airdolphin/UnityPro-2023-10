using Leopotam.EcsLite;
using EcsEngine.Components;
using EcsEngine.Components.CombatSystem;
using EcsEngine.Components.LifeCycle;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Helpers;


namespace EcsEngine.Systems.CombatSystem
{
    public class ArrowCollisionRequestSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject eventWorld = EcsWorlds.Events;
        private readonly EcsFilterInject<Inc<CollisionEnterRequest, ArrowTag, SourceEntity, TargetEntity>> filter =
            EcsWorlds.Events;
        private readonly EcsFactoryInject<TakeDamageRequest, SourceEntity, TargetEntity, Damage> takeDamageEmitter
            = EcsWorlds.Events;
        
        private readonly EcsPoolInject<Damage> damagePool;
        private readonly EcsPoolInject<DamagableTag> damagableTagPool;
        private readonly EcsPoolInject<DeathRequest> deathRequestPool;

        public void Run(IEcsSystems systems)
        {
            var sourcePool = filter.Pools.Inc3;
            var targetPool = filter.Pools.Inc4;

            foreach (var entity in filter.Value)
            {
                var sourceEntity = sourcePool.Get(entity);
                var arrow = sourceEntity.value;

                if (!deathRequestPool.Value.Has(arrow))
                {
                    var targetEntity = targetPool.Get(entity);
                    var target = targetEntity.value;

                    if (damagableTagPool.Value.Has(target))
                    {
                        // урон
                        takeDamageEmitter.Value.NewEntity(
                            new TakeDamageRequest(),
                            sourceEntity,
                            targetEntity,
                            damagePool.Value.Get(arrow)
                        );

                        // пометить стрелу неактивной
                        deathRequestPool.Value.Add(arrow);
                    }

                    eventWorld.Value.DelEntity(entity);
                }
            }
        }
    }
}