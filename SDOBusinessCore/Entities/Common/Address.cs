
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDOBusinessCore.Entities.Common
{
    /// <summary>
    /// Address
    /// </summary>
    public class Address
    {
        #region enumerations

        /// <summary>
        /// AddressType
        /// </summary>
        public enum AddressType
        {
            Shipping = 1,
            Billing = 2,
            Unknown = 3
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the address identifier.
        /// </summary>
        /// <value>
        /// The address identifier.
        /// </value>     
        public int? AddressId {get;set;}

        /// <summary>
        /// Gets or sets the type of address.
        /// </summary>
        /// <value>
        /// The type of address.
        /// </value>
        public AddressType TypeOfAddress { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the address nick.
        /// </summary>
        /// <value>
        /// The name of the address nick.
        /// </value>
        public string AddressNickName { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the complete.
        /// </summary>
        /// <value>
        /// The name of the complete.
        /// </value>
        public string CompleteName { get; set; }
        
        /// <summary>
        /// Gets or sets the first line.
        /// </summary>
        /// <value>
        /// The first line.
        /// </value>
        public string FirstLine { get; set; }
        
        /// <summary>
        /// Gets or sets the second line.
        /// </summary>
        /// <value>
        /// The second line.
        /// </value>
        public string SecondLine { get; set; }
        
        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; }

        ///// <summary>
        ///// Gets or sets the country address.
        ///// </summary>
        ///// <value>
        ///// The country address.
        ///// </value>
        //public Country CountryAddress { get; set; }

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        /// <value>
        /// The name of the country.
        /// </value>
        public String CountryName { get; set; }

        /// <summary>
        /// Gets or sets the three letter country code.
        /// </summary>
        /// <value>
        /// The three letter country code.
        /// </value>
        public String ThreeLetterCountryCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is available.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is available; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is relay.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is relay; otherwise, <c>false</c>.
        /// </value>
        public bool IsRelay { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        public Address()
        {
            this.TypeOfAddress = AddressType.Unknown;
        }

        #endregion
    }
}
