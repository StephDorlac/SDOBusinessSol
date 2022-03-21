using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDOBusinessCore.Entities
{
    /// <summary>
    /// LitigationType
    /// </summary>
    public class LitigationType
    {
        #region Properties

        public int LitigationTypeId { get; set; }

        /// <summary>
        /// Gets or sets the litigation type identifier.
        /// </summary>
        /// <value>
        /// The litigation type identifier.
        /// </value>
        public int LitigationTypeID { get; set; }

        /// <summary>
        /// Gets or sets the name of the litigation type.
        /// </summary>
        /// <value>
        /// The name of the litigation type.
        /// </value>
        public String LitigationTypeName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is available.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is available; otherwise, <c>false</c>.
        /// </value>
        public bool IsAvailable { get; set; }

        #endregion
    }
}
