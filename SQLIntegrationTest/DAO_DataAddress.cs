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
    public class DAO_DataAddress
    {
        [TestMethod]
        public void SaveAddressWithUnknownCustomer()
        {
            DataAddress dbAddress = new DataAddress();

            //Create fakeaddress
            Address address = new Address() { 
                AddressId = -1,
                ThreeLetterCountryCode = "FRA",
                CountryName = "France",
                TypeOfAddress = Address.AddressType.Billing,
                AddressNickName = "IntegrationTest",
                CompleteName = "IntegrationfirstName IntegrationLastName",
                FirstLine = "10 rue de l'intégration",
                SecondLine = null,
                PostalCode = "75002",
                City= "Saint Intégration",
                IsRelay = false,
                IsActive = true
            };


            var actual = dbAddress.SaveAddress(address, -1);
            var expected = new CommonResult() { Message = "-1 - ADDRESS NOT FOUND", ResultStatus = CommonResult.ResultStatusAction.Failure };
            actual.ResultStatus.Should().Equals(expected);
        }

        [TestMethod]
        public void SaveNewAddress()
        {
            DataAddress dbAddress = new DataAddress();

            //Create fakeaddress
            Address address = new Address()
            {
                AddressId = null,
                ThreeLetterCountryCode = "FRA",
                CountryName = "France",
                TypeOfAddress = Address.AddressType.Billing,
                AddressNickName = "IntegrationTest",
                CompleteName = "IntegrationfirstName IntegrationLastName",
                FirstLine = "10 rue de l'intégration",
                SecondLine = null,
                PostalCode = "75002",
                City = "Saint Intégration",
                IsRelay = false,
                IsActive = true
            };

            var actual = dbAddress.SaveAddress(address, 10);//WARNING, PLEASE SET A CORRECT CUSTOMERID
            var expected = new CommonResult() { Message = "OK", ResultStatus = CommonResult.ResultStatusAction.Success };
            actual.ResultStatus.Should().Equals(expected);
        }

        [TestMethod]
        public void GetAddressesByCustomerId()
        {
            DataAddress dbAddress = new DataAddress();
            var actual = dbAddress.GetAddressesByCustomerId(10);//WARNING, PLEASE SET A CORRECT CUSTOMERID
            actual.Should().NotBeNull();
        }



    }
}
