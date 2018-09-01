using BusinessRules.Common;
using BusinessRules.Rules.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules.RuleSets.Person
{
    [Selector(Category = "Update", SubCategory = "Person")]
    public class PersonRuleSet2 : BaseRuleSet<Models.Person, DefaultContext>, IRuleSet
    {

        public PersonRuleSet2()
        {
            AddRule<FirstNameCannotBeBlank>("00001");
            AddRuleAsync<LastNameCannotBeBlank>("00002");
            AddRule<BirthdateCannotBeBlank>("00003");
        }
    }
}
