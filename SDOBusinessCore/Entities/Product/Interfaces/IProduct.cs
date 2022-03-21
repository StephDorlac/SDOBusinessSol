using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDOBusinessCore.Entities.Interfaces
{
    /// <summary>
    /// IProduct
    /// </summary>
    public interface IProduct
    {
        int ProductID { get; set; }
        String Name { get; set; }
    }
}
