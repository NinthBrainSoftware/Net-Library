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
    public class JobTitle : Component
    {
        /// <summary>
        /// Gets or sets the JobTitle id.
        /// </summary>
        [DataMember(Name = "JobTitleId", EmitDefaultValue = false)]
        public int JobTitleId { get; set; }
         /// <summary>
        /// Gets or sets the JobTitle name.
        /// </summary>
        [DataMember(Name = "JobTitleName", EmitDefaultValue = false)]
        public string JobTitleName { get; set; }        
    }

}
