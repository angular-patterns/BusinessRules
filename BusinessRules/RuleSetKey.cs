using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules
{
    public class RuleSetKey
    {
        public Type ModelType { get; set; }

        public Type ContextType { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as RuleSetKey;

            if (other == null)
                return false;

            return ModelType.Equals(other.ModelType) &&
                ContextType.Equals(other.ContextType);
        }

        public override int GetHashCode()
        {
            var one = EqualityComparer<Type>.Default.GetHashCode(ModelType);
            var two = EqualityComparer<Type>.Default.GetHashCode(ContextType);
            return (one + '_' + two).GetHashCode();
        }

        public static RuleSetKey Create<Model, Context>()
        {
            return new RuleSetKey { ModelType = typeof(Model), ContextType = typeof(Context) };
        }

        public static RuleSetKey Create(Type model, Type context)
        {
            return new RuleSetKey { ModelType = model, ContextType = context };
        }
    }
}
