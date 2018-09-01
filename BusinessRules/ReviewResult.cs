using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules
{
    public class ReviewResult
    {
        public string Selector { get; set; }

        public bool Success { get; set; }

        public IList<ReviewRule> Rules { get; set; }
    }
}
