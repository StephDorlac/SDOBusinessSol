using SDOBusinessCore.Entities;
using SDOBusinessCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDOBusinessCore.DAO
{
    public interface IDataBasket
    {
        public Basket GetBasketByCustomerEmail(String email);
        public CommonResult CleanBasket(int basketId);

        public CommonResult InsertProducts(List<Product> products, int basketId);
    }
}
