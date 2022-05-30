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

namespace SDOBusinessCore.DAO
{
    public class DataProductSQL: IDataProduct
    {
        private String connectionString;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataProductSQL"/> class.
        /// </summary>
        public DataProductSQL()
        {
            this.connectionString = SettingsManager.ReadSetting("CONNECTIONSTRING");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            LogHelper.LogMessage($"DataProduct.GetAllProducts", LogHelper.SeverityLevel.Info);
            List<Product> result = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var procName = "GetAllProducts";                   
                    var dbResult = connection.Query<Product>(procName, null, commandType: CommandType.StoredProcedure);

                    result = dbResult.ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage($"DataAddress.GetAddressesByCustomerId Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);
            }
            return result;
        }

        /// <summary>
        /// Gets the products by category identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            LogHelper.LogMessage($"DataProduct.GetAllProducts", LogHelper.SeverityLevel.Info);
            List<Product> result = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var procName = "GetProductsByCategoryId";
                    var values = new { categoryId = categoryId };
                    var dbResult = connection.Query<Product>(procName, values, commandType: CommandType.StoredProcedure);
                    result = dbResult.ToList();
                }                
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage($"DataAddress.GetAddressesByCustomerId Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);
            }
            return result;
        }

        #endregion
    }
}
