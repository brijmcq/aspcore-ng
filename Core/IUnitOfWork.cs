using System.Threading.Tasks;

namespace asp_ng.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
