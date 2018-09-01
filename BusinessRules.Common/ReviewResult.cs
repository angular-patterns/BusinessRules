using System.Collections.Generic;

namespace BusinessRules.Common
{
    public class ReviewResult
    {
        public string Selector { get; set; }

        public bool Success { get; set; }

        public IList<ReviewRule> Rules { get; set; }
    }
}
