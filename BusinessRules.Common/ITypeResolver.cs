using System;

namespace BusinessRules.Common
{
    public interface ITypeResolver
    {
        T Resolve<T>(Type type);
    }
}
