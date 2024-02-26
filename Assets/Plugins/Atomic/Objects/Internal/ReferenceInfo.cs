using System;

namespace Atomic.Objects
{
    internal sealed class ReferenceInfo
    {
        internal readonly string Id;
        internal readonly bool Override;
        internal readonly Func<object, object> Value;

        internal ReferenceInfo(string id, bool @override, Func<object, object> value)
        {
            Id = id;
            Override = @override;
            Value = value;
        }
    }
}
