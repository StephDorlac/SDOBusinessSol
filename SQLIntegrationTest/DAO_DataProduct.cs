using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDOBusinessCore.Business.Common;
using SDOBusinessCore.DAO;
using SDOBusinessCore.Entities;
using SDOBusinessCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLIntegrationTest
{
    [TestClass]
    public class DAO_DataProduct
    {
        [TestMethod]
        public void GetAllProducts()
        {
            DataProductSQL dbProduct = new DataProductSQL();
            var actual = dbProduct.GetAllProducts();
            actual.Should().NotBeNull();
        }

        [TestMethod]
        public void GetProductsByCategoryId()
        {
            DataProductSQL dbProduct = new DataProductSQL();
            var actual = dbProduct.GetProductsByCategoryId(1);
            actual.Should().NotBeNull();
        }
    }
}
