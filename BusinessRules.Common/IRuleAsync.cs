using System.Threading.Tasks;

namespace BusinessRules.Common
{
    public interface IRuleAsync<Model, Context>
    {
        string Message { get; }
        Task<bool> IsSatisfiedBy(Model t, Context c);
    }
}
