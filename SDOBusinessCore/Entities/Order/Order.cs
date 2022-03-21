using SDOBusinessCore.Business.Common;
using SDOBusinessCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDOBusinessCore.Entities
{
    /// <summary>
    /// Order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// StatusOrderType
        /// </summary>
        public enum StatusOrderType
        {
            Cancelled,
            Preparing,
            Shipping,
            Shipped,
            Closed
        }


        #region Private fields
        
        private String orderId;
        private List<ExtendedProperties> extendedProperties;
        private List<Product> products;        
        private Customer owner;
        private Address billingAddress;
        private Address shippingAddress;
        private Decimal amountIncludingTaxes;
        private Decimal amountExcludinTaxes;
        private Decimal discountAmount;
        private Decimal shippingAmount;
        private Decimal vATRate;
        private Decimal totalVAT;
        private DateTime creationDate;
        private DateTime paidDate;
        private StatusOrderType statusOrder;        
        private bool isLocked;

        #endregion

        #region Properties
        
       
        public String OrderId { get => orderId; set => orderId = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed",this) : value; }
        public List<ExtendedProperties> ExtendedProperties { get => extendedProperties; set => extendedProperties = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed",this) : value; }
        public List<Product> Products { get => products; set => products = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed", this) : value; }

        public Customer Owner { get => owner; set => owner = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed", this) : value; }
        public Address BillingAddress { get => billingAddress; set => billingAddress = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed",this) : value; }
        public Address ShippingAddress { get => shippingAddress; set => shippingAddress = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed",this) : value; }
        public decimal AmountIncludingTaxes { get => amountIncludingTaxes; set => amountIncludingTaxes = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed",this) : value; }
        public decimal AmountExcludinTaxes { get => amountExcludinTaxes; set => amountExcludinTaxes = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed",this) : value; }
        public decimal DiscountAmount { get => discountAmount; set => discountAmount = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed",this) : value; }
        public decimal ShippingAmount { get => shippingAmount; set => shippingAmount = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed",this) : value; }
        public decimal VATRate { get => vATRate; set => vATRate = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed",this) : value; }
        public decimal TotalVAT { get => totalVAT; set => totalVAT = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed", this) : value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed",this) : value; }
        public DateTime PaidDate { get => paidDate; set => paidDate = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed",this) : value; }

        public StatusOrderType StatusOrder { get => statusOrder; set => statusOrder = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed", this) : value; }
        public bool IsLocked { get => isLocked; set => isLocked = this.IsLocked ? throw new OrderBusinessException("Order is Locked, change is not allowed",this) : value; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// isLocked is False (any change is allowed
        /// </summary>
        public Order()
        {
            this.isLocked = false;
            this.ExtendedProperties = new List<ExtendedProperties>();
        }

      

        #endregion

    }
}
