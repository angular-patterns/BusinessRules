using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules
{
    public interface IRuleSet
    {
        IEnumerable<RuleMetadata> Rules { get; }
    }
}
