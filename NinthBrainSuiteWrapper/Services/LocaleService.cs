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
    /// Performs all actions pertaining to the Locales Collection.
    /// </summary>
    public class LocaleService : BaseService
    {
        private Configuration configuration = null;
        private NinthBrainSuiteService manager = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="manager"></param>
        public LocaleService(Configuration configuration, NinthBrainSuiteService manager)
        {
            this.configuration = configuration;
            this.manager = manager;
        }

        /// <summary>
        /// Get an array of individuals.
        /// </summary>
        /// <returns>Returns a list of individuals.</returns>
        public IList<Locale> GetLocales()
        {
            IList<Locale> Locales = new List<Locale>();
            // Construct access URL
            string url = Config.ConstructUrl("Locale/GetList", null, null);

            // Get REST response
            CUrlResponse response = RestClient.Get(url, configuration);          

            if (response.IsError)
            {
                throw new NinthBrainAPIException(response.GetErrorMessage());
            }

            if (response.HasData)
            {
                // Convert from JSON
                Locales = Component.FromJSON<IList<Locale>>(response.Body);
            }

            return Locales;
        }
        
    }
}
