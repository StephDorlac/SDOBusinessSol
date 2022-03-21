
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDOBusinessCore.Entities.Common
{
    /// <summary>
    /// Person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// SexType
        /// </summary>
        public enum SexType
        {
            Male,
            Female,
            Unknown
        }

        #region Properties

     
        public int PersonId { get; set; }

        public SexType Sex { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            this.Sex = SexType.Unknown;
        }

        #endregion
    }
}
