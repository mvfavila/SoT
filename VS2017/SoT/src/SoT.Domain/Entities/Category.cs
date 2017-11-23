using SoT.Domain.Interfaces.Validation;
using SoT.Domain.Validation.Category;
using SoT.Domain.ValueObjects;
using System;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents the Category of a set of Adventures.<br/>
    /// e.g. Kayaking, Sky diving, Parachuting.
    /// </summary>
    public class Category : ISelfValidator
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        private Category() { }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="name">Name of the Category.</param>
        /// <param name="active">Informs if the Element is active in SoT system.</param>
        /// <param name="elementId">Unique id of the <see cref="Entities.Element"/> attached to the Category.</param>
        private Category(string name, bool active, Guid elementId)
        {
            CategoryId = Guid.NewGuid();
            Name = name;
            Active = active;
            ElementId = elementId;
        }

        /// <summary>
        /// Category Unique Id.
        /// </summary>
        public Guid CategoryId { get; private set; }

        /// <summary>
        /// Name of the Category.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Informs if the Category is active in SoT system.
        /// </summary>
        public bool Active { get; private set; }

        /// <summary>
        /// Unique id of the <see cref="Entities.Element"/> attached to the Category.
        /// </summary>
        public Guid ElementId { get; private set; }

        /// <summary>
        /// <see cref="Entities.Element"/> attached to the Category.
        /// </summary>
        public virtual Element Element { get; private set; }

        /// <summary>
        /// See <see cref="ValueObjects.ValidationResult"/>.
        /// </summary>
        public ValidationResult ValidationResult { get; private set; }

        /// <summary>
        /// See <see cref="ISelfValidator.IsValid"/>.
        /// </summary>
        /// <returns>See <see cref="ISelfValidator.IsValid"/>.</returns>
        public bool IsValid()
        {
            var validation = new CategoryIsVerifiedForRegistration();
            ValidationResult = validation.Validate(this);

            return ValidationResult.IsValid;
        }

        /// <summary>
        /// Factory used when a new Category is being added to the database context.
        /// </summary>
        /// <param name="name">Name of the Category.</param>
        /// <param name="elementId">Unique id of the <see cref="Entities.Element"/> attached to the Category.</param>
        /// <returns>See <see cref="Category"/>.</returns>
        public static Category FactoryAdd(string name, Guid elementId)
        {
            const bool ACTIVE = true;
            return new Category(name, ACTIVE, elementId);
        }

        /// <summary>
        /// Factory used to seed the database context.
        /// </summary>
        /// <param name="categoryId">Category Unique Id.</param>
        /// <param name="name">Name of the Category.</param>
        /// <param name="active">Informs if the Category is active in SoT system.</param>
        /// <param name="elementId">Unique id of the <see cref="Entities.Element"/> attached to the Category.</param>
        /// <returns>See <see cref="Category"/>.</returns>
        public static Category FactorySeed(string categoryId, string name, bool active, Guid elementId)
        {
            return new Category
            {
                CategoryId = Guid.Parse(categoryId),
                Name = name,
                Active = active,
                ElementId = elementId
            };
        }

        /// <summary>
        /// Factory used for Category's Unit Tests.
        /// </summary>
        /// <param name="categoryId">Category Unique Id.</param>
        /// <param name="name">Name of the Category.</param>
        /// <param name="active">Informs if the Category is active in SoT system.</param>
        /// <param name="elementId">Unique id of the <see cref="Entities.Element"/> attached to the Category.</param>
        /// <param name="element"><see cref="Entities.Element"/> attached to the Category.</param>
        /// <returns>>See <see cref="Category"/>.</returns>
        public static Category FactoryTest(Guid categoryId, string name, bool active, Guid elementId,
            Element element)
        {
            return new Category
            {
                CategoryId = categoryId,
                Name = name,
                Active = active,
                ElementId = elementId,
                Element = element
            };
        }
    }
}
