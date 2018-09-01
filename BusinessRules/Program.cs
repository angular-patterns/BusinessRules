using BusinessRules.RuleSets.Person;
using System;

namespace BusinessRules
{
    class Program
    {
        static void Main(string[] args)
        {
            var registry = new RuleSetRegistry(new TypeResolver());
            registry.Register<PersonRuleSet>();

            var ruleSets = registry.Get<Models.Person, DefaultContext>();

            var rules = ruleSets[0].Rules;

            var reviewRunner = new ReviewRunner(registry, new TypeResolver());
            var result = reviewRunner.Run(new Models.Person(), new DefaultContext());
            Console.WriteLine("Hello World!");
        }
    }
}
