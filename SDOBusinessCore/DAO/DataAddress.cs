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
    public class DataAddress
    {
        private String connectionString;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAddress"/> class.
        /// </summary>
        public DataAddress()
        {
            this.connectionString = SettingsManager.ReadSetting("CONNECTIONSTRING");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Saves the address for a user
        /// Update if exists else create a new one
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public CommonResult SaveAddress (Address address, int customerId)
        {
            LogHelper.LogMessage($"DataAddress.SaveAddress with: {JsonSerializer.Serialize(address)} - customerId:{customerId}", LogHelper.SeverityLevel.Info);

            CommonResult result = new CommonResult();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var procName = "SaveAddress";
                    var values =  new {addressId = address.AddressId, customerId = customerId, addressTypeId = (int)address.TypeOfAddress ,countryCode = address.ThreeLetterCountryCode,nickName= address.AddressNickName,completeName= address.CompleteName,firstLine= address.FirstLine,secondLine= address.SecondLine,postalCode= address.PostalCode,city= address.City,isRelay= address.IsRelay };
                    var dbResult = connection.QuerySingle<SQLCommonResult>(procName, values, commandType: CommandType.StoredProcedure);

                    if (dbResult.Code == 0)
                        result.ResultStatus = CommonResult.ResultStatusAction.Success;
                    else
                        throw new Exception($"{dbResult.Code} - {dbResult.Message}");
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage($"DataAddress.SaveAddress Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);

                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
                result.Message = ex.ToString();
            }

            return result;
        }

        /// <summary>
        /// Gets the addresses by customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public List<Address> GetAddressesByCustomerId(int customerId)
        {
            LogHelper.LogMessage($"DataAddress.GetAddressesByCustomerId with customerId:{customerId}", LogHelper.SeverityLevel.Info);

            List<Address> result = new List<Address>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var procName = "GetCustomerAdresses";
                    var values = new { customerId = customerId };
                    var dbResult = connection.Query<Address>(procName, values, commandType: CommandType.StoredProcedure);

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
