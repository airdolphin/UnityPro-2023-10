using System.Collections.Generic;
using System.Reflection;

namespace Atomic.Objects
{
    internal sealed class SectionInfo
    {
        internal readonly IEnumerable<string> Types;
        internal readonly IEnumerable<ReferenceInfo> References;
        internal readonly IEnumerable<SectionInfo> Children;

        private readonly FieldInfo _field;

        internal SectionInfo(
            IEnumerable<string> types,
            IEnumerable<ReferenceInfo> references,
            IEnumerable<SectionInfo> children,
            FieldInfo field
        )
        {
            Types = types;
            References = references;
            Children = children;
            _field = field;
        }

        internal object GetValue(object parent)
        {
            return _field.GetValue(parent);
        }
    }
}
