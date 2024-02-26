using EcsEngine.Components.Tags;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems
{
    internal sealed class OneFrameEventSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject eventWorld = EcsWorlds.Events;
        private readonly EcsFilterInject<Inc<OneFrame>> filter = EcsWorlds.Events;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (var @event in filter.Value) eventWorld.Value.DelEntity(@event);
        }
    }
}