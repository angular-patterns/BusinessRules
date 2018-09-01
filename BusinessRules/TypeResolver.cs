using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules
{
    public class TypeResolver : ITypeResolver
    {
        public T Resolve<T>(Type type)
        {
            return (T) Activator.CreateInstance(type);
        }
    }
}
