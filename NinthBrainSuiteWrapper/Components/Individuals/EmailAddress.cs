using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NinthBrainSoftware.HostedEngine.Client.Components.Individuals
{
    /// <summary>
    /// Represents a single EmailAddress of a Individual.
    /// </summary>
    [DataContract]
    [Serializable]
    public class EmailAddress : Component
    {
        /// <summary>
        /// Email address id.
        /// </summary>
        [DataMember(Name = "EmailId", EmitDefaultValue = false)]
        public int EmailId { get; set; }
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [DataMember(Name = "EmailAddress", EmitDefaultValue = false)]
        public string EmailAddr { get; set; }
        /// <summary>
        /// Gets or sets the email type.
        /// </summary>
        [DataMember(Name = "EmailType", EmitDefaultValue = false)]
        public string EmailType { get; set; }

        [DataMember(Name = "AlertFormat", EmitDefaultValue = false)]
        public int AlertFormat { get; set; }
       
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="emailAddress">Email address.</param>
        public EmailAddress(string emailAddress, string emailType)
        {
            this.EmailAddr = emailAddress;
            this.EmailType = emailType;
            this.AlertFormat = 1;
        }

        [Newtonsoft.Json.JsonConstructor()]
        public EmailAddress(string emailAddress, string emailType, int alertFormat)
        {
            this.EmailAddr = emailAddress;
            this.EmailType = emailType;
            this.AlertFormat = alertFormat;
        }
    }

    /// <summary>
    /// Email type structure.
    /// </summary>
    public struct EmailType
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
        public const string Personal1 = "PERSONAL1";
        /// <summary>
        /// Business1
        /// </summary>
        public const string Personal2 = "PERSONAL2";
        /// <summary>
        /// Unknown.
        /// </summary>
        public const string Unknown = "UNKNOWN";
    }
}
