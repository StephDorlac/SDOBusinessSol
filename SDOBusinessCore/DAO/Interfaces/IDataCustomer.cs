using SDOBusinessCore.Entities;
using SDOBusinessCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDOBusinessCore.DAO
{
    public interface IDataCustomer
    {
        public bool IsExist(Customer customerToCheck);
        public Customer GetCustomerByEmail(String email);
        public CommonResult Save(Customer customerToSave);
        public Customer ConnectCustomer(String emailAddress, String password, bool withBasket = false);

    }
}
