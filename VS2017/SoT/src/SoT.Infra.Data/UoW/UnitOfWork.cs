using CommonServiceLocator;
using SoT.Infra.Data.Context;
using SoT.Infra.Data.Interfaces;
using System;

namespace SoT.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SoTContext dbContext;
        private readonly ContextManager contextManager =
            ServiceLocator.Current.GetInstance<IContextManager>() as ContextManager;
        private bool disposed;

        public UnitOfWork()
        {
            dbContext = contextManager.GetContext();
        }

        public void BeginTransaction()
        {
            disposed = false;
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
