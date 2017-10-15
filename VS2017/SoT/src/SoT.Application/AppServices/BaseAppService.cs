using SoT.Application.Interfaces;
using SoT.Infra.Data.Interfaces;

namespace SoT.Application.AppServices
{
    public class BaseAppService : IBaseAppService
    {
        private IUnitOfWork unitOfWork;

        public void BeginTransaction()
        {
            // TODO: unitOfWork must be innitialized here
            unitOfWork.BeginTransaction();
        }

        public void Commit()
        {
            unitOfWork.SaveChanges();
        }
    }
}
