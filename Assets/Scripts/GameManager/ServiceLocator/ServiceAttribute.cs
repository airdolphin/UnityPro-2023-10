using System;
using JetBrains.Annotations;

namespace ShootEmUp
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ServiceAttribute : Attribute
    {
        public readonly Type contract;

        public ServiceAttribute(Type contract)
        {
            this.contract = contract;
        }
    }
}