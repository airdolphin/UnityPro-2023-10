using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;

namespace EcsEngine.Systems.Attack
{
    internal sealed class ArrowDestroySystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<ArrowTag, Inactive>> filter;
        private EcsCustomInject<EntityManager> entityManager;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                entityManager.Value.Destroy(entity);
            }
        }
    }
}