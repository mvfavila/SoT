using SoT.Domain.Interfaces.Repository.ReadOnly;
using System;

namespace SoT.Infra.Data.Repositories.ReadOnly
{
    public class ClaimReadOnlyRepository : BaseReadOnlyRepository, IClaimReadOnlyRepository
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
