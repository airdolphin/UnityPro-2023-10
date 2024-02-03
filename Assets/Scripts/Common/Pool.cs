using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Pool<T> where T : MonoBehaviour
    {
        private readonly T _initPrefab;
        private readonly Transform _initContainer;
        private readonly Queue<T> _initPool;
        
        public Pool(T prefab, int count, Transform container)
        {
            _initPrefab = prefab;
            _initContainer = container;
            _initPool = new Queue<T>(count);

            for (int i = 0; i < count; i++)
            {
                _initPool.Enqueue(CreateObject());
            }
        }

        public T Get()
        {
            if (_initPool.TryDequeue(out T obj))
            {
                return obj;
            }

            return CreateObject();
        }
        
        public void Release(T obj)
        {
            _initPool.Enqueue(obj);
        }

        private T CreateObject()
        {
            return Object.Instantiate(_initPrefab, _initContainer);
        }
    }
}