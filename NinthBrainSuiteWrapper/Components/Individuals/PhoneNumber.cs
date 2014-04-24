using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NinthBrainSoftware.HostedEngine.Client.Components.Individuals
{
    /// <summary>
    /// Represents a single Phone of a Individual.
    /// </summary>
    [DataContract]
    [Serializable]
    public class PhoneNumber : Component
    {
        /// <summary>
        /// Phone address id.
        /// </summary>
        [DataMember(Name = "PhoneId", EmitDefaultValue = false)]
        public int PhoneId { get; set; }
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [DataMember(Name = "Number", EmitDefaultValue = false)]
        public string Number { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [DataMember(Name = "Country", EmitDefaultValue = false)]
        public string Country { get; set; }
        /// <summary>
        /// Gets or sets the email type.
        /// </summary>
        [DataMember(Name = "PhoneType", EmitDefaultValue = false)]
        public string PhoneType { get; set; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="phoneNumber">Phone address.</param>
        public PhoneNumber(string phoneNumber, string phoneType)
        {
            this.Number = phoneNumber;
            this.PhoneType = phoneType;
            this.Country = "US";
        }

        [Newtonsoft.Json.JsonConstructor()]
        public PhoneNumber(string phoneNumber, string country, string phoneType)
        {
            this.Number = phoneNumber;
            this.Country = country;
            this.PhoneType = phoneType;
        }

    }

    /// <summary>
    /// Phone type structure.
    /// </summary>
    public struct PhoneType
    {
        public const string Fax = "FAX";
        public const string TollFree = "TOLLFREE";
        public const string Business1 = "BUSINESS1";
        public const string Mobile1 = "MOBILE1";
        public const string Home1 = "HOME1";
        public const string Pager = "PAGER";
        public const string Business2 = "BUSINESS2";
        public const string Mobile2 = "MOBILE2";
        public const string Home2 = "HOME2";
    }
}
