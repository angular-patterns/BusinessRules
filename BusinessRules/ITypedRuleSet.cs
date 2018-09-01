using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules
{
    public interface ITypedRuleSet<T, C>: IRuleSet
    {
        RuleMetadata AddRule<RuleType>(string businessId) where RuleType: IRule<T,C>;
    }
}
