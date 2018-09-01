using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessRules.Models;

namespace BusinessRules.Rules.Person
{
    public class LastNameCannotBeBlank : IRuleAsync<Models.Person, DefaultContext>
    {
        public string Message => "Last name cannot be blank";

        public Task<bool> IsSatisfiedBy(Models.Person t, DefaultContext c)
        {
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(3000);
                return !string.IsNullOrEmpty(t.LastName);
            });
        }
    }
}
