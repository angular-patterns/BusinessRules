using BusinessRules.RuleSets.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRules
{
    public class RuleSetRegistry : IRuleSetRegistry
    {
        private IDictionary<RuleSetKey, IList<Type>> registry;
        private ITypeResolver typeResolver;

        public RuleSetRegistry (ITypeResolver typeResolver)
        {
            this.typeResolver = typeResolver;
            registry = new Dictionary<RuleSetKey, IList<Type>>();
        }


        public IList<IRuleSet> Get<ModelType, ContextType>()
        {
            var ruleSetKey = RuleSetKey.Create<ModelType, ContextType>();

            return this.registry[ruleSetKey].Select(t=>
            {
                return this.typeResolver.Resolve<IRuleSet>(t);
            }).ToList();
        }

        public IRuleSet Resolve<ModelType, ContextType>(string selector)
        {
            string category = null;
            string subCategory = null;

            selector = selector ?? string.Empty;
            var path = selector.Split('.');

            if (path.Length > 2)
                throw new Exception("Selector cannot have more than two segments");

            if (path.Length >= 1 && !string.IsNullOrEmpty(path[0]))
                category = path[0].Trim();

            if (path.Length == 2 && !string.IsNullOrEmpty(path[1]))
                subCategory = path[1].Trim();

            var ruleSets = Get<ModelType, ContextType>();
            ruleSets = ruleSets.Where(t =>
            {
                return GetSelectorAttribute(t, category, subCategory) != null;
            }).ToList();

            if (ruleSets.Count == 0)
                throw new ApplicationException($"Could not resolve a rule set with selector {selector}");
            if (ruleSets.Count > 1) {
                var selectorList = String.Join(',', ruleSets.Select(t => GetSelectorAttribute(t, category, subCategory).ToString()));
                throw new ApplicationException($"Multiple rule sets found with selector {selector}: [{selectorList}]");
            }

            return ruleSets.First();
        }

        private SelectorAttribute GetSelectorAttribute(IRuleSet ruleSet, string category, string subCategory)
        {
            SelectorAttribute[] attributes = (SelectorAttribute[])ruleSet.GetType().GetCustomAttributes(typeof(SelectorAttribute), true);

            return attributes
                .FirstOrDefault(t => (category == null || t.Category == category) && (subCategory == null || t.SubCategory == subCategory));
        }

        public RuleSetKey Register<RuleSetType>()
        {
            var ruleSetType = typeof(RuleSetType);
            var genericType = ruleSetType.GetInterfaces()
                .Where(i => i.IsGenericType)
                .FirstOrDefault(i => i.GetGenericTypeDefinition() == typeof(ITypedRuleSet<,>));

            if (genericType == null)
            {
                throw new ApplicationException($"Type {ruleSetType.Name} does not implement interface ITypedRuleSet");
            }
            

            var typeArgs = genericType.GetGenericArguments();

            var ruleSetKey = RuleSetKey.Create(typeArgs[0], typeArgs[1]);

            if (!this.registry.ContainsKey(ruleSetKey))
            {
                this.registry[ruleSetKey] = new List<Type>();
            }

            this.registry[ruleSetKey].Add(ruleSetType);

            return ruleSetKey;
        }


    }
}
