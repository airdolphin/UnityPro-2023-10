using EcsEngine.Components;
using EcsEngine.Components.CombatSystem;
using EcsEngine.Components.LifeCycle;
using EcsEngine.Components.Movement;
using EcsEngine.Components.Spawn;
using EcsEngine.Components.Tags;
using EcsEngine.Components.ViewSystem;
using Leopotam.EcsLite.Entities;
using UnityEngine;


namespace Content
{
    public class ArcherInstaller : EntityInstaller
    {
        [SerializeField] private int teamID;

        [SerializeField] private int health;
        [SerializeField] private float moveSpeed;

        [SerializeField] private float attackRange;
        [SerializeField] private Transform firePoint;
        [SerializeField] private Entity arrowPrefab;

        [SerializeField] private Animator animator;
        [SerializeField] private Renderer[] assetRenderList;

        protected override void Install(Entity entity)
        {
            entity.AddData(new Team { value = teamID });
            entity.AddData(new DamagableTag());

            entity.AddData(new Health() { value = health });
            entity.AddData(new MoveSpeed { value = moveSpeed });
            entity.AddData(new Position { value = transform.position });
            entity.AddData(new Rotation { value = transform.rotation });

            entity.AddData(new AttackRange() { value = attackRange });
            entity.AddData(new RangeWeapon()
            {
                firePoint = firePoint,
                rangeWeaponPrefab = arrowPrefab
            });
            entity.AddData(new SpawnCooldown()
                {
                    spawnTimer = 0,
                    spawnInterval = 2
                }
            );

            entity.AddData(new TargetEntity { value = -1 });
            entity.AddData(new TargetPosition { value = transform.position });
            entity.AddData(new MoveToTargetTag());

            entity.AddData(new AnimatorView() { value = animator });
            entity.AddData(new TransformView { value = transform });
            entity.AddData(new RenderView() { values = assetRenderList });
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}