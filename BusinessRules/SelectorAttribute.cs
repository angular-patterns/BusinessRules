using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules
{
    public class SelectorAttribute: Attribute
    {
        public string Category { get; set; }

        public string SubCategory { get; set; }

        public SelectorAttribute(string category = null, string subCategory = null)
        {
            this.Category = category;
            this.SubCategory = subCategory;
        }
    }
}
