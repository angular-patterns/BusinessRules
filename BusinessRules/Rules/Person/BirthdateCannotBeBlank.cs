using System;
using System.Collections.Generic;
using System.Text;
using BusinessRules.Common;
using BusinessRules.Models;

namespace BusinessRules.Rules.Person
{
    public class BirthdateCannotBeBlank : IRule<Models.Person, DefaultContext>
    {

        public string Message => "Birthdate cannot be null";

        public bool IsSatisfiedBy(Models.Person t, DefaultContext c)
        {
            return t.Birthdate != null;
        }
    }
}
