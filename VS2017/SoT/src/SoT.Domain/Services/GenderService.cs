using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace SoT.Domain.Services
{
    public class GenderService : BaseService<Gender>, IGenderService
    {
        private readonly IGenderReadOnlyRepository genderReadOnlyRepository;

        public GenderService(IGenderReadOnlyRepository genderReadOnlyRepository)
            : base(null, genderReadOnlyRepository)
        {
            this.genderReadOnlyRepository = genderReadOnlyRepository;
        }

        public IEnumerable<Gender> GetAllActive()
        {
            const bool ACTIVE = true;

            return genderReadOnlyRepository.GetAllBySituation(ACTIVE);
        }
    }
}
