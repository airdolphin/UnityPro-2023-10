using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Zombie
{
    public class ZombieSpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPositionList;
        [SerializeField] private GameObject _zombiePrefab;
        [SerializeField] private Transform _root;

        public void Spawn()
        {
            var instance = Object.Instantiate(
                _zombiePrefab,
                GetSpawnPoint(),
                _zombiePrefab.transform.rotation,
                _root
            );
        }

        private Vector3 GetSpawnPoint()
        {
            return _spawnPositionList[Random.Range(0, _spawnPositionList.Count - 1)].position;
        }

    }
}