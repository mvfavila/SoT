using SoT.Infra.Data.Context;
using SoT.Infra.Data.Interfaces;

namespace SoT.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SoTContext dbContext;
        private readonly ContextManager contextManager;

        public void BeginTransaction()
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
