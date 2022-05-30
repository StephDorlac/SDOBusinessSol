using SDOBusinessCore.Business.Common;
using SDOBusinessCore.Entities;
using SDOBusinessCore.Entities.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SDOBusinessCore.Business.CustomerProcess;
using SDOBusinessCore.BasketProcess;
using SDOBusinessCore.DAO;

namespace SDOBusinessCore.Business.OrderProcess
{
    /// <summary>
    /// OrderManager 
    /// </summary>
    public class OrderManager
    {
        private readonly IDataOrder _dao;
        private readonly IDataBasket _daoBasket;

        public OrderManager(IDataOrder dao)
        {
            _dao = dao;
        }

        /// <summary>
        /// Creates the order inside Customer's Orders collection
        /// CreateOrder is used AFTER payment notification
        /// </summary>
        /// <param name="basket">The basket.</param>
        /// <param name="billingAdd">The billing add.</param>
        /// <param name="shippingAdd">The shipping adr.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// basket - basket cannot be null !
        /// or
        /// basket.Owner - basket's Owner cannot be null !
        /// or
        /// basket.Products - basket without product cannot provide an order !
        /// </exception>
        public CommonResult CreateOrder(Basket basket, Address billingAdd, Address shippingAdd, bool cleanBasket, decimal discountAmount=0, decimal shippingAmount=0)
        {
            CommonResult result = new CommonResult() { Message = String.Empty, ResultStatus = CommonResult.ResultStatusAction.Pending };
            try
            {
                if (basket is null)
                    throw new ArgumentNullException("basket", "basket cannot be null !");
                if (basket.Owner is null)
                    throw new ArgumentNullException("basket.Owner", "basket's Owner cannot be null !");
                if(basket.Products is null ||basket.Products.Count==0)
                    throw new ArgumentNullException("basket.Products", "basket without product cannot provide an order !");

                //Calcultate amounts                
                var totalProductsAmountWithoutTaxes = basket.Products.Sum(p => p.Price);
                var totalProductsVAT = basket.Products.Sum(p => p.PriceWithTax);
                var totalShippingWithoutTaxes = 0;//TEMP
                var totalShippingVAT = 0;//TEMP
                var totalAmountWithTaxes = totalProductsAmountWithoutTaxes + totalProductsVAT + totalShippingVAT;
                var totalAmountWithoutTaxes = totalProductsAmountWithoutTaxes + totalShippingWithoutTaxes;
                Order order = new Order()
                {
                    Products = basket.Products,
                    Owner = basket.Owner,
                    BillingAddress = billingAdd,
                    ShippingAddress = shippingAdd,
                    AmountIncludingTaxes = totalAmountWithTaxes,
                    AmountExcludinTaxes = totalAmountWithoutTaxes,
                    DiscountAmount = discountAmount,
                    ShippingAmount = shippingAmount,
                    VATRate = basket.VATRate,
                    TotalVAT = (totalAmountWithTaxes - totalAmountWithoutTaxes),                    
                    CreationDate = DateTime.Now,
                    StatusOrder = Order.StatusOrderType.Preparing,
                    IsLocked = false
                };

                //TODO
                //SAVE Order


                //clean basket
                if (cleanBasket)
                {
                    BasketManager bskManager = new BasketManager(_daoBasket);
                    bskManager.CleanBasket(basket);                    
                }

                result.ResultStatus = CommonResult.ResultStatusAction.Success;
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage($"OrderManager.CreateOrder Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
            }
            return result;
        }


    }
}
