using EcsEngine.Components.CombatSystem;
using EcsEngine.Components.ViewSystem;
using Leopotam.EcsLite.Entities;
using UnityEngine;


namespace Content
{
    public class SwordmanInstaller : EntityInstaller
    {
        [SerializeField] private Renderer[] assetRenderList;

        protected override void Install(Entity entity)
        {
            entity.AddData(new DamagableTag());
            
            entity.AddData(new RenderView() { values = assetRenderList });
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}