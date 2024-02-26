using System;
using UnityEngine;

namespace Atomic.Elements
{
    [Serializable]
    public sealed class AtomicValue<T> : IAtomicValue<T>
    {
        [SerializeField]
        private T _value;

        public T Value => _value;

        public AtomicValue(T value = default)
        {
            _value = value;
        }

        public static implicit operator T(AtomicValue<T> atomic)
        {
            return atomic.Value;
        }
    }
}
