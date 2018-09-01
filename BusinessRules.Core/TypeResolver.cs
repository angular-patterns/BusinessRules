using BusinessRules.Common;
using System;

namespace BusinessRules.Core
{
    public class TypeResolver : ITypeResolver
    {
        public T Resolve<T>(Type type)
        {
            return (T) Activator.CreateInstance(type);
        }
    }
}
