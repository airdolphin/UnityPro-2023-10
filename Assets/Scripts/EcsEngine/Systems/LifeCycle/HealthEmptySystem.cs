using EcsEngine.Components.LifeCycle;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems.Life
{
    internal sealed class HealthEmptySystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Health>, Exc<DeathRequest, Inactive>> filter;
        private readonly EcsPoolInject<DeathRequest> deathPool;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                var health = filter.Pools.Inc1.Get(entity);

                if (health.value <= 0)
                {
                    deathPool.Value.Add(entity) = new DeathRequest();
                }
            }
        }
    }
}