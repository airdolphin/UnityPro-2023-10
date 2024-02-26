using EcsEngine.Components;
using EcsEngine.Components.CombatSystem;
using EcsEngine.Components.LifeCycle;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Spawn;
using EcsEngine.Components.Tags;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    public class BaseInstaller : EntityInstaller
    {
        [SerializeField] private int teamID;
        [SerializeField] private int hitPoints;
        [SerializeField] private Transform spawnPoint;

        protected override void Install(Entity entity)
        {
            entity.AddData(new BaseTag());
            entity.AddData(new DamagableTag());

            entity.AddData(new Team { value = teamID });
            entity.AddData(new Health() { value = hitPoints });
            entity.AddData(new SpawnPosition() { value = spawnPoint.position });
            entity.AddData(new Position() { value = transform.position });
            entity.AddData(new Rotation { value = transform.rotation });
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}