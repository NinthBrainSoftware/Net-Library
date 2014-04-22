﻿using System;
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
    public class IndividualCertificationService : BaseService, IIndividualCertificationService
    {

        /// <summary>
        /// Get an array of individuals.
        /// </summary>
        /// <param name="apiKey">The API key for the application</param>
        /// <param name="updatedSince">limit to individual certifications modified since the supplied date</param>        
        /// <returns>Returns a list of individuals.</returns>
        public IList<IndividualCertification> GetIndividualCertifications(string apiKey, DateTime? updatedSince)
        {
            IList<IndividualCertification> certifications = new List<IndividualCertification>();
            // Construct access URL
            //string url = (pag == null) ? Config.ConstructUrl(Config.Endpoints.Certifications, null, new object[] { "email", email, "limit", limit, "modified_since", Extensions.ToISO8601String(modifiedSince), "status", status }) : pag.GetNextUrl();
            string url = Config.ConstructUrl("IndividualCertification/GetIndividualCertificationList", null, new object[] { "updatedSince", updatedSince.ToString() });

            // Get REST response
            CUrlResponse response = RestClient.Get(url, apiKey);

            if (response.IsError)
            {
                throw new NinthBrainAPIException(response.GetErrorMessage());
            }

            if (response.HasData)
            {
                // Convert from JSON
                certifications = Component.FromJSON<IList<IndividualCertification>>(response.Body);
            }

            return certifications;
        }

        /// <summary>
        /// Get an array of individuals.
        /// </summary>
        /// <param name="apiKey">The API key for the application</param>
        /// <returns>Returns a list of individuals.</returns>
        public IList<IndividualCertification> GetIndividualCertifications(string apiKey)
        {
            return GetIndividualCertifications(apiKey, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="individualCertificationId"></param>
        /// <returns></returns>
        public IndividualCertification GetIndividualCertification(string apiKey, int individualCertificationId)
        {
            IndividualCertification certification = new IndividualCertification();
            // Construct access URL
            //string url = (pag == null) ? Config.ConstructUrl(Config.Endpoints.Certifications, null, new object[] { "email", email, "limit", limit, "modified_since", Extensions.ToISO8601String(modifiedSince), "status", status }) : pag.GetNextUrl();
            string url = Config.ConstructUrl("IndividualCertification/GetIndividualCertification", null, new object[] { "individualCertificationId", individualCertificationId.ToString() });

            // Get REST response
            CUrlResponse response = RestClient.Get(url, apiKey);

            if (response.IsError)
            {
                throw new NinthBrainAPIException(response.GetErrorMessage());
            }

            if (response.HasData)
            {
                // Convert from JSON
                certification = Component.FromJSON<IndividualCertification>(response.Body);
            }

            return certification;
        }

        public IndividualCertification Update(string apiKey, IndividualCertification individualCertification)
        {
            IndividualCertification updatedIndividualCertification = null;
            string url = String.Concat(Config.Endpoints.BaseUrl, "IndividualCertification/Update");

            string json = individualCertification.ToJSON();
            CUrlResponse response = RestClient.Post(url, apiKey, json);
            if (response.HasData)
            {
                updatedIndividualCertification = Component.FromJSON<IndividualCertification>(response.Body);
            }
            else
                if (response.IsError)
                {
                    throw new NinthBrainAPIException(response.GetErrorMessage());
                }

            return updatedIndividualCertification;
        }

        public IndividualCertification Insert(string apiKey, IndividualCertification individualCertification)
        {
            IndividualCertification updatedIndividualCertification = null;
            string url = String.Concat(Config.Endpoints.BaseUrl, "IndividualCertification/Insert");

            string json = individualCertification.ToJSON();
            CUrlResponse response = RestClient.Post(url, apiKey, json);
            if (response.HasData)
            {
                updatedIndividualCertification = Component.FromJSON<IndividualCertification>(response.Body);
            }
            else
                if (response.IsError)
                {
                    throw new NinthBrainAPIException(response.GetErrorMessage());
                }

            return updatedIndividualCertification;
        }
    }
}
