using SoT.Application.Interfaces;
using SoT.Application.Validation;
using SoT.Application.ViewModels;
using SoT.Domain.Interfaces.Services;
using SoT.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace SoT.Application.AppServices
{
    public class ClaimAppService : BaseAppService<SoTContext>, IClaimAppService
    {
        private readonly IClaimService claimService;

        public ClaimAppService(
            IClaimService claimService)
        {
            this.claimService = claimService;
        }

        public ValidationAppResult Add(ClaimViewModel claimViewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClaimViewModel> GetActive()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClaimViewModel> GetAll()
        {
            var claims = claimService.GetAll();

            return Mapping.ClaimMapper.FromDomainToViewModel(claims);
        }

        public ClaimViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ClaimViewModel claimViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
