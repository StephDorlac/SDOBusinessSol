using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDOBusinessCore.Entities
{
    /// <summary>
    /// ProductCategory
    /// </summary>
    public class ProductCategory
    {
        #region Properties

        /// <summary>
        /// Gets or sets the product category identifier.
        /// </summary>
        /// <value>
        /// The product category identifier.
        /// </value>
        public string ProductCategoryID { get; set; }

        /// <summary>
        /// Gets or sets the product category owner.
        /// </summary>
        /// <value>
        /// The product category owner.
        /// </value>
        public ProductCategory ProductCategoryOwner { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

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
