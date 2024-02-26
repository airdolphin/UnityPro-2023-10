using EcsEngine.Components.LifeCycle;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems.Life
{
    internal sealed class DeathRequestSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<DeathRequest>, Exc<Inactive>> filter;
        
        private EcsPoolInject<DeathEvent> eventPool;
        private EcsPoolInject<Inactive> tagPool;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                filter.Pools.Inc1.Del(entity);

                tagPool.Value.Add(entity) = new Inactive();
                eventPool.Value.Add(entity) = new DeathEvent();
            }
        }
    }
}