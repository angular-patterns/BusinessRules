using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules
{
    public class ReviewRule
    {
        public string BusinessId { get; set; }

        public string Message { get; set; }

        public bool IsSatisfied { get; set; }
    }
}
