using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace NinthBrainSoftware.HostedEngine.Client.Components.Individuals
{
    /// <summary>
    /// Represents a single Individual in Constant Individual.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Individual : Component
    {
        [DataMember(Name = "IndividualId")]
        public int IndividualId { get; set; }

        [DataMember(Name = "NBSId")]
        public int NBSId { get; set; }

        [DataMember(Name = "FirstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "MiddleName")]
        public string MiddleName { get; set; }

        [DataMember(Name = "LastName")]
        public string LastName { get; set; }

        public string FirstLastName
        {
            get
            {
                if (!string.IsNullOrEmpty(MiddleName))
                {
                    return string.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
                }
                else
                {
                    return string.Format("{0} {1}", FirstName, LastName);
                }
            }
        }

        public string LastFirstName
        {
            get
            {
                if (!string.IsNullOrEmpty(MiddleName))
                {
                    return string.Format("{0} {1} {2}", LastName, MiddleName, FirstName);
                }
                else
                {
                    return string.Format("{0} {1}", LastName, FirstName);
                }
            }
        }

        [DataMember(Name = "EmployeeNumber")]
        public string EmployeeNumber { get; set; }

        [DataMember(Name = "UniqueNumber")]
        public string UniqueNumber { get; set; }

        [DataMember(Name = "LogonId")]
        public string LogonId { get; set; }

        [DataMember(Name = "Password")]
        public string Password { get; set; }

        [DataMember(Name = "DateOfBirth")]
        public string DateOfBirth { get; set; }

        [DataMember(Name = "Gender")]
        public string Gender { get; set; }

        [DataMember(Name = "JobTitle")]
        public string JobTitle { get; set; }

        [DataMember(Name = "Department")]
        public string Department { get; set; }

        [DataMember(Name = "Locale")]
        public string Locale { get; set; }

        [DataMember(Name = "WorkShift")]
        public string WorkShift { get; set; }

        [DataMember(Name = "CompanyId")]
        public int CompanyId { get; set; }

        [DataMember(Name = "IsEmployee")]
        public int IsEmployee { get; set; }

        [DataMember(Name = "FullTime")]
        public int FullTime { get; set; }

        [DataMember(Name = "Status")]
        public int Status { get; set; }

        [DataMember(Name = "HireDate")]
        public string HireDate { get; set; }

        [DataMember(Name = "InsertDate")]
        public string InsertDate { get; set; }

        [DataMember(Name = "UpdateDate")]
        public string UpdateDate { get; set; }

        [DataMember(Name = "EmailAddresses")]
        public List<EmailAddress> EmailAddresses { get; set; }
        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        [DataMember(Name = "Addresses")]
        public List<Address> Addresses { get; set; }
        /// <summary>
        /// Gets or sets the phones
        /// </summary>
        [DataMember(Name = "PhoneNumbers")]
        public List<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        public Individual()
        {
            this.EmailAddresses = new List<EmailAddress>();
            this.Addresses = new List<Address>();
            this.PhoneNumbers = new List<PhoneNumber>();
        }
    }

    /// <summary>
    /// Individual status enumeration
    /// </summary>
    public enum IndividualStatus
    {
        /// <summary>
        /// Active.
        /// </summary>
        ACTIVE,
        /// <summary>
        /// Unconfirmed.
        /// </summary>
        LOA,
        /// <summary>
        /// Output.
        /// </summary>
        FORMER
    }

}
