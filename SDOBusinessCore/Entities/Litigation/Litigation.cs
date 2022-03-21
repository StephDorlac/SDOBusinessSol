using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDOBusinessCore.Entities
{
    /// <summary>
    /// Litigation
    /// </summary>
    public class Litigation
    {
        #region Enumerations

        public enum LitigationStatusType
        {
            Open,
            Closed,
            Unknown
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the litigetion identifier.
        /// </summary>
        /// <value>
        /// The litigetion identifier.
        /// </value>
        public int LitigationId { get; set; }

        /// <summary>
        /// Gets or sets the litigation identifier.
        /// </summary>
        /// <value>
        /// The litigation identifier.
        /// </value>
        public string LitigationID { get; set; }

        /// <summary>
        /// Gets or sets the type of litigation.
        /// </summary>
        /// <value>
        /// The type of litigation.
        /// </value>
        public LitigationType TypeOfLitigation { get; set; }

        /// <summary>
        /// Gets or sets the litigation status.
        /// </summary>
        /// <value>
        /// The litigation status.
        /// </value>
        public LitigationStatusType LitigationStatus { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the closing date.
        /// </summary>
        /// <value>
        /// The closing date.
        /// </value>
        public DateTime ClosingDate { get; set; }

        /// <summary>
        /// Gets or sets the affected products.
        /// </summary>
        /// <value>
        /// The affected products.
        /// </value>
        public List<Product> AffectedProducts { get; set; }

        /// <summary>
        /// Gets or sets the affected order.
        /// </summary>
        /// <value>
        /// The affected order.
        /// </value>
        public Order AffectedOrder { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// private contructor to prevent new instance without affected Order
        /// </summary>
        private Litigation()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Litigation"/> class.
        /// </summary>
        public Litigation(Order affectedOrder)
        {
            this.AffectedProducts = new List<Product>();
            this.AffectedOrder = affectedOrder;
            this.LitigationStatus = LitigationStatusType.Unknown;
        }

        #endregion
    }
}
