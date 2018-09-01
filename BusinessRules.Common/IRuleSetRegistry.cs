using System.Collections.Generic;

namespace BusinessRules.Common
{
    public interface IRuleSetRegistry
    {
        void Register<RuleSetType>();

        IList<IRuleSet> Get<Model, Context>();

        IRuleSet Resolve<Model, Context>(string selector);
    }

}
