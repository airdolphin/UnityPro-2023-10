using System;
using Sirenix.OdinInspector;

namespace Atomic.Elements
{
    [Serializable]
    public class AtomicAction : IAtomicAction
    {
        private Action _action;

        public AtomicAction()
        {
        }

        public AtomicAction(Action action)
        {
            _action = action;
        }

        public void Compose(Action action)
        {
            _action = action;
        }

        [Button]
        public void Invoke()
        {
            _action?.Invoke();
        }
    }

    [Serializable]
    public class AtomicAction<T> : IAtomicAction<T>
    {
        private Action<T> _action;

        public AtomicAction()
        {
        }

        public AtomicAction(Action<T> action)
        {
            _action = action;
        }
        
        public void Compose(Action<T> action)
        {
            _action = action;
        }

        [Button]
        public void Invoke(T arg)
        {
            _action?.Invoke(arg);
        }
    }
    
    [Serializable]
    public class AtomicAction<T1, T2> : IAtomicAction<T1, T2>
    {
        private Action<T1, T2> _action;

        public AtomicAction()
        {
        }

        public AtomicAction(Action<T1, T2> action)
        {
            _action = action;
        }
        
        public void Compose(Action<T1, T2> action)
        {
            _action = action;
        }

        [Button]
        public void Invoke(T1 args1, T2 args2)
        {
            _action?.Invoke(args1, args2);
        }
    }
    
    [Serializable]
    public class AtomicAction<T1, T2, T3> : IAtomicAction<T1, T2, T3>
    {
        private Action<T1, T2, T3> _action;

        public AtomicAction()
        {
        }

        public AtomicAction(Action<T1, T2, T3> action)
        {
            _action = action;
        }
        
        public void Compose(Action<T1, T2, T3> action)
        {
            _action = action;
        }

        [Button]
        public void Invoke(T1 args1, T2 args2, T3 args3)
        {
            _action?.Invoke(args1, args2, args3);
        }
    }
}
