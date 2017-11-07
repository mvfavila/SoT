using System;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents an User Claim.
    /// </summary>
    public class Claim
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        private Claim() { }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="name"></param>
        private Claim(string name)
        {
            ClaimId = Guid.NewGuid();
            Name = name;
        }

        /// <summary>
        /// Claim Unique Id.
        /// </summary>
        public Guid ClaimId { get; private set; }

        /// <summary>
        /// Name fo the Claim.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Factory used when a new Claim is being added to the database context.
        /// </summary>
        /// <param name="name">Name fo the Claim.</param>
        /// <returns>See <see cref="Claim"/>.</returns>
        public static Claim FactoryAdd(string name)
        {
            return new Claim(name);
        }

        /// <summary>
        /// Factory used when an existing Claim is loaded from the database context.
        /// </summary>
        /// <param name="claimId">Claim Unique Id.</param>
        /// <param name="name">Name fo the Claim.</param>
        /// <returns>See <see cref="Claim"/>.</returns>
        public static Claim FactoryLoad(Guid claimId, string name)
        {
            return new Claim
            {
                ClaimId = claimId,
                Name = name
            };
        }
    }
}
