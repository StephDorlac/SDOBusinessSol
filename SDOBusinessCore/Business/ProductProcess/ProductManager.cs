using SDOBusinessCore.Business.Common;
using SDOBusinessCore.Entities;
using SDOBusinessCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDOBusinessCore.Business.ProductProcess
{
    public class ProductManager
    {
        /// <summary>
        /// Saves the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">product - product cannot be null !</exception>
        public CommonResult Save(Product product)
        {
            CommonResult result = new CommonResult() { Message = String.Empty, ResultStatus = CommonResult.ResultStatusAction.Pending };

            if (product == null)
                throw new ArgumentNullException("product", "product cannot be null !");

            try
            {
                //TODO
                result.ResultStatus = CommonResult.ResultStatusAction.Success;
            }
            catch (Exception ex)
            {
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
                LogHelper.LogMessage(ex.ToString(), LogHelper.SeverityLevel.Error);
            }
            return result;
        }
    }       
}
