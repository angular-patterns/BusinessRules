using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules
{
    public class RuleMetadata
    {
        public string BusinessId { get; set; }
        public Type ModelType { get; set; }

        public Type ContextType { get;set; }

        public Type RuleType { get; set; }

        public bool IsAsync { get; set; }
    }
}
