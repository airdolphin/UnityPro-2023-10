using System;
using Atomic.Elements;

namespace Atomics.Extensions
{
    public static class AtomicElementsExtensions
    {
        public static AtomicValue<T> AsValue<T>(this T it)
        {
            return new AtomicValue<T>(it);
        }

        public static AtomicVariable<T> AsVariable<T>(this T it)
        {
            return new AtomicVariable<T>(it);
        }

        public static AtomicFunction<TResult> AsFunction<T, TResult>(this T it, Func<T, TResult> func)
        {
            return new AtomicFunction<TResult>(() => func.Invoke(it));
        }

        public static IAtomicValue<bool> Negate(this IAtomicValue<bool> boolValue)
        {
            return boolValue.AsFunction(value => !value.Value);
        }
    }
}
