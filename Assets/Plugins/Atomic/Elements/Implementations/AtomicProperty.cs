using System;
using Sirenix.OdinInspector;

namespace Atomic.Elements
{
    [Serializable]
    public sealed class AtomicProperty<T> : IAtomicVariable<T>
    {
        [ShowInInspector, DisableInEditorMode]
        public T Value
        {
            get => _getter != null ? _getter.Invoke() : default;
            set => _setter?.Invoke(value);
        }

        private Func<T> _getter;
        private Action<T> _setter;

        public AtomicProperty()
        {
        }

        public AtomicProperty(Func<T> getter, Action<T> setter)
        {
            _getter = getter;
            _setter = setter;
        }

        public void Compose(Func<T> getter, Action<T> setter)
        {
            _getter = getter;
            _setter = setter;
        }

        public static implicit operator T(AtomicProperty<T> atomic)
        {
            return atomic.Value;
        }
    }
}
