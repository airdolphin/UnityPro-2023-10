using System.Collections.Generic;

namespace Atomic.Objects
{
    internal sealed class AtomicObjectInfo
    {
        internal readonly IEnumerable<string> Types;
        internal readonly IEnumerable<ReferenceInfo> References;
        internal readonly IEnumerable<SectionInfo> Sections;

        internal AtomicObjectInfo(
            IEnumerable<string> types,
            IEnumerable<ReferenceInfo> references,
            IEnumerable<SectionInfo> sections
        )
        {
            Types = types;
            References = references;
            Sections = sections;
        }
    }
}
