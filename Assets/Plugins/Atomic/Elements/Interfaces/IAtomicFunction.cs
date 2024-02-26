namespace Atomic.Elements
{
    public interface IAtomicFunction<out TResult> : IAtomicValue<TResult>
    {
        TResult Invoke();

        TResult IAtomicValue<TResult>.Value => Invoke();
    }

    public interface IAtomicFunction<in T, out TResult>
    {
        TResult Invoke(T args);
    }
    
    public interface IAtomicFunction<in T1, in T2, out TResult>
    {
        TResult Invoke(T1 args1, T2 args2);
    }
}
