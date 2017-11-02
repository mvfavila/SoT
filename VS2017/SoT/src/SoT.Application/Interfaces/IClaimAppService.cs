using SoT.Application.Validation;
using SoT.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace SoT.Application.Interfaces
{
    public interface IClaimAppService : IDisposable
    {
        IEnumerable<ClaimViewModel> GetActive();

        // TODO: paging should be added to method.
        IEnumerable<ClaimViewModel> GetAll();

        ClaimViewModel GetById(Guid id);

        ValidationAppResult Add(ClaimViewModel claimViewModel);

        void Update(ClaimViewModel claimViewModel);

        void Delete(Guid id);
    }
}
