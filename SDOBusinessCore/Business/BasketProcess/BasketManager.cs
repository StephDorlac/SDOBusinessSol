using SDOBusinessCore.Entities.Common;
using System;
using System.Collections.Generic;
using SDOBusinessCore.Entities;
using SDOBusinessCore.Business.Common;
using SDOBusinessCore.DAO;

namespace SDOBusinessCore.BasketProcess
{
    /// <summary>
    /// BasketManager
    /// </summary>
    public class BasketManager
    {
        public DataBasket dao = new DataBasket();

        /// <summary>
        /// Adds the item to Basket
        /// </summary>
        /// <param name="products">The products.</param>
        /// <param name="basket">The basket.</param>
        /// <returns></returns>
        public CommonResult AddProduct(List<Product> products, Basket basket, List<BasketRuleBase> rules = null)
        {
            CommonResult result = new CommonResult() { Message = String.Empty, ResultStatus = CommonResult.ResultStatusAction.Pending };
            try
            {
                //Process policy checks  
                bool areRulesValid = rules != null ?  rules.TrueForAll(r => r.IsValid) : true;

                if (areRulesValid)
                {

                    //Add product to basket
                    products.ForEach(p =>
                    {
                        basket.Products.Add(p);
                    });

                    //DAO management
                    var daoResult = dao.InsertProducts(products, basket.BasketId);
                    if (daoResult.ResultStatus == CommonResult.ResultStatusAction.Success)
                    {
                        result.Message = "OK";
                        result.ResultStatus = CommonResult.ResultStatusAction.Success;
                    }
                    else
                        throw new Exception(daoResult.Message);
                }
                else
                {
                    result.Message = "Not all rules respected !";
                    result.ResultStatus = CommonResult.ResultStatusAction.Failure;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage($"BasketManager.AddProduct Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;                
            }
            return result;
        }

        /// <summary>
        /// Cleans the basket.
        /// </summary>
        /// <param name="basket">The basket.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// basket - basket cannot be null !
        /// or
        /// basket - basket Product List cannot be null !
        /// </exception>
        public CommonResult CleanBasket(Basket basket)
        {
            CommonResult result = new CommonResult() { Message = String.Empty, ResultStatus = CommonResult.ResultStatusAction.Pending };
            
            try
            {
                if (basket == null)
                    throw new ArgumentNullException("basket", "basket cannot be null !");
                if (basket.Products == null)
                    throw new ArgumentNullException("basket", "basket Product List cannot be null !");

                basket.Products.Clear();

                //DAO management
                var daoResult = dao.CleanBasket(basket.BasketId);
                if (daoResult.ResultStatus == CommonResult.ResultStatusAction.Success)
                {
                    result.Message = "OK";
                    result.ResultStatus = CommonResult.ResultStatusAction.Success;
                }
                else
                    throw new Exception(daoResult.Message);
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage($"BasketManager.CleanBasket Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);
                result.Message = ex.ToString();
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;                                
            }
            return result;
        }

       
    }
}
