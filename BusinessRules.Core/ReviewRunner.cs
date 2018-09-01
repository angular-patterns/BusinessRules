using BusinessRules.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRules.Core
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
        public async Task<ReviewResult> RunAsync<Model, Context>(Model model, Context context, string selector = null)
        {
            var ruleSet = this.registry.Resolve<Model, Context>(selector);

            var tasks = ruleSet.Rules.Select(t =>
            {
                return t.IsAsync ? EvaluateRuleAsync(t, model, context) :
                    Task.FromResult(EvaluateRule(t, model, context));
            }).ToArray();

            var reviewRules = await Task.WhenAll(tasks);
            
            return new ReviewResult()
            {
                Selector = selector,
                Rules = reviewRules,
                Success = reviewRules.All(t=>t.IsSatisfied)
            };
        }
        public ReviewResult Run<Model, Context>(Model model, Context context, string selector = null)
        {
            return RunAsync(model, context, selector).Result;
        }

        public ReviewRule EvaluateRule<Model, Context>(
             RuleMetadata metadata, Model model, Context context)
        {
            var rule = typeResolver.Resolve<IRule<Model, Context>>(metadata.RuleType);
            return new ReviewRule()
            {
                BusinessId = metadata.BusinessId,
                Message = rule.Message,
                IsSatisfied = rule.IsSatisfiedBy(model, context)
            };

        }

        public async Task<ReviewRule> EvaluateRuleAsync<Model, Context>(
            RuleMetadata metadata, Model model, Context context)
        {
            var rule = typeResolver.Resolve<IRuleAsync<Model, Context>>(metadata.RuleType);
            var result = await rule.IsSatisfiedBy(model, context);

            return new ReviewRule
            {
                BusinessId = metadata.BusinessId,
                Message = rule.Message,
                IsSatisfied = result
            };
        }

      
    }
}
