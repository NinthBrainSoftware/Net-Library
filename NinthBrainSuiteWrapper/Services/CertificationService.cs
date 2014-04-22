using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NinthBrainSoftware.HostedEngine.Client.Components.Certifications;
using NinthBrainSoftware.HostedEngine.Client.Util;
using NinthBrainSoftware.HostedEngine.Client.Components;
using NinthBrainSoftware.HostedEngine.Client.Exceptions;
using System.Collections.Specialized;
using System.Collections;

namespace NinthBrainSoftware.HostedEngine.Client.Services
{
    /// <summary>
    /// Performs all actions pertaining to the Certifications Collection.
    /// </summary>
    public class CertificationService : BaseService, ICertificationService
    {

        /// <summary>
        /// Get an array of individuals.
        /// </summary>
        /// <param name="apiKey">The API key for the application</param>
        /// <param name="modifiedSince">limit individual to individuals modified since the supplied date</param>
        /// <param name="status">Match the exact individual status.</param>
        /// <returns>Returns a list of individuals.</returns>
        public IList<Certification> GetCertifications(string apiKey)
        {
            IList<Certification> certifications = new List<Certification>();
            // Construct access URL
            //string url = (pag == null) ? Config.ConstructUrl(Config.Endpoints.Certifications, null, new object[] { "email", email, "limit", limit, "modified_since", Extensions.ToISO8601String(modifiedSince), "status", status }) : pag.GetNextUrl();
            string url = Config.ConstructUrl("Certification/GetCertificationList", null, null);

            // Get REST response
            CUrlResponse response = RestClient.Get(url, apiKey);

            if (response.IsError)
            {
                throw new NinthBrainAPIException(response.GetErrorMessage());
            }

            if (response.HasData)
            {
                // Convert from JSON
                certifications = Component.FromJSON<IList<Certification>>(response.Body);
            }

            return certifications;
        }
        
    }
}
