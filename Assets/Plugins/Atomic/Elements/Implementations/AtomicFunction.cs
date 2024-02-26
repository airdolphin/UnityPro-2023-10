using System;
using Sirenix.OdinInspector;

namespace Atomic.Elements
{
    [Serializable]
    public sealed class AtomicFunction<T> : IAtomicFunction<T>
    {
        private Func<T> _func;

        [ShowInInspector, ReadOnly]
        public T Value => _func != null ? _func.Invoke() : default;

        public AtomicFunction()
        {
        }

        public AtomicFunction(Func<T> func)
        {
            _func = func;
        }

        public void Compose(Func<T> func)
        {
            _func = func;
        }

        public T Invoke()
        {
            return _func != null ? _func.Invoke() : default;
        }

        public static implicit operator T(AtomicFunction<T> atomic)
        {
            return atomic.Value;
        }
    }

    [Serializable]
    public sealed class AtomicFunction<T, TResult> : IAtomicFunction<T, TResult>
    {
        private Func<T, TResult> _func;

        public AtomicFunction()
        {
        }

        public AtomicFunction(Func<T, TResult> func)
        {
            _func = func;
        }

        public void Compose(Func<T, TResult> func)
        {
            _func = func;
        }

        [Button]
        public TResult Invoke(T args)
        {
            return _func.Invoke(args);
        }
    }
}
