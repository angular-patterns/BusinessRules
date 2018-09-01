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

        public override string ToString()
        {
            var category = (Category ?? string.Empty).Trim();
            var subCategory = (SubCategory ?? string.Empty).Trim();

            if (subCategory == string.Empty)
                return category;
            else
                return $"{category}.{subCategory}";
            
        }
    }
}
