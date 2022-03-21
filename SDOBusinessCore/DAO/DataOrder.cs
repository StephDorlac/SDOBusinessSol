using SDOBusinessCore.Entities;
using System;
using System.Linq;
using SDOBusinessCore.Business.Common;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using SDOBusinessCore.Entities.Common;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Transactions;

namespace SDOBusinessCore.DAO
{
    public class DataOrder
    {
        private String connectionString;

        #region Contructors

        public DataOrder()
        {
            this.connectionString = SettingsManager.ReadSetting("CONNECTIONSTRING");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="products">The products.</param>
        /// <param name="billingAddressId">The billing address identifier.</param>
        /// <param name="shippingAddressId">The shipping address identifier.</param>
        /// <param name="amountWithTaxes">The amount with taxes.</param>
        /// <param name="amountWithoutTaxes">The amount without taxes.</param>
        /// <param name="discountAmout">The discount amout.</param>
        /// <param name="shippingAmountWithTaxes">The shipping amount with taxes.</param>
        /// <param name="shippingAmountWithoutTaxes">The shipping amount without taxes.</param>
        /// <param name="VATRate">The vat rate.</param>
        /// <param name="totalVAT">The total vat.</param>
        /// <param name="paidDate">The paid date.</param>
        /// <returns></returns>
        public CreateOrderCommonResult CreateOrder(int customerId, List<Product> products, int billingAddressId, int shippingAddressId, decimal amountWithTaxes, decimal amountWithoutTaxes, decimal discountAmout, decimal shippingAmountWithTaxes, decimal shippingAmountWithoutTaxes, decimal VATRate, decimal totalVAT, DateTime paidDate)
        {
            LogHelper.LogMessage($"DataOrder.CreateOrder", LogHelper.SeverityLevel.Info);

            CreateOrderCommonResult result = new CreateOrderCommonResult();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    //sql : CreateOrder - CreateOrderProducts

                    //create order

                    //attach products
                    products.ForEach(p =>
                    {
                        //TODO
                    });

                    //commit transaction
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage($"DataOrder.CreateOrder Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);

                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
                result.Message = ex.ToString();
            }

            return result;
        }

        #endregion

    }
}
