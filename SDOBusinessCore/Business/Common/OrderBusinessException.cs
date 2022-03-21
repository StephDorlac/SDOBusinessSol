using SDOBusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDOBusinessCore.Business.Common
{
    public class OrderBusinessException : Exception
    {
        private Order orderInError;
        public Order OrderInError { get => orderInError; set => orderInError = value; }

        public OrderBusinessException (String message, Order order) : base(message)
        {
            this.orderInError = order;
        }

        
    }
}
