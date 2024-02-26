using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Atomic.Elements
{
    [Serializable]
    public class AtomicVariable<T> : IAtomicVariable<T>, IAtomicObservable<T>, IDisposable
    {
        private Action<T> _onChanged;

        [OnValueChanged(nameof(OnValueChanged))]
        [SerializeField]
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChanged(value);
            }
        }

        public AtomicVariable(T value = default)
        {
            _value = value;
        }

        public void Subscribe(Action<T> listener)
        {
            _onChanged += listener;
        }

        public void Unsubscribe(Action<T> listener)
        {
            _onChanged -= listener;
        }

        public void Dispose()
        {
            AtomicUtils.Dispose(ref _onChanged);
        }

        private void OnValueChanged(T value)
        {
            _onChanged?.Invoke(value);
        }

        public static implicit operator T(AtomicVariable<T> atomic)
        {
            return atomic.Value;
        }
    }
}
