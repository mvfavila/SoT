using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using SoT.Domain.ValueObjects;
using SoT.Domain.Validation.Adventure;

namespace SoT.Domain.Services
{
    public class AdventureService : BaseService<Adventure>, IAdventureService
    {
        private readonly IAdventureRepository adventureRepository;
        private readonly IAdventureReadOnlyRepository adventureReadOnlyRepository;

        public AdventureService(IAdventureRepository adventureRepository,
            IAdventureReadOnlyRepository adventureReadOnlyRepository)
            : base(adventureRepository, adventureReadOnlyRepository)
        {
            this.adventureRepository = adventureRepository;
            this.adventureReadOnlyRepository = adventureReadOnlyRepository;
        }

        public new ValidationResult Add(Adventure adventure)
        {
            var validationResult = new ValidationResult();

            if (!adventure.IsValid())
            {
                validationResult.AddError(adventure.ValidationResult);
                return validationResult;
            }

            var validator = new AdventureIsVerifiedForRegistration();
            var validationService = validator.Validate(adventure);
            if (!validationService.IsValid)
            {
                validationResult.AddError(adventure.ValidationResult);
                return validationResult;
            }

            adventureRepository.Add(adventure);

            return validationResult;
        }

        public Adventure GetWithAddressById(Guid adventureId, Guid userId)
        {
            return adventureReadOnlyRepository.GetWithAddressById(adventureId, userId);
        }

        public IEnumerable<Adventure> GetAllWithAddressById(Guid userId)
        {
            return adventureReadOnlyRepository.GetAllWithAddressById(userId);
        }
    }
}
