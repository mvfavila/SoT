using SoT.Application.ViewModels;
using SoT.Domain.Entities;
using System.Collections.Generic;

namespace SoT.Application.Mapping
{
    /// <summary>
    /// Mapping class for <see cref="Claim"/>.
    /// </summary>
    public static class ClaimMapper
    {
        /// <summary>
        /// Executes the map from a <see cref="ClaimViewModel"/> to a <see cref="Claim"/>.
        /// </summary>
        /// <param name="claim">See <see cref="Claim"/>.</param>
        /// <returns>See <see cref="ClaimViewModel"/>.</returns>
        internal static ClaimViewModel FromDomainToViewModel(
            Claim claim)
        {
            return new ClaimViewModel
            {
                Id = claim.ClaimId,
                Name = claim.Name
            };
        }

        /// <summary>
        /// Executes the map from a collection of <see cref="ClaimViewModel"/> to a collection of <see cref="Claim"/>.
        /// </summary>
        /// <param name="claims">Collection of <see cref="Claim"/>.</param>
        /// <returns>Collection of <see cref="ClaimViewModel"/>.</returns>
        internal static IEnumerable<ClaimViewModel> FromDomainToViewModel(IEnumerable<Claim> claims)
        {
            var claimViewModel = new List<ClaimViewModel>();

            foreach (var claim in claims)
            {
                claimViewModel.Add(FromDomainToViewModel(claim));
            }

            return claimViewModel;
        }
    }
}
