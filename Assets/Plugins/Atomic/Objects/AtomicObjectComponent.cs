using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Profiling;

namespace Atomic.Objects
{
    public abstract class AtomicObjectComponent : MonoBehaviour, IAtomicObject
    {
        [PropertyOrder(100)]
        [HideInEditorMode]
        [SerializeField]
        private AtomicObject _atomicObject;

        /// <summary>
        ///     <para>Constructor for atomic object</para>
        /// </summary>
        public virtual void Compose()
        {
#if UNITY_EDITOR
            Profiler.BeginSample("AtomicObject.Compose", this);
#endif
            _atomicObject.Compose(this);

#if UNITY_EDITOR
            Profiler.EndSample();
#endif
        }

        public T Get<T>(string key)
            where T : class
        {
            return _atomicObject.Get<T>(key);
        }

        public bool TryGet<T>(string key, out T result)
            where T : class
        {
            return _atomicObject.TryGet(key, out result);
        }

        public object Get(string key)
        {
            return _atomicObject.Get(key);
        }

        public bool TryGet(string key, out object result)
        {
            return _atomicObject.TryGet(key, out result);
        }

        public IEnumerable<KeyValuePair<string, object>> GetAll()
        {
            return _atomicObject.GetAll();
        }

        public bool Is(string type)
        {
            return _atomicObject.Is(type);
        }

        public IEnumerable<string> GetTypes()
        {
            return _atomicObject.GetTypes();
        }
    }
}
