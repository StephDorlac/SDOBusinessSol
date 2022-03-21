using System;
using System.Collections.Generic;
using System.Text;

namespace SDOBusinessCore.Entities
{

    /// <summary>
    /// BasketRuleNotNullOrEmpty is a quick and easy implementation of a BasketRuleBase
    /// It checks if product added are not null and if Basket Exist
    /// </summary>
    /// <seealso cref="SDOBusinessCore.Entities.BasketRuleBase" />
    public class BasketRuleNotNullOrEmpty : BasketRuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasketRuleNotNullOrEmpty"/> class.
        /// </summary>
        /// <param name="products">The products.</param>
        /// <param name="basket">The basket.</param>
        public BasketRuleNotNullOrEmpty(List<Product> products, Basket basket) : base(products, basket)
        {
        }

        /// <summary>
        /// Checks if rule is Valid. It's the implementation of the abstract method of BasketRuleBase.
        /// </summary>
        public override void CheckIfValid()
        {
            if ((this.products == null || this.products.Count == 0) || this.basket == null)
                this.IsValid = false;
            else
                this.IsValid = true;

            
        }
    }
}
