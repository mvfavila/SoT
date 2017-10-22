using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoT.Domain.Entities
{
    /// <summary>
    /// Represents an Address.<br/>
    /// e.g. Address from where the Adventure will take place.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Address Unique Id.
        /// </summary>
        public Guid AddressId { get; private set; }

        /// <summary>
        /// First part of the Street's Address.
        /// </summary>
        public string Street01 { get; private set; }

        /// <summary>
        /// Second part of the Street's Address.
        /// </summary>
        public string Street02 { get; private set; }

        /// <summary>
        /// Address'Post Code.
        /// Ex.: 4102, EC, 49040-000.
        /// </summary>
        public string PostCode { get; private set; }
    }
}
