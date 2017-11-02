using SoT.Domain.Interfaces.Repository;
using SoT.Infra.Data.Context;
using System.Security.Claims;

namespace SoT.Infra.Data.Repositories
{
    public class ClaimRepository : BaseRepository<Claim, SoTContext>, IClaimRepository
    {
    }
}
