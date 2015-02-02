using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace NinthBrainSoftware.HostedEngine.Client.Components.EducationTraining
{
    /// <summary>
    /// Represents a single Certification in Constant Certification.
    /// </summary>
    [DataContract]
    [Serializable]
    public class IndividualCourse : Component
    {
        /// <summary>
        /// Gets or sets the IndividualCourse id.
        /// </summary>
        [DataMember(Name = "IndividualCourseId", EmitDefaultValue = false)]
        public int IndividualCourseId { get; set; }
         /// <summary>
        /// Gets or sets the IndividualCourse name.
        /// </summary>
        [DataMember(Name = "CourseName", EmitDefaultValue = false)]
        public string CourseName { get; set; }
        /// <summary>
        /// Gets or sets the IndividualCourse name.
        /// </summary>
        [DataMember(Name = "StartDate", EmitDefaultValue = false)]
        public string StartDate { get; set; }
        /// <summary>
        /// Gets or sets the IndividualCourse name.
        /// </summary>
        [DataMember(Name = "EndDate", EmitDefaultValue = false)]
        public string EndDate { get; set; } 
          /// <summary>
        /// Gets or sets the IndividualCourse name.
        /// </summary>
        [DataMember(Name = "FirstName", EmitDefaultValue = false)]
        public string FirstName { get; set; } 
          /// <summary>
        /// Gets or sets the IndividualCourse name.
        /// </summary>
        [DataMember(Name = "LastName", EmitDefaultValue = false)]
        public string LastName { get; set; } 
    }

}
