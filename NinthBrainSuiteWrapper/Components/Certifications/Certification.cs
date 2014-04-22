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
    public class IndividualCertification : Component
    {

        [DataMember(Name = "IndividualCertificationId", EmitDefaultValue = false)]
        public int IndividualCertificationId { get; set; }

        [DataMember(Name = "NBSId", EmitDefaultValue = false)]
        public int NBSId { get; set; }

        [DataMember(Name = "FirstName", EmitDefaultValue = false)]
        public string FirstName { get; set; }

        [DataMember(Name = "LastName", EmitDefaultValue = false)]
        public string LastName { get; set; }

        [DataMember(Name = "UniqueIdentifier", EmitDefaultValue = false)]
        public string UniqueIdentifier { get; set; }
        
        [DataMember(Name = "CertificationId", EmitDefaultValue = false)]
        public int CertificationId { get; set; }
        
        [DataMember(Name = "CertificationName", EmitDefaultValue = false)]
        public string CertificationName { get; set; }

        [DataMember(Name = "CertificationNumber", EmitDefaultValue = false)]
        public string CertificationNumber { get; set; }

        [DataMember(Name = "ActivationDate", EmitDefaultValue = false)]
        public DateTime ActivationDate { get; set; }

        [DataMember(Name = "ExpirationDate", EmitDefaultValue = false)]
        public DateTime ExpirationDate { get; set; }

        [DataMember(Name = "Country", EmitDefaultValue = false)]
        public string Country { get; set; }

        [DataMember(Name = "State", EmitDefaultValue = false)]
        public string State { get; set; }

        [DataMember(Name = "UpdateDate", EmitDefaultValue = false)]
        public DateTime UpdateDate { get; set; }
    }

}
