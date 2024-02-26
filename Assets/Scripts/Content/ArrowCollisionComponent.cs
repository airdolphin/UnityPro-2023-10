using EcsEngine;
using EcsEngine.Components;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    [RequireComponent(typeof(Entity))]
    public class ArrowCollisionComponent : MonoBehaviour
    {
        private Entity entity;

        private void Awake()
        {
            entity = GetComponent<Entity>();
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.TryGetComponent(out Entity target))
            {
                EcsAdmin.Instance.CreateEntity(EcsWorlds.Events)
                    .Add(new CollisionEnterRequest())
                    .Add(new ArrowTag())
                    .Add(new SourceEntity { value = entity.Id })
                    .Add(new TargetEntity() { value = target.Id })
                    .Add(new Position { value = collision.ClosestPoint(transform.position) });
            }
        }
    }
}