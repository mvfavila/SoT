using SoT.Infra.Data.Interfaces;

namespace SoT.Application.Interfaces
{
    public interface IBaseAppService<TContext> where TContext : IDbContext
    {
        void BeginTransaction();

        void Commit();
    }
}
