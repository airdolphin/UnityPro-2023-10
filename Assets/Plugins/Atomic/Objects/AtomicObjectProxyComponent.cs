using System.Collections.Generic;
using UnityEngine;

namespace Atomic.Objects
{
    [AddComponentMenu("Atomic/Atomic Object Proxy")]
    public sealed class AtomicObjectProxyComponent : MonoBehaviour, IAtomicObject
    {
        [SerializeField]
        public AtomicObjectComponent _source;

        public T Get<T>(string key) where T : class
        {
            return this._source.Get<T>(key);
        }

        public bool TryGet<T>(string key, out T result) where T : class
        {
            return this._source.TryGet(key, out result);
        }

        public object Get(string key)
        {
            return this._source.Get(key);
        }

        public bool TryGet(string key, out object result)
        {
            return this._source.TryGet(key, out result);
        }

        public IEnumerable<string> GetTypes()
        {
            return this._source.GetTypes();
        }

        public IEnumerable<KeyValuePair<string, object>> GetAll()
        {
            return this._source.GetAll();
        }

        public bool Is(string type)
        {
            return this._source.Is(type);
        }
    }
}
