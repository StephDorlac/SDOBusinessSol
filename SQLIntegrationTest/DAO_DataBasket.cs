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
    public class DAO_DataBasket
    {
        [TestMethod]
        public void GetBasketByCustomerEmail()
        {
            DataBasketSQL dbBasket = new DataBasketSQL();

            // test unknown customer
            Action act1 = () => dbBasket.GetBasketByCustomerEmail("notexist@notexist.com");
            act1.Should().Throw<Exception>();

            //test with real user (create one if not exist)
            DataCustomerSQL dbCustomer = new DataCustomerSQL();
            Customer customer = new Customer()
            {
                FirstName = "IntegrationTest_FirstName",
                LastName = "IntegrationTest_LastName",
                EmailAddress = "integrationtest@integrationtest.com",
                ExtentedCustomerProperties = new System.Collections.Generic.List<ExtendedProperties>()
                {
                    new ExtendedProperties() { PropertyKey = "CreationDate", PropertyValue = DateTime.Now.ToString(), UnicityRequired = true }
                },
                PassWord = Cipher.Encrypt("theSecretPassword", SettingsManager.ReadSetting("encrPss"))
            };
            var actCustomer = dbCustomer.Save(customer);
            actCustomer.Should().Match<CommonResult>(d => d.ResultStatus == CommonResult.ResultStatusAction.Success);

            var actBasket = dbBasket.GetBasketByCustomerEmail(customer.EmailAddress);
            actBasket.Should().NotBeNull();           
        }

        [TestMethod]
        public void CleanBasket()
        {
            DataBasketSQL dbBasket = new DataBasketSQL();
            var actual = dbBasket.CleanBasket(1);
            var expected = new CommonResult() { Message = "OK", ResultStatus = CommonResult.ResultStatusAction.Failure };
            actual.ResultStatus.Should().Equals(expected);            
        }

        //[TestMethod]
        ////TEST OK BUT NEED TO PICK SOMES IDs to validate
        //public void AddProductToBasket()
        //{
        //    List<Product> products = new List<Product>() { new Product() { ProductID = 1, Name = "TestProduct01" }, new Product { ProductID = 2, Name = "TestProduct01" } };

        //    DataBasket dbBasket = new DataBasket();
        //    var actual = dbBasket.InsertProducts(products, 1);

        //    var expected = new CommonResult() { Message = "OK", ResultStatus = CommonResult.ResultStatusAction.Success };
        //    actual.ResultStatus.Should().Equals(expected);

        //}
    }
}
