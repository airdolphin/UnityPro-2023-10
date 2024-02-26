using System;

namespace Core
{
    public interface IAtomicVariable<T> : IAtomicValue<T>
    {
        event Action<T> ValueChanged;
        new T Value { get; set; }
    }
}