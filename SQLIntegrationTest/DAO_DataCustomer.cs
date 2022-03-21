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
    public class DAO_DataCustomer
    {
        [TestMethod]
        public void Is_Customer_Exist()
        {
            DataCustomer dbCustomer = new DataCustomer();
            Customer customer = new Customer()
            {
                FirstName = "IntegrationTest_FirstName",
                LastName = "IntegrationTest_LastName",
                EmailAddress = $"{Guid.NewGuid()}@integrationtest.com",
                ExtentedCustomerProperties = new System.Collections.Generic.List<ExtendedProperties>()
                {
                    new ExtendedProperties() { PropertyKey = "CreationDate", PropertyValue = DateTime.Now.ToString(), UnicityRequired = true }
                },
                PassWord = Cipher.Encrypt("theSecretPassword", SettingsManager.ReadSetting("encrPss"))

            };

            var actual = dbCustomer.IsExist(customer);
            actual.Should().BeFalse();
        }




        [TestMethod]
        public void Save_Customer_Get_Customer()
        {
            DataCustomer dbCustomer = new DataCustomer();
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

            var actual = dbCustomer.Save(customer);
            actual.Should().Match<CommonResult>(d => d.ResultStatus == CommonResult.ResultStatusAction.Success);

            var actualGet = dbCustomer.GetCustomerByEmail(customer.EmailAddress);
            actualGet.Should().NotBeNull();
        }

        [TestMethod]
        public void ConnectCustomer()
        {
            DataCustomer dbCustomer = new DataCustomer();
            var actual = dbCustomer.ConnectCustomer("integrationtest@integrationtest.com", "kViOLy+o+GEsh83HjPtpLxnehgxAmBNJ0DNy9MOmDxc=", true);
            actual.Should().NotBeNull();
        }


    }
}
