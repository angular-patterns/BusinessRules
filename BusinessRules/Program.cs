using BusinessRules.Common;
using BusinessRules.Core;
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
            registry.Register<PersonRuleSet2>();

            var ruleSets = registry.Get<Models.Person, DefaultContext>();

            var rules = ruleSets[0].Rules;

            var reviewRunner = new ReviewRunner(registry, new TypeResolver());
            var result = reviewRunner.Run(new Models.Person(), new DefaultContext(), "Save.Person");
            var result2 = reviewRunner.Run(new Models.Person(), new DefaultContext(), "Update.Person");
            Console.WriteLine("Hello World!");
        }
    }
}
