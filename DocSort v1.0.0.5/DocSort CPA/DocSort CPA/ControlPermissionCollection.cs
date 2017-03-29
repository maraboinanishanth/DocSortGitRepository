using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace DocSort_CPA  
{
    [Serializable] 
    /// <summary>
    /// Class for collection of ControlPermission
    /// </summary>
    public class ControlPermissionCollection : CollectionBase
    {
        /// <summary>
        /// Method for adding ControlPermission values.
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public int Add(ControlPermission Value)
        {
            return (List.Add(Value));
        }

    }

    
}
