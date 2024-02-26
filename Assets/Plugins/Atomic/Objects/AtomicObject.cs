using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Atomic.Objects
{
    [Serializable]
    public class AtomicObject : IAtomicObject
    {
        [Title("Data"), PropertySpace, PropertyOrder(100)]
        [ShowInInspector]
        protected internal ISet<string> Types = new HashSet<string>();

        [ShowInInspector, PropertyOrder(100)]
        protected internal IDictionary<string, object> References = new Dictionary<string, object>();

        public bool Is(string type)
        {
            return Types.Contains(type);
        }

        public T Get<T>(string key)
            where T : class
        {
            return Get(key) as T;
        }

        public bool TryGet<T>(string key, out T result)
            where T : class
        {
            if (TryGet(key, out var value))
            {
                result = value as T;
                return true;
            }

            result = default;
            return false;
        }

        public object Get(string key)
        {
            return References[key];
        }

        public bool TryGet(string key, out object result)
        {
            return References.TryGetValue(key, out result);
        }

        public IEnumerable<string> GetTypes()
        {
            return Types;
        }

        public IEnumerable<KeyValuePair<string, object>> GetAll()
        {
            return References;
        }

        public bool AddData(string key, object value)
        {
            return References.TryAdd(key, value);
        }

        public void SetData(string key, object value)
        {
            References[key] = value;
        }

        public bool RemoveData(string key)
        {
            return References.Remove(key);
        }

        public void OverrideData(string key, object value, out object prevValue)
        {
            References.TryGetValue(key, out prevValue);
            References[key] = value;
        }

        public bool AddType(string type)
        {
            return Types.Add(type);
        }

        public void AddTypes(IEnumerable<string> types)
        {
            Types.UnionWith(types);
        }

        public bool RemoveType(string type)
        {
            return Types.Remove(type);
        }

        public void RemoveTypes(IEnumerable<string> types)
        {
            foreach (var type in types)
            {
                Types.Remove(type);
            }
        }
    }
}
