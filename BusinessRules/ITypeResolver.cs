using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules
{
    public interface ITypeResolver
    {
        T Resolve<T>(Type type);
    }
}
