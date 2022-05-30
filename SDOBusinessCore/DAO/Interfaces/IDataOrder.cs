using SDOBusinessCore.Entities;
using SDOBusinessCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDOBusinessCore.DAO
{
    public interface IDataOrder
    {
        public CreateOrderCommonResult CreateOrder(int customerId, List<Product> products, int billingAddressId, int shippingAddressId, decimal amountWithTaxes, decimal amountWithoutTaxes, decimal discountAmout, decimal shippingAmountWithTaxes, decimal shippingAmountWithoutTaxes, decimal VATRate, decimal totalVAT, DateTime paidDate);


    }
}
