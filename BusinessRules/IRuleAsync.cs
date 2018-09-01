using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules
{
    public interface IRuleAsync<Model, Context>
    {
        string Message { get; }
        Task<bool> IsSatisfiedBy(Model t, Context c);
    }
}
