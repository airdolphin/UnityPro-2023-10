using EcsEngine.Components.ViewSystem;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems.ViewSystems
{
    public class RenderViewSynchronizer : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<RenderView, MaterialView>> filter;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var entity in filter.Value)
            {
                ref var renderView = ref filter.Pools.Inc1.Get(entity);
                var materialView = filter.Pools.Inc2.Get(entity);

                foreach (var render in renderView.values)
                {
                    render.material = materialView.value;
                }
            }
        }
    }
}