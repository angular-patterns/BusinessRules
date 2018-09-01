using System.Collections.Generic;

namespace BusinessRules.Common
{
    public interface IRuleSet
    {
        IEnumerable<RuleMetadata> Rules { get; }
    }
}
