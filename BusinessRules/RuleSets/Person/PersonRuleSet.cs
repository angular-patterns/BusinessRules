using BusinessRules.Rules.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules.RuleSets.Person
{
    public class PersonRuleSet : BaseRuleSet<Models.Person, DefaultContext>, IRuleSet
    {

        public PersonRuleSet()
        {
            AddRule<FirstNameCannotBeBlank>("00001");
            AddRule<LastNameCannotBeBlank>("00002");
            AddRule<BirthdateCannotBeBlank>("00003");
        }
    }
}
