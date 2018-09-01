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
            return ruleSets.Where(t =>
            {
                SelectorAttribute[] attributes = (SelectorAttribute[]) t.GetType().GetCustomAttributes(typeof(SelectorAttribute), true);
                return attributes.Any(x => x.Category == category && x.SubCategory == subCategory);
            }).First();
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
