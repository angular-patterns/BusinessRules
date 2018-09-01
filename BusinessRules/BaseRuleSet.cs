using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules
{
    public class BaseRuleSet<T, C> : ITypedRuleSet<T, C>
    {
        protected IDictionary<string, RuleMetadata> RuleMap;

        public BaseRuleSet()
        {
            this.RuleMap = new Dictionary<string, RuleMetadata>();
        }

        public IEnumerable<RuleMetadata> Rules => RuleMap.Values;

        public RuleMetadata AddRule<RuleType>(string businessId) where RuleType : IRule<T, C>
        {
            var metadata = new RuleMetadata
            {
                BusinessId = businessId,
                ModelType = typeof(T),
                ContextType = typeof(C),
                RuleType = typeof(RuleType),
                IsAsync = false
            };
            this.RuleMap.Add(businessId, metadata);

            return metadata;
        }
        public RuleMetadata AddRuleAsync<RuleType>(string businessId) where RuleType : IRuleAsync<T, C>
        {
            var metadata = new RuleMetadata
            {
                BusinessId = businessId,
                ModelType = typeof(T),
                ContextType = typeof(C),
                RuleType = typeof(RuleType),
                IsAsync = true
            };
            this.RuleMap.Add(businessId, metadata);

            return metadata;
        }



    }
}
