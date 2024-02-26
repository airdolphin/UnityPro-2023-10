using System;
using Sirenix.OdinInspector;

namespace Atomic.Elements
{
    [Serializable]
    public class AtomicEvent : IAtomicEvent, IDisposable
    {
        private Action _onEvent;

        public void Subscribe(Action action)
        {
            _onEvent += action;
        }

        public void Unsubscribe(Action action)
        {
            _onEvent -= action;
        }

        [Button]
        public virtual void Invoke()
        {
            _onEvent?.Invoke();
        }

        public void Dispose()
        {
            AtomicUtils.Dispose(ref _onEvent);
        }
    }

    [Serializable]
    public class AtomicEvent<T> : IAtomicEvent<T>, IDisposable
    {
        private Action<T> _onEvent;
        
        public void Subscribe(Action<T> action)
        {
            _onEvent += action;
        }

        public void Unsubscribe(Action<T> action)
        {
            _onEvent -= action;
        }

        [Button]
        public virtual void Invoke(T arg)
        {
            _onEvent?.Invoke(arg);
        }

        public void Dispose()
        {
            AtomicUtils.Dispose(ref _onEvent);
        }
    }
    
    [Serializable]
    public class AtomicEvent<T1, T2> : IAtomicEvent<T1, T2>, IDisposable
    {
        private Action<T1, T2> _onEvent;
        
        public void Subscribe(Action<T1, T2> action)
        {
            _onEvent += action;
        }

        public void Unsubscribe(Action<T1, T2> action)
        {
            _onEvent -= action;
        }

        [Button]
        public virtual void Invoke(T1 args1, T2 args2)
        {
            _onEvent?.Invoke(args1, args2);
        }

        public void Dispose()
        {
            AtomicUtils.Dispose(ref _onEvent);
        }
    }
    
    [Serializable]
    public class AtomicEvent<T1, T2, T3> : IAtomicEvent<T1, T2, T3>, IDisposable
    {
        private Action<T1, T2, T3> _onEvent;
        
        public void Subscribe(Action<T1, T2, T3> action)
        {
            _onEvent += action;
        }

        public void Unsubscribe(Action<T1, T2, T3> action)
        {
            _onEvent -= action;
        }

        [Button]
        public virtual void Invoke(T1 args1, T2 args2, T3 args3)
        {
            _onEvent?.Invoke(args1, args2, args3);
        }

        public void Dispose()
        {
            AtomicUtils.Dispose(ref _onEvent);
        }
    }
}
