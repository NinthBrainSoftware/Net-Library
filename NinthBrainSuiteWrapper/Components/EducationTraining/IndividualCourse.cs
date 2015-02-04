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
        
        [DataMember(Name = "CourseName", EmitDefaultValue = false)]
        public string CourseName { get; set; }
       
        [DataMember(Name = "AuthorInstructor", EmitDefaultValue = false)]
        public string AuthorInstructor { get; set; }

        [DataMember(Name = "CourseDescription", EmitDefaultValue = false)]
        public string CourseDescription { get; set; } 

        [DataMember(Name = "StartDate", EmitDefaultValue = false)]
        public string StartDate { get; set; }

        [DataMember(Name = "EndDate", EmitDefaultValue = false)]
        public string EndDate { get; set; } 
        
        [DataMember(Name = "FirstName", EmitDefaultValue = false)]
        public string FirstName { get; set; } 
        
        [DataMember(Name = "LastName", EmitDefaultValue = false)]
        public string LastName { get; set; }

        [DataMember(Name = "Department", EmitDefaultValue = false)]
        public string Department { get; set; }

        [DataMember(Name = "Locale", EmitDefaultValue = false)]
        public string Locale { get; set; }

        [DataMember(Name = "JobTitle", EmitDefaultValue = false)]
        public string JobTitle { get; set; }

        [DataMember(Name = "EmployeeNumber", EmitDefaultValue = false)]
        public string EmployeeNumber { get; set; }


    }

}
