using System;
using System.Collections.Generic;
using System.Text;

namespace SDOBusinessCore.Entities
{
    /// <summary>
    /// BasketRuleBase
    /// To implement some Rules Weh action is done to Basket (like Add for example), 
    /// inherit from BasketRuleBase and implement Business check in CheckIfValid method.
    /// Please don't change this abstract class, don't add Business rules here !
    /// </summary>    
    /// <example>See BasketRuleNotNullOrEmpty for a quick and easy implementation</example>
    public abstract class BasketRuleBase
    {
        public bool IsValid { get; set; }
        public List<Product> products { get; set; }
        public Basket basket { get; set; }


        public BasketRuleBase(List<Product> products, Basket basket)
        {
            this.products = products;
            this.basket = basket;
            CheckIfValid();
        }

        public abstract void CheckIfValid();
    }
}
