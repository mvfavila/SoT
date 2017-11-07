﻿using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SoT.Domain.Services
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns>See <see cref="IClaimService.GetAll()"/>.</returns>
        public IEnumerable<Claim> GetAll()
        {
            return claimReadOnlyRepository.GetAll();
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
            GC.SuppressFinalize(this);
        }
    }
}
