using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocSort_CPA 
{ 
    [Serializable]
    /// <summary>
    /// Class for setting Control permission to properties
    /// </summary>
    public class ControlPermission
    {
        public string ControlID { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }

}
