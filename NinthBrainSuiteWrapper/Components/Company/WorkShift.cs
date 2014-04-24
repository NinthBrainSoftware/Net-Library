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
    public class WorkShift : Component
    {
        /// <summary>
        /// Gets or sets the WorkShift id.
        /// </summary>
        [DataMember(Name = "WorkShiftId", EmitDefaultValue = false)]
        public int WorkShiftId { get; set; }
         /// <summary>
        /// Gets or sets the WorkShift name.
        /// </summary>
        [DataMember(Name = "WorkShiftName", EmitDefaultValue = false)]
        public string WorkShiftName { get; set; }        
    }

}
