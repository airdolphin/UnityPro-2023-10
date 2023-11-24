using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Pool<T> where T : MonoBehaviour
    // public class Pool<T> : MonoBehaviour where T : Object
    {
        private readonly T initPrefab;
        private readonly Transform initContainer;
        private readonly Queue<T> initPool;
        
        public Pool(T prefab, int count, Transform container)
        {
            initPrefab = prefab;
            initContainer = container;
            initPool = new Queue<T>(count);

            for (int i = 0; i < count; i++)
            {
                initPool.Enqueue(CreateObject());
            }
        }

        public T Get()
        {
            if (initPool.TryDequeue(out T obj))
            {
                return obj;
            }

            return CreateObject();
        }
        
        public void Release(T obj)
        {
            initPool.Enqueue(obj);
        }

        private T CreateObject()
        {
            return Object.Instantiate(initPrefab, initContainer);
        }
    }
}