using SDOBusinessCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SDOBusinessCore.Entities
{
    public class Customer : Person
    {
        #region Properties
             
        ///// <summary>
        ///// Gets or sets the customer identifier.
        ///// </summary>
        ///// <value>
        ///// The customer identifier.
        ///// </value>        
        //public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the delivery addresses.
        /// </summary>
        /// <value>
        /// The delivery addresses.
        /// </value>
        public List<Address> ShippingAddresses { get; set; }

        /// <summary>
        /// Gets or sets the billing address.
        /// </summary>
        /// <value>
        /// The billing address.
        /// </value>
        public List<Address> BillingAddress { get; set; }

        /// <summary>
        /// Gets or sets the email adress.
        /// </summary>
        /// <value>
        /// The email adress.
        /// </value>
        public String EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the pass word.
        /// </summary>
        /// <value>
        /// The pass word.
        /// </value>
        public String PassWord { get; set; }

        /// <summary>
        /// Gets or sets the basket.
        /// </summary>
        /// <value>
        /// The basket.
        /// </value>
        public Basket Basket { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is web connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is web connected; otherwise, <c>false</c>.
        /// </value>
        public bool IsWebConnected { get; set; }

        /// <summary>
        /// Gets or sets the extented customer properties.
        /// </summary>
        /// <value>
        /// The extented customer properties.
        /// </value>
        public List<ExtendedProperties> ExtentedCustomerProperties { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
            this.ShippingAddresses = new List<Address>();
            this.ExtentedCustomerProperties = new List<ExtendedProperties>();
            this.Orders = new List<Order>();
            this.Basket = new Basket();
        }

        #endregion
    }
}
