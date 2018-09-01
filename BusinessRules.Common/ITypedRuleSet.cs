namespace BusinessRules.Common
{
    public interface ITypedRuleSet<T, C>: IRuleSet
    {
        RuleMetadata AddRule<RuleType>(string businessId) where RuleType: IRule<T,C>;
    }
}
