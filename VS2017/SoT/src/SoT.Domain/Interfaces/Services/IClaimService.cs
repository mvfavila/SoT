using SoT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;

namespace SoT.Domain.Interfaces.Services
{
    public interface IClaimService : IDisposable
    {
        IEnumerable<Claim> GetActive();

        IEnumerable<Claim> GetAll();

        IEnumerable<Claim> Find(Expression<Func<Claim, bool>> predicate);

        Claim GetById(Guid id);

        ValidationResult Add(Claim claim);

        void Update(Claim claim);

        void Delete(Guid id);
    }
}
