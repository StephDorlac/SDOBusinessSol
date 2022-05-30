using SDOBusinessCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDOBusinessCore.DAO
{
    public interface IDataAddress
    {
        CommonResult SaveAddress(Address address, int customerId);

        List<Address> GetAddressesByCustomerId(int customerId);


    }
}
