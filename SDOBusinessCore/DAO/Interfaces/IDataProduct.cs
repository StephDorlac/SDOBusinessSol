using SDOBusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDOBusinessCore.DAO
{
    public interface IDataProduct
    {
        public List<Product> GetAllProducts();
        public List<Product> GetProductsByCategoryId(int categoryId);
    }
}
