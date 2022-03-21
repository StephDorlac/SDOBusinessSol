using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDOBusinessCore.Entities.Common
{
    /// <summary>
    /// Currency
    /// </summary>
    public class Currency
    {
        #region Properties

        /// <summary>
        /// Gets or sets the three letter iso code.
        /// </summary>
        /// <value>
        /// The three letter iso code.
        /// </value>
        public string ThreeLetterISOCode { get; set; }

        /// <summary>
        /// Gets or sets the iso code.
        /// </summary>
        /// <value>
        /// The iso code.
        /// </value>
        public string ISOCode { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        #endregion
    }
}
