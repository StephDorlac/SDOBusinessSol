using SDOBusinessCore.Entities;
using System;
using System.Linq;
using SDOBusinessCore.Business.Common;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using SDOBusinessCore.Entities.Common;

namespace SDOBusinessCore.DAO
{
    public sealed class DataCustomerSQL : IDataCustomer
    {
        private String connectionString;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DataCustomerSQL"/> class.
        /// </summary>
        public DataCustomerSQL()
        {
            this.connectionString = SettingsManager.ReadSetting("CONNECTIONSTRING");
        }

        public DataCustomerSQL(String connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the specified customer to check is exist.
        /// The check is done on EMAIL_ADDRESS field
        /// </summary>
        /// <param name="customerToCheck">The customer to check.</param>
        /// <returns>
        ///   <c>true</c> if the specified customer to check is exist; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">customerToCheck cannot be null !</exception>
        public bool IsExist(Customer customerToCheck)
        {
            LogHelper.LogMessage($"DataCustomer.IsExist with: {customerToCheck.EmailAddress}", LogHelper.SeverityLevel.Info);

            bool result = false;

            try
            {
                if (customerToCheck is null)
                    throw new ArgumentNullException("customerToCheck cannot be null !");


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var procName = "GetCustomerByEmail";
                    var values = new { email = customerToCheck.EmailAddress };
                    var dbResult = connection.Query(procName, values, commandType: CommandType.StoredProcedure).ToList();
                    result = dbResult.Count() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage($"DataCustomer.IsExist Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);
                throw;
            }

            return result;
        }

        /// <summary>
        /// Gets the customer by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Customer GetCustomerByEmail(String email)
        {
            Customer result = null;
            try
            {
                LogHelper.LogMessage($"DataCustomer.GetCustomerByEmail with: {email}", LogHelper.SeverityLevel.Info);
                if (String.IsNullOrEmpty(email))
                    throw new ArgumentNullException("email", "email cannot be null or empty");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var procName = "GetCustomerByEmail";
                    var values = new { email = email };
                    result = connection.QueryFirst<Customer>(procName, values, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage($"DataCustomer.GetCustomerByEmail Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);
                throw;
            }
            return result;
        }

        /// <summary>
        /// Saves the customer without relationship
        /// </summary>
        /// <param name="customerToSave">The customer to save.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Cannot save a null Customer !</exception>
        /// <exception cref="System.Exception">proc GetCustomerByEmail {dbResult.Code} - {dbResult.Message}</exception>
        public CommonResult Save(Customer customerToSave)
        {
            LogHelper.LogMessage($"DataCustomer.SaveCustomer with: {customerToSave.EmailAddress}", LogHelper.SeverityLevel.Info);

            CommonResult result = new CommonResult();

            try
            {
                //check mandatory fields
                if (customerToSave is null)
                    throw new ArgumentNullException("Cannot save a null Customer !");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var procName = "SaveCustomer";
                    var values = new { FirstName = customerToSave.FirstName, SexType = (int)customerToSave.Sex, LastName = customerToSave.LastName, EmailAddress = customerToSave.EmailAddress, Password = customerToSave.PassWord };
                    var dbResult = connection.QuerySingle<SQLCommonResult>(procName, values, commandType: CommandType.StoredProcedure);

                    if (dbResult.Code == 0)
                        result.ResultStatus = CommonResult.ResultStatusAction.Success;
                    else
                        throw new Exception($"proc SaveCustomer {dbResult.Code} - {dbResult.Message}");
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage($"DataCustomer.Save Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);

                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
                result.Message = ex.ToString();
            }

            return result;
        }

        /// <summary>
        /// Connects the customer.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// emailAddress - emailAddress cannot be null or empty
        /// or
        /// password - password cannot be null or empty
        /// </exception>
        /// <exception cref="System.Exception"></exception>
        public Customer ConnectCustomer(String emailAddress, String password, bool withBasket = false)
        {
            LogHelper.LogMessage($"DataCustomer.ConnectCustomer with emailAddress: {emailAddress}", LogHelper.SeverityLevel.Info);

            if (String.IsNullOrEmpty(emailAddress))
                throw new ArgumentNullException("emailAddress", "emailAddress cannot be null or empty");
            if (String.IsNullOrEmpty(password))
                throw new ArgumentNullException("password", "password cannot be null or empty");

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var procName = "ConnectCustomer";
                    var values = new { email = emailAddress, password = password };
                    var dbResult = connection.QueryMultiple(procName, values, commandType: CommandType.StoredProcedure);
                    var commonResult = dbResult.ReadFirst<SQLCommonResult>();
                    if (commonResult.Code == 0)
                    {
                        Customer customer = dbResult.ReadFirst<Customer>();
                        customer.IsWebConnected = true;
                        if (withBasket)
                        {
                            DataBasketSQL dbBasket = new DataBasketSQL(connectionString);
                            customer.Basket = dbBasket.GetBasketByCustomerEmail(customer.EmailAddress);
                        }
                        return customer;
                    }
                    else
                    {
                        //throw new Exception($"{commonResult.Code} - {commonResult.Message}");
                        return new Customer() { IsWebConnected = false };
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage($"DataCustomer.ConnectCustomer Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);
                throw;
            }
        }

        #endregion
    }
}










