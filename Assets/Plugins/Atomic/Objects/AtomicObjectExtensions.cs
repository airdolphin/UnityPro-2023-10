using System;
using System.Collections.Generic;

namespace Atomic.Objects
{
    public static class AtomicObjectExtensions
    {
        public static void AddComponent(this AtomicObject it, object component, bool @override = true)
        {
            Type componentType = component.GetType();

            IEnumerable<string> types = AtomicScanner.ScanTypes(componentType);
            it.AddTypes(types);

            IEnumerable<ReferenceInfo> references = AtomicScanner.ScanReferences(componentType);

            if (@override)
            {
                foreach (var reference in references)
                {
                    string key = reference.Id;
                    object value = reference.Value(component);

                    if (reference.Override)
                    {
                        it.SetData(key, value);
                    }
                    else
                    {
                        it.AddData(key, value);
                    }
                }
            }
            else
            {
                foreach (var reference in references)
                {
                    string key = reference.Id;
                    object value = reference.Value(component);
                    it.AddData(key, value);
                }
            }
        }

        public static void RemoveComponent(this AtomicObject it, object component)
        {
            it.RemoveComponent(component.GetType());
        }

        public static void RemoveComponent<T>(this AtomicObject it)
        {
            it.RemoveComponent(typeof(T));
        }

        public static void RemoveComponent(this AtomicObject it, Type componentType)
        {
            IEnumerable<string> types = AtomicScanner.ScanTypes(componentType);
            it.RemoveTypes(types);

            IEnumerable<ReferenceInfo> references = AtomicScanner.ScanReferences(componentType);
            foreach (var reference in references)
            {
                it.RemoveData(reference.Id);
            }
        }

        public static void CopyDataFrom(this AtomicObject it, IAtomicObject other, bool @override = true)
        {
            if (@override)
            {
                foreach (var (key, value) in other.GetAll())
                {
                    it.SetData(key, value);
                }
            }
            else
            {
                foreach (var (key, value) in other.GetAll())
                {
                    it.AddData(key, value);
                }
            }
        }

        public static void CopyTypesFrom(this AtomicObject it, IAtomicObject other)
        {
            it.AddTypes(other.GetTypes());
        }

        public static void Compose(this AtomicObject atomicObject, object source)
        {
            AtomicObjectInfo objectInfo = AtomicCompiler.CompileObject(source.GetType());

            atomicObject.AddTypes(objectInfo.Types);
            atomicObject.AddReferences(source, objectInfo.References);
            atomicObject.AddSections(source, objectInfo.Sections);
        }

        private static void AddReferences(this AtomicObject atomicObject, object source, IEnumerable<ReferenceInfo> definitions)
        {
            foreach (ReferenceInfo definition in definitions)
            {
                string id = definition.Id;
                object value = definition.Value(source);

                if (definition.Override)
                {
                    atomicObject.References[id] = value;
                    continue;
                }

                atomicObject.References.TryAdd(id, value);
            }
        }

        private static void AddSections(this AtomicObject atomicObject, object parent, IEnumerable<SectionInfo> definitions)
        {
            foreach (var definition in definitions)
            {
                object section = definition.GetValue(parent);

                atomicObject.AddTypes(definition.Types);
                atomicObject.AddReferences(section, definition.References);
                atomicObject.AddSections(section, definition.Children);
            }
        }
    }
}
