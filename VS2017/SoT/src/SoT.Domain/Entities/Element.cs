using System;
using System.Collections.Generic;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents the nature element where the Adventure is taken place.<br/>
    /// e.g. Land, Water, Air.
    /// </summary>
    public class Element
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        private Element() { }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="name">Name of the Element.</param>
        /// <param name="active">Informs if the Element is active in SoT system.</param>
        private Element(string name, bool active)
        {
            ElementId = Guid.NewGuid();
            Name = name;
            Active = active;
        }

        /// <summary>
        /// Element Unique Id.
        /// </summary>
        public Guid ElementId { get; private set; }

        /// <summary>
        /// Name of the Element.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Informs if the Element is active in SoT system.
        /// </summary>
        public bool Active { get; private set; }

        /// <summary>
        /// Collection of <see cref="Category"/> attached to the Element.
        /// </summary>
        public virtual ICollection<Category> Categories { get; private set; }

        /// <summary>
        /// Factory used when a new Element is being added to the database context.
        /// </summary>
        /// <param name="name">Name of the Element.</param>
        /// <returns>See <see cref="Element"/>.</returns>
        public static Element FactoryAdd(string name)
        {
            const bool ACVTIVE = true;
            return new Element(name, ACVTIVE);
        }
    }
}
