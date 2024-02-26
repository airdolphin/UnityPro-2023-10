using System;
using Atomic;

namespace Core
{
    public interface IAtomicEvent : IAtomicAction
    {
        void Subscribe(Action action);
        void Unsubscribe(Action action);
    }
    
    public interface IAtomicEvent<T> : IAtomicAction<T>
    {
        void Subscribe(Action<T> action);
        void Unsubscribe(Action<T> action);
    }
}