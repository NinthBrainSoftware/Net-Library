using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NinthBrainSoftware.HostedEngine.Client.Components.Individuals
{
    /// <summary>
    /// Represents a single Address of a Individual.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Address : Component
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "AddressId", EmitDefaultValue = false)]
        public int AddressId { get; set; }
        /// <summary>
        /// Gets or sets the first address line.
        /// </summary>
        [DataMember(Name = "AddressLine1", EmitDefaultValue = false)]
        public string AddressLine1 { get; set; }
        /// <summary>
        /// Gets or sets the second address line.
        /// </summary>
        [DataMember(Name = "AddressLine2", EmitDefaultValue = false)]
        public string AddressLine2 { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [DataMember(Name = "City", EmitDefaultValue = false)]
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the address type.
        /// </summary>
        [DataMember(Name = "AddressType", EmitDefaultValue = false)]
        public string AddressType { get; set; }
        /// <summary>
        /// Gets or sets the state code.
        /// </summary>
        [DataMember(Name = "State", EmitDefaultValue = false)]
        public string State { get; set; }
        /// <summary>
        /// Gets or sets the contry code.
        /// </summary>
        [DataMember(Name = "Country", EmitDefaultValue = false)]
        public string Country { get; set; }
        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        [DataMember(Name = "ZipCode", EmitDefaultValue = false)]
        public string ZipCode { get; set; }
        
        public Address(string addressType, string addressLine1, string addressLine2, string city, string state, string zipCode)
        {
            this.AddressType = addressType;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
            this.Country = "US";
        }

        [Newtonsoft.Json.JsonConstructor()]
        public Address(string addressType, string addressLine1, string addressLine2, string city, string state, string zipCode, string country)
        {
            this.AddressType = addressType;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
            this.Country = country;
        }
    }

    /// <summary>
    /// Address type structure.
    /// </summary>
    public struct AddressType
    {
        /// <summary>
        /// Business1
        /// </summary>
        public const string Business1 = "BUSINESS1";
        /// <summary>
        /// Business2
        /// </summary>
        public const string Business2 = "BUSINESS2";
        /// <summary>
        /// Home1
        /// </summary>
        public const string Home1 = "HOME1";
        /// <summary>
        /// Business1
        /// </summary>
        public const string Home2 = "HOME2";
        /// <summary>
        /// Unknown.
        /// </summary>
        public const string Unknown = "UNKNOWN";
    }
}
