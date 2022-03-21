using SDOBusinessCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDOBusinessCore.Entities
{
    /// <summary>
    /// TransactionOrder
    /// </summary>
    public class TransactionOrder
    {
        public enum TransationResultValues
        {
            Success,
            Failure,
            Pending,
            Unknown
        }

        /// <summary>
        /// Gets or sets the relative order.
        /// </summary>
        /// <value>
        /// The relative order.
        /// </value>
        public Order RelativeOrder { get; set; }

        /// <summary>
        /// Gets or sets the PSP.
        /// </summary>
        /// <value>
        /// The PSP.
        /// </value>
        public PaymentProcessor PSP { get; set; }

        /// <summary>
        /// Gets or sets the payment send date.
        /// </summary>
        /// <value>
        /// The payment send date.
        /// </value>
        public DateTime PaymentSendDate { get; set; }

        /// <summary>
        /// Gets or sets the payment received date.
        /// </summary>
        /// <value>
        /// The payment received date.
        /// </value>
        public DateTime PaymentReceivedDate { get; set; }

        /// <summary>
        /// Gets or sets the transation result.
        /// </summary>
        /// <value>
        /// The transation result.
        /// </value>
        public TransationResultValues TransationResult { get; set; }

        /// <summary>
        /// Gets or sets the PSP reference.
        /// </summary>
        /// <value>
        /// The PSP reference.
        /// </value>
        public String PSPReference { get; set; }

        public TransactionOrder()
        {
            this.TransationResult = TransationResultValues.Unknown;
        }
    }
}
