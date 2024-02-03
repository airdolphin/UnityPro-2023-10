using System;
using System.Collections.Generic;

namespace ShootEmUp
{
    public interface IServiceProvider
    {
        IEnumerable<(Type, object)> ProvideServices();
    }
}