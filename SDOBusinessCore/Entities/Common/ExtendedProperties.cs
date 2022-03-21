using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDOBusinessCore.Entities.Common
{
    /// <summary>
    /// ProductExtendedProperties helps define properties for product (Colors, size, ... )
    /// </summary>
    public class ExtendedProperties
    {
        #region Properties

        /// <summary>
        /// Gets or sets the property key.
        /// </summary>
        /// <value>
        /// The property key.
        /// </value>
        public string PropertyKey { get; set; }

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        /// <value>
        /// The property value.
        /// </value>
        public string PropertyValue { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [unicity required].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [unicity required]; otherwise, <c>false</c>.
        /// </value>        
        public bool UnicityRequired { get; set; }

        #endregion
    }
}
