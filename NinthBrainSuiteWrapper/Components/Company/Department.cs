using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace NinthBrainSoftware.HostedEngine.Client.Components.Company
{
    /// <summary>
    /// Represents a single Certification in Constant Certification.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Department : Component
    {
        /// <summary>
        /// Gets or sets the department id.
        /// </summary>
        [DataMember(Name = "DepartmentId", EmitDefaultValue = false)]
        public int DepartmentId { get; set; }
         /// <summary>
        /// Gets or sets the department name.
        /// </summary>
        [DataMember(Name = "DepartmentName", EmitDefaultValue = false)]
        public string DepartmentName { get; set; }        
    }

}
