using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDOBusinessCore.BasketProcess;
using SDOBusinessCore.Entities;
using SDOBusinessCore.Entities.Common;
using SDOBusinessEntity;
using System.Collections.Generic;
using static SDOBusinessCore.Entities.Common.CommonResult;

namespace SDOBusinessCoreTest
{
    [TestClass]
    [TestCategory("Basket")]
    public class BasketManagerTest
    {
        [TestMethod]        
        public void AddItem_AddProductsOnly()
        {
            BasketManager basketManager = new BasketManager();

            Basket basket = new Basket();

            Product productOne = new Product() { ProductID = "1", Name = "Product Test 1",IsAvailable = true };
            Product productTwo = new Product() { ProductID = "2", Name = "Product Test 2", IsAvailable = true };
            Product productThree = new Product() { ProductID = "3", Name = "Product Test 3", IsAvailable = true };

            List<Product> products = new List<Product>();
            products.Add(productOne);
            products.Add(productTwo);
            products.Add(productThree);
            
            var actual = basketManager.AddProduct(products, basket);
            
            //check Status and value
            actual.Should().BeOfType<CommonResult>().Subject.ResultStatus.Should().Be(ResultStatusAction.Succes);
            basket.Products.Count.Should().BeOneOf(3);

        }
    }
}
