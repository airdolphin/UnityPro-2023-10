using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class ServiceLocator : MonoBehaviour
    {
        private readonly Dictionary<Type, object> _services = new();

        public object GetService(Type type)
        {
            return _services[type];
        }

        public T GetService<T>() where T : class
        {
            return _services[typeof(T)] as T;
        }

        public void BindService(Type type, object service)
        {
            _services.Add(type, service);
        }
    }
}