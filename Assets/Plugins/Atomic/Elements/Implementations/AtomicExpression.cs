using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Atomic.Elements
{
    [Serializable]
    public abstract class AtomicExpression<T> : IAtomicExpression<T>
    {
        [ShowInInspector]
        protected readonly List<IAtomicValue<T>> Members = new();

        public IAtomicExpression<T> AddMember(IAtomicValue<T> member)
        {
            Members.Add(member);
            return this;
        }

        public IAtomicExpression<T> RemoveMember(IAtomicValue<T> member)
        {
            Members.Remove(member);
            return this;
        }

        public abstract T Invoke();

        public static implicit operator T(AtomicExpression<T> atomic)
        {
            return atomic.Invoke();
        }
    }
}
