namespace BusinessRules.Common
{
    public interface IRule<Model, Context>
    {
        string Message { get;  }
        bool IsSatisfiedBy(Model t, Context c);
    }
}
