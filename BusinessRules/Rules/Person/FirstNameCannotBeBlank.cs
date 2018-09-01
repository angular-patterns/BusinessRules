using System;
using System.Collections.Generic;
using System.Text;
using BusinessRules.Models;

namespace BusinessRules.Rules.Person
{
    public class FirstNameCannotBeBlank : IRule<Models.Person, DefaultContext>
    {
        public string Message => "First name cannot be blank";

        public bool IsSatisfiedBy(Models.Person t, DefaultContext c)
        {
            return t.FirstName != string.Empty;
        }
    }
}
