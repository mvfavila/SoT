using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;

namespace SoT.Domain.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository claimRepository;
        private readonly IClaimReadOnlyRepository claimReadOnlyRepository;

        public ClaimService(
            IClaimRepository claimRepository,
            IClaimReadOnlyRepository claimReadOnlyRepository)
        {
            this.claimRepository = claimRepository;
            this.claimReadOnlyRepository = claimReadOnlyRepository;
        }

        public ValidationResult Add(Claim claim)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Claim> Find(Expression<Func<Claim, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Claim> GetActive()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Claim> GetAll()
        {
            throw new NotImplementedException();
        }

        public Claim GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Claim claim)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
