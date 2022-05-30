using SDOBusinessCore.Entities;
using System;
using System.Linq;
using SDOBusinessCore.Business.Common;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using SDOBusinessCore.Entities.Common;
using System.Collections.Generic;

namespace SDOBusinessCore.DAO
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DataBasketSQL : IDataBasket
    {
        private String connectionString;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DataBasketSQL"/> class.
        /// </summary>
        public DataBasketSQL()
        {
            this.connectionString = SettingsManager.ReadSetting("CONNECTIONSTRING");
        }

        public DataBasketSQL(String connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion


        #region Methods


        /// <summary>
        /// Gets the basket by customer email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Basket GetBasketByCustomerEmail(String email)
        {
            LogHelper.LogMessage($"DataBasket.GetBasketByCustomerEmail with email: {email}", LogHelper.SeverityLevel.Info);
            Basket basket = new Basket();
            try
            {   
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var procName = "GetBasketByCustomerEmail";
                    var values = new { email = email };
                    var dbResult = connection.QueryMultiple(procName, values, commandType: CommandType.StoredProcedure);
                    var commonResult = dbResult.ReadFirst<SQLCommonResult>();
                    if (commonResult.Code == 0)
                    {
                        var sqlBasket = dbResult.ReadFirst<Basket>();
                        var sqlProducts = dbResult.Read<Product>();
                        basket.BasketId = sqlBasket.BasketId;
                        basket.VATRate = sqlBasket.VATRate;
                        basket.Products = sqlProducts.ToList();
                        
                        //Set VAT for products depend of Basket VAT Rate
                        basket.Products.ForEach(p =>
                        {
                            p.PriceWithTax = p.Price + ((p.Price / 100) * basket.VATRate);
                        });
                    }
                    else
                        throw new Exception($"{commonResult.Code} - {commonResult.Message}");
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage($"DataBasket.GetBasketByCustomerEmail Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);
                throw;
            }
            return basket;
        }

        /// <summary>
        /// Cleans the basket.
        /// </summary>
        /// <param name="basketId">The basket identifier.</param>
        /// <returns></returns>        
        public CommonResult CleanBasket(int basketId)
        {
            LogHelper.LogMessage($"DataBasket.CleanBasket with basketId: {basketId}", LogHelper.SeverityLevel.Info);
            CommonResult result = new CommonResult();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var procName = "CleanBasket";
                    var values = new { basketId = basketId };
                    var dbResult = connection.QuerySingle<SQLCommonResult>(procName, values, commandType: CommandType.StoredProcedure);

                    result.ResultStatus = dbResult.Code==0 ? CommonResult.ResultStatusAction.Success : CommonResult.ResultStatusAction.Failure;
                    result.Message = dbResult.Message;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage($"DataBasket.CleanBasket Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);
                result.Message = ex.ToString();
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;                
            }

            return result;
        }

        /// <summary>
        /// Insert the products.
        /// </summary>
        /// <param name="products">The products.</param>
        /// <param name="basketId">The basket identifier.</param>
        /// <returns></returns>
        public CommonResult InsertProducts(List<Product> products, int basketId)
        {
            LogHelper.LogMessage($"DataBasket.InsertProducts with basketId: {basketId}", LogHelper.SeverityLevel.Info);

            CommonResult result = new CommonResult();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var procName = "AddProductToBasket";

                    using (var transaction = connection.BeginTransaction())
                    {
                        products.ForEach(p =>
                        {
                            var values = new { basketId = basketId, productId = p.ProductID };
                            var dbResult = connection.QuerySingle<SQLCommonResult>(procName, values, commandType: CommandType.StoredProcedure, transaction: transaction);
                            if (dbResult.Code != 0)
                            {
                                transaction.Rollback();
                                throw new Exception($"{dbResult.Code} - {dbResult.Message}");
                            }
                        });
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage($"DataBasket.InsertProducts Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);
                result.Message = ex.ToString();
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
            }
            return result;
        }

        #endregion
    }
}
