using SDOBusinessCore.Business.Common;
using SDOBusinessCore.DAO;
using SDOBusinessCore.Entities;
using SDOBusinessCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDOBusinessCore.Business.CustomerProcess
{
    /// <summary>
    /// CustomerManager
    /// </summary>
    public class CustomerManager
    {
        private DataCustomer dao;

        public CustomerManager()
        {
            dao = new DataCustomer();
        }

        public CustomerManager(String connectionString)
        {
            dao = new DataCustomer(connectionString);
        }



        /// <summary>
        /// Saves the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">customer - customer cannot be null !</exception>
        public CommonResult Save(Customer customer)
        {
            CommonResult result = new CommonResult() { Message = String.Empty, ResultStatus = CommonResult.ResultStatusAction.Pending };

            if (customer == null)
                throw new ArgumentNullException("customer", "customer cannot be null !");

            try
            {
                dao.Save(customer);

                result.ResultStatus = CommonResult.ResultStatusAction.Success;
            }
            catch (Exception ex)
            {
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
                LogHelper.LogMessage($"CustomerManager.Save Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);
            }
            return result;
        }

        /// <summary>
        /// Determines whether [is customer exist] [the specified customer].
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>
        ///   <c>true</c> if [is customer exist] [the specified customer]; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">customer - customer cannot be null !</exception>
        public bool IsCustomerExist(Customer customer)
        {            
            try
            {
                if (customer == null)
                    throw new ArgumentNullException("customer", "customer cannot be null !");
                return dao.IsExist(customer);
            }

            catch (Exception ex)
            {                
                LogHelper.LogMessage($"CustomerManager.IsCustomerExist Error:{ex.ToString()}", LogHelper.SeverityLevel.Error);
                throw;
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAll()
        {
            //return this.dao.CollectionContext.FindSync(Builders<Customer>.Filter.Empty).ToList();
            throw new NotImplementedException();
            
            
        }

        /// <summary>
        /// Connects the customer.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="passWord">The pass word.</param>
        /// <returns></returns>
        public Customer ConnectCustomer(String email, String passWord)
        {
            return dao.ConnectCustomer(email, passWord, true);
        }
    }
}
