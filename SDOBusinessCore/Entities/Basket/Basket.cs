
using SDOBusinessCore.Entities;
using SDOBusinessCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDOBusinessCore.Entities
{
    /// <summary>
    /// Basket
    /// </summary>
    public class Basket
    {
        #region Properties

        /// <summary>
        /// Gets or sets the basket identifier.
        /// </summary>
        /// <value>
        /// The basket identifier.
        /// </value>
      
        public int BasketId { get; set; }

        /// <summary>
        /// Gets or sets the vat rate.
        /// </summary>
        /// <value>
        /// The vat rate.
        /// </value>
        public decimal VATRate { get; set; }

        /// <summary>
        /// Gets or sets the Products.
        /// </summary>
        /// <value>
        /// The Products.
        /// </value>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Gets the products count.
        /// </summary>
        /// <value>
        /// The products count.
        /// </value>
        public int ProductsCount
        {
            get
            {
                return Products.Count;
            }
        }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public Customer Owner { get; set; }

        /// <summary>
        /// Gets or sets the extented basket properties.
        /// </summary>
        /// <value>
        /// The extented basket properties.
        /// </value>
        public List<ExtendedProperties> ExtentedBasketProperties { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Basket"/> class.
        /// </summary>
        public Basket()
        {
            this.Products = new List<Product>();
            this.ExtentedBasketProperties = new List<ExtendedProperties>();
        }

        #endregion

    }
}
