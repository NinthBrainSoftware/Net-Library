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
    public class Locale : Component
    {
        /// <summary>
        /// Gets or sets the Locale id.
        /// </summary>
        [DataMember(Name = "LocaleId", EmitDefaultValue = false)]
        public int LocaleId { get; set; }
         /// <summary>
        /// Gets or sets the Locale name.
        /// </summary>
        [DataMember(Name = "LocaleName", EmitDefaultValue = false)]
        public string LocaleName { get; set; }        
    }

}
