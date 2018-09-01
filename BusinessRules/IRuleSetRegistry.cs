using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules
{
    public interface IRuleSetRegistry
    {
        RuleSetKey Register<RuleSetType>();

        IList<IRuleSet> Get<Model, Context>();

        IRuleSet Resolve<Model, Context>(string selector);
    }

}
