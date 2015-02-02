using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NinthBrainSoftware.HostedEngine.Client.Components.EducationTraining;
using NinthBrainSoftware.HostedEngine.Client.Util;
using NinthBrainSoftware.HostedEngine.Client.Components;
using NinthBrainSoftware.HostedEngine.Client.Exceptions;
using System.Collections.Specialized;
using System.Collections;

namespace NinthBrainSoftware.HostedEngine.Client.Services
{
    /// <summary>
    /// Performs all actions pertaining to the IndividualCourses Collection.
    /// </summary>
    public class IndividualCourseService : BaseService
    {
        private Configuration configuration = null;
        private NinthBrainSuiteService manager = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="manager"></param>
        public IndividualCourseService(Configuration configuration, NinthBrainSuiteService manager)
        {
            this.configuration = configuration;
            this.manager = manager;
        }

        /// <summary>
        /// Get an array of individuals.
        /// </summary>
        /// <returns>Returns a list of individuals.</returns>
        public IList<IndividualCourse> GetIndividualCourses(int individualId, DateTime startDate, DateTime endDate)
        {
            IList<IndividualCourse> IndividualCourses = new List<IndividualCourse>();
            // Construct access URL
            string url = Config.ConstructUrl("IndividualCourse/GetList", null, new object[] { "individualId", individualId.ToString(), "startDate", startDate.ToString(), "endDate", endDate.ToString() });

            // Get REST response
            CUrlResponse response = RestClient.Get(url, configuration);

            if (response.IsError)
            {
                throw new NinthBrainAPIException(response.GetErrorMessage());
            }

            if (response.HasData)
            {
                // Convert from JSON
                IndividualCourses = Component.FromJSON<IList<IndividualCourse>>(response.Body);
            }

            return IndividualCourses;
        }

    }
}
