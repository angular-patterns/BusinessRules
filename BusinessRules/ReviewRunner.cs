using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRules
{
    public class ReviewRunner : IReviewRunner
    {
        private IRuleSetRegistry registry;
        private ITypeResolver typeResolver;

        public ReviewRunner(IRuleSetRegistry registry, ITypeResolver typeResolver)
        {
            this.registry = registry;
            this.typeResolver = typeResolver;
        }
        public ReviewResult Run<Model, Context>(Model model, Context context)
        {
            var ruleSet = this.registry.Get<Model, Context>().First();

            var reviewRules = ruleSet.Rules.Select(t =>
            {
                var rule = typeResolver.Resolve<IRule<Model, Context>>(t.RuleType);

                return new ReviewRule()
                {
                    BusinessId = t.BusinessId,
                    Message = rule.Message,
                    IsSatisfied = rule.IsSatisfiedBy(model, context)
                };
            }).ToList();

            return new ReviewResult()
            {
                Rules = reviewRules,
                Success = reviewRules.All(t=>t.IsSatisfied)
            };
        }
    }
}
