using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using SDOBusinessCore.Entities;
using System;
using SDOBusinessCore.Business.Common;

namespace SDOBusinessCoreUnitTest
{
    [TestClass]
    public class OrderEntity
    {
        [TestMethod]
        public void Set_Values_When_OrderIs_Locked()
        {
            //configure test
            Action act = () =>
            {
                Order testOrder = new Order();
                testOrder.OrderId = "TEST_01";
                testOrder.IsLocked = true;
                testOrder.OrderId = "TEST_UPDATE";
            };
            act.Should().Throw<OrderBusinessException>();


        }
    }
}
