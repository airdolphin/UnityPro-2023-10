using System;

namespace Core
{
    public interface IAtomicValue<T>
    {
        T Value { get; }
    }

    class AtomicValue<T> : IAtomicValue<T>
    {
        public T Value => _function.Invoke();

        private readonly Func<T> _function;

        public AtomicValue(Func<T> function)
        {
            _function = function;
        }
    }
}