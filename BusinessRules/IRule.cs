using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules
{
    public interface IRule<Model, Context>
    {
        string Message { get;  }
        bool IsSatisfiedBy(Model t, Context c);
    }
}
