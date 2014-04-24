using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace NinthBrainSoftware.HostedEngine.Client.Components.Certifications
{
    /// <summary>
    /// Represents a single Certification in Constant Certification.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Certification : Component
    {
        /// <summary>
        /// Gets or sets the certification id.
        /// </summary>
        [DataMember(Name = "CertificationId", EmitDefaultValue = false)]
        public int CertificationId { get; set; }
         /// <summary>
        /// Gets or sets the certification name.
        /// </summary>
        [DataMember(Name = "CertificationName", EmitDefaultValue = false)]
        public string CertificationName { get; set; }        
    }

}
