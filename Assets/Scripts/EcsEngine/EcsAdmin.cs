using EcsEngine.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;
using System;
using EcsEngine.Components.CombatSystem;
using EcsEngine.Components.LifeCycle;
using EcsEngine.Systems.Attack;
using EcsEngine.Systems.CombatSystem;
using EcsEngine.Systems.Life;
using EcsEngine.Systems.ViewSystem;
using EcsEngine.Systems.ViewSystems;
using Leopotam.EcsLite.ExtendedSystems;
using Leopotam.EcsLite.Helpers;

namespace EcsEngine {
    public sealed class EcsAdmin : MonoBehaviour 
    {
        public static EcsAdmin Instance { get; private set; }
        
        EcsWorld _world;        
        EcsWorld _events;        
        IEcsSystems _systems;
        private EntityManager _entityManager;

        
        public EcsEntityBuilder CreateEntity(string worldName = null)
        {
            return new EcsEntityBuilder(_systems.GetWorld(worldName));
        }

        public EcsWorld GetWorld(string worldName = null)
        {
            return worldName switch
            {
                null => _world,
                EcsWorlds.Events => _events,
                _ => throw new Exception($"World with name {worldName} is not found!")
            };
        }

        private void Awake()
        {
            Instance = this;

            _entityManager = new EntityManager();

            _world = new EcsWorld();
            _events = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.AddWorld(_events, EcsWorlds.Events);

            _systems 
                // Logic
                .Add(new MovementSystem())
                .Add(new FollowTargetSystem())
                .Add(new MoveTargetSystem())
                
                .Add(new ArrowSpawnRequestSystem())
                .Add(new UnitSpawnRequestSystem())
                
                .Add(new DeathRequestSystem())
                .Add(new HealthEmptySystem())
                .Add(new TakeDamageSystem())
                .Add(new ArrowCollisionRequestSystem())
                .Add(new ArrowDestroySystem())
                .Add(new AttackRangeCheckSystem())
                .Add(new AttackRequestSystem())
                .Add(new RangeAttackRequestSystem())
                .Add(new UnitDestroySystem())
                
                // View
                .Add(new AnimatorMoveListener())
                .Add(new AnimatorAttackListener())
                .Add(new AnimatorDeathListener())
                .Add(new RenderViewSynchronizer())
                .Add(new TransformViewSynchronizer())

                // Editor
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem(EcsWorlds.Events))
#endif                
                // CleanUp
                .Add(new OneFrameEventSystem())
                .DelHere<AttackEvent>()
                .DelHere<DeathEvent>();

        }

        private void Start ()
        {
            _entityManager.Initialize(_world);
            _systems.Inject(_entityManager);
            _systems.Init();
        }

        private void Update () {
            // process systems here.
            _systems?.Run ();
        }

        private void OnDestroy () {
            if (_systems != null) {
                // list of custom worlds will be cleared
                // during IEcsSystems.Destroy(). so, you
                // need to save it here if you need.
                _systems.Destroy ();
                _systems = null;
            }
            
            // cleanup custom worlds here.
            
            // cleanup default world.
            if (_world != null) {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}