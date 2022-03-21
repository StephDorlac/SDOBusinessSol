using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDOBusinessCore.Entities.Common
{
    /// <summary>
    /// Country
    /// </summary>
    public class Country
    {
        #region Properties

        /// <summary>
        /// Gets or sets the two letter country code.
        /// </summary>
        /// <value>
        /// The two letter country code.
        /// </value>
        public string TwoLetterCountryCode { get; set; }
       
        /// <summary>
        /// Gets or sets the three letter country code.
        /// </summary>
        /// <value>
        /// The three letter country code.
        /// </value>
        public string ThreeLetterCountryCode { get; set; }
       
        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        /// <value>
        /// The name of the country.
        /// </value>
        public string CountryName { get; set; }

        #endregion

    }
}
