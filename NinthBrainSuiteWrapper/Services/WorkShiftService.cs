using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NinthBrainSoftware.HostedEngine.Client.Components.Company;
using NinthBrainSoftware.HostedEngine.Client.Util;
using NinthBrainSoftware.HostedEngine.Client.Components;
using NinthBrainSoftware.HostedEngine.Client.Exceptions;
using System.Collections.Specialized;
using System.Collections;

namespace NinthBrainSoftware.HostedEngine.Client.Services
{
    /// <summary>
    /// Performs all actions pertaining to the WorkShifts Collection.
    /// </summary>
    public class WorkShiftService : BaseService
    {
        private Configuration configuration = null;
        private NinthBrainSuiteService manager = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="manager"></param>
        public WorkShiftService(Configuration configuration, NinthBrainSuiteService manager)
        {
            this.configuration = configuration;
            this.manager = manager;
        }

        /// <summary>
        /// Get an array of individuals.
        /// </summary>
        /// <returns>Returns a list of individuals.</returns>
        public IList<WorkShift> GetWorkShifts()
        {
            IList<WorkShift> WorkShifts = new List<WorkShift>();
            // Construct access URL
            string url = Config.ConstructUrl("WorkShift/GetList", null, null);

            // Get REST response
            CUrlResponse response = RestClient.Get(url, configuration);          

            if (response.IsError)
            {
                throw new NinthBrainAPIException(response.GetErrorMessage());
            }

            if (response.HasData)
            {
                // Convert from JSON
                WorkShifts = Component.FromJSON<IList<WorkShift>>(response.Body);
            }

            return WorkShifts;
        }
        
    }
}
