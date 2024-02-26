using System;

namespace Atomic.Elements
{
    [Serializable]
    public sealed class AtomicOrExpression : AtomicExpression<bool>
    {
        public override bool Invoke()
        {
            for (int i = 0, count = Members.Count; i < count; i++)
            {
                if (Members[i].Value)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
