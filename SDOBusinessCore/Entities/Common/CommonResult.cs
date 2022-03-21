using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDOBusinessCore.Entities.Common
{
    /// <summary>
    /// CommonResult
    /// </summary>
    public class CommonResult 
    {
        #region Enumerations

        /// <summary>
        /// ResultStatusAction
        /// </summary>
        public enum ResultStatusAction
        {
            Success,
            Failure,
            Pending,
            Unknown
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public String Message { get; set; }
        
        /// <summary>
        /// Gets or sets the result status.
        /// </summary>
        /// <value>
        /// The result status.
        /// </value>
        public ResultStatusAction ResultStatus { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonResult"/> class.
        /// </summary>
        public CommonResult()
        {
            this.Message = string.Empty;
            this.ResultStatus = ResultStatusAction.Unknown;
        }

        #endregion
    }
}
