
using SDOBusinessCore.Entities.Common;
using SDOBusinessCore.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDOBusinessCore.Entities
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product : IProduct
    {
        #region Properties

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is available.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is available; otherwise, <c>false</c>.
        /// </value>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public List<ProductCategory> Categories { get; set; }

        /// <summary>
        /// Gets or sets the extended properties.
        /// </summary>
        /// <value>
        /// The extended properties.
        /// </value>
        public List<ExtendedProperties> ExtendedProperties { get; set; }


        /// <summary>
        /// The price without Tax
        /// </summary>
        public Decimal Price { get; set; }


        /// <summary>
        /// Gets or sets the price with tax.
        /// </summary>
        /// <value>
        /// The price with tax.
        /// </value>
        public Decimal PriceWithTax { get; set; }

        #endregion

        #region Constructors

        public Product()
        {
            this.ExtendedProperties = new List<ExtendedProperties>();
            this.Categories = new List<ProductCategory>();
        }

        #endregion
    }
}
