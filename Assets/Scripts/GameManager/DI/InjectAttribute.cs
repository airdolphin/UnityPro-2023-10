using System;
using JetBrains.Annotations;

namespace ShootEmUp
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
    public sealed class InjectAttribute : Attribute
    {
    }
}