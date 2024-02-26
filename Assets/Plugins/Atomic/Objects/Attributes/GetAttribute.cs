using System;
using JetBrains.Annotations;

namespace Atomic.Objects
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
    public sealed class GetAttribute : Attribute
    {
        internal readonly string Id;
        internal readonly bool Override;

        public GetAttribute(string id, bool @override = false)
        {
            Id = id;
            Override = @override;
        }
    }
}
