using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace ShootEmUp
{
    [Serializable]
    public sealed class EnemyPositions
    {
        [SerializeField] private Transform[] _spawnPositions;
        [SerializeField] private Transform[] _attackPositions;

        public Transform RandomSpawnPosition()
        {
            return RandomTransform(_spawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return RandomTransform(_attackPositions);
        }

        private Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
            return transforms[index];
        }
    }
}