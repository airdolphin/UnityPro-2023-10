using Atomic.Elements;
using Atomic.Objects;

namespace Atomics.Extensions
{
    public static class AtomicObjectExtensions
    {
        public static IAtomicValue<T> GetValue<T>(this IAtomicObject it, string name)
        {
            return it.Get<IAtomicValue<T>>(name);
        }

        public static bool TryGetValue<T>(this IAtomicObject it, string name, out IAtomicValue<T> value)
        {
            return it.TryGet<IAtomicValue<T>>(name, out value);
        }

        public static IAtomicVariable<T> GetVariable<T>(this IAtomicObject it, string name)
        {
            return it.Get<IAtomicVariable<T>>(name);
        }

        public static bool TryGetVariable<T>(this IAtomicObject it, string name, out IAtomicVariable<T> variable)
        {
            return it.TryGet<IAtomicVariable<T>>(name, out variable);
        }

        public static IAtomicFunction<T> GetFunction<T>(this IAtomicObject it, string name)
        {
            return it.Get<IAtomicFunction<T>>(name);
        }

        public static bool TryGetFunction<T>(this IAtomicObject it, string name, out IAtomicFunction<T> function)
        {
            return it.TryGet<IAtomicFunction<T>>(name, out function);
        }

        public static IAtomicFunction<T1, T2> GetFunction<T1, T2>(this IAtomicObject it, string name)
        {
            return it.Get<IAtomicFunction<T1, T2>>(name);
        }

        public static bool TryGetFunction<T1, T2>(this IAtomicObject it, string name,
            out IAtomicFunction<T1, T2> function)
        {
            return it.TryGet<IAtomicFunction<T1, T2>>(name, out function);
        }

        public static IAtomicFunction<T1, T2, T3> GetFunction<T1, T2, T3>(this IAtomicObject it, string name)
        {
            return it.Get<IAtomicFunction<T1, T2, T3>>(name);
        }

        public static bool TryGetFunction<T1, T2, T3>(this IAtomicObject it, string name,
            out IAtomicFunction<T1, T2, T3> function)
        {
            return it.TryGet<IAtomicFunction<T1, T2, T3>>(name, out function);
        }

        public static IAtomicAction GetAction(this IAtomicObject it, string name)
        {
            return it.Get<IAtomicAction>(name);
        }

        public static bool TryGetAction(this IAtomicObject it, string name, out IAtomicAction action)
        {
            return it.TryGet<IAtomicAction>(name, out action);
        }

        public static IAtomicAction<T> GetAction<T>(this IAtomicObject it, string name)
        {
            return it.Get<IAtomicAction<T>>(name);
        }

        public static bool TryGetAction<T>(this IAtomicObject it, string name, out IAtomicAction<T> action)
        {
            return it.TryGet<IAtomicAction<T>>(name, out action);
        }

        public static IAtomicObservable<T> GetObservable<T>(this IAtomicObject it, string name)
        {
            return it.Get<IAtomicObservable<T>>(name);
        }

        public static bool TryGetObservable<T>(this IAtomicObject it, string name, out IAtomicObservable<T> observable)
        {
            return it.TryGet<IAtomicObservable<T>>(name, out observable);
        }

        public static IAtomicObservable GetObservable(this IAtomicObject it, string name)
        {
            return it.Get<IAtomicObservable>(name);
        }

        public static bool TryGetObservable(this IAtomicObject it, string name, out IAtomicObservable observable)
        {
            return it.TryGet<IAtomicObservable>(name, out observable);
        }

        public static IAtomicExpression<T> GetExpression<T>(this IAtomicObject it, string name)
        {
            return it.Get<IAtomicExpression<T>>(name);
        }

        public static bool TryGetExpression<T>(this IAtomicObject it, string name, out IAtomicExpression<T> expression)
        {
            return it.TryGet<IAtomicExpression<T>>(name, out expression);
        }
    }
}
