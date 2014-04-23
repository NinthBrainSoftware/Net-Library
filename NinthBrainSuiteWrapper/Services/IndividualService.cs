using System;
using System.Collections.Generic;
using NinthBrainSoftware.HostedEngine.Client.Components.Individuals;
using NinthBrainSoftware.HostedEngine.Client.Util;
using NinthBrainSoftware.HostedEngine.Client.Components;
using NinthBrainSoftware.HostedEngine.Client.Exceptions;

namespace NinthBrainSoftware.HostedEngine.Client.Services
{
    /// <summary>
    /// Performs all actions pertaining to the Individuals Collection.
    /// </summary>
    public class IndividualService : BaseService
    {

        private Configuration configuration = null;
        private NinthBrainSuiteService manager = null;

        public IndividualService(Configuration configuration, NinthBrainSuiteService manager)
        {
            this.configuration = configuration;
            this.manager = manager;
        }

        /// <summary>
        /// Get an array of individuals.
        /// </summary>
        /// <param name="configuration">The API key for the application</param>
        /// <param name="modifiedSince">limit individual to individuals modified since the supplied date</param>
        /// <param name="status">Match the exact individual status.</param>
        /// <returns>Returns a list of individuals.</returns>
        public IList<Individual> GetIndividuals(DateTime? modifiedSince, IndividualStatus? status)
        {
            IList<Individual> results = null;

            // Construct access URL
            //string url = (pag == null) ? Config.ConstructUrl(Config.Endpoints.Individuals, null, new object[] { "email", email, "limit", limit, "modified_since", Extensions.ToISO8601String(modifiedSince), "status", status }) : pag.GetNextUrl();
            string url = Config.ConstructUrl("Individual/GetList", null, null);

            // Get REST response
            CUrlResponse response = RestClient.Get(url, configuration);

            if (response.IsError)
            {
                throw new NinthBrainAPIException(response.GetErrorMessage());
            }

            if (response.HasData)
            {
                // Convert from JSON
                results = Component.FromJSON<IList<Individual>>(response.Body);
            }

            return results;
        }

        /// <summary>
        /// Get individual details for a specific individual.
        /// </summary>
        /// <param name="configuration">The API key for the application</param>
        /// <param name="nbsId">Unique individual id.</param>
        /// <returns>Returns a individual.</returns>
        public Individual GetIndividualByNBSId(string nbsId)
        {
            Individual individual = null;

            string url = String.Format("Individual/GetByNBSId?nbsId={0}", nbsId);
            CUrlResponse response = RestClient.Get(url, configuration);

            if (response.IsError)
            {
                throw new NinthBrainAPIException(response.GetErrorMessage());
            }

            if (response.HasData)
            {
                individual = Component.FromJSON<Individual>(response.Body);
            }

            return individual;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="employeeNumber"></param>
        /// <returns></returns>
        public Individual GetIndividualByEmployeeNumber(string employeeNumber)
        {
            Individual individual = null;

            string url = String.Format("Individual/GetByNBSId?employeeNumber={0}", employeeNumber);
            CUrlResponse response = RestClient.Get(url, configuration);

            if (response.IsError)
            {
                throw new NinthBrainAPIException(response.GetErrorMessage());
            }

            if (response.HasData)
            {
                individual = Component.FromJSON<Individual>(response.Body);
            }

            return individual;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public Individual GetIndividualByUniqueIdentifier(string uniqueIdentifier)
        {
            Individual individual = null;

            string url = String.Format("Individual/GetByUniqueIdentifier?uniqueIdentifier={0}", uniqueIdentifier);
            CUrlResponse response = RestClient.Get(url, configuration);

            if (response.IsError)
            {
                throw new NinthBrainAPIException(response.GetErrorMessage());
            }

            if (response.HasData)
            {
                individual = Component.FromJSON<Individual>(response.Body);
            }

            return individual;
        }
        /// <summary>
        /// Add a new individual to the Constant Individual account
        /// </summary>
        /// <param name="configuration">The API key for the application</param>
        /// <param name="individual">Individual to add.</param>
        /// <returns>Returns the newly created individual.</returns>
        public Individual AddIndividual(Individual individual)
        {
            Individual newIndividual = null;
            string url = "Individual/Insert";

            string json = individual.ToJSON();
            CUrlResponse response = RestClient.Post(url, configuration, json);
            if (response.HasData)
            {
                newIndividual = Component.FromJSON<Individual>(response.Body);
            }
            else
                if (response.IsError)
                {
                    throw new NinthBrainAPIException(response.GetErrorMessage());
                }

            return newIndividual;
        }

        /// <summary>
        /// Update individual details for a specific individual.
        /// </summary>
        /// <param name="configuration">The API key for the application</param>
        /// <param name="individual">Individual to be updated.</param>
        /// <returns>Returns the updated individual.</returns>
        public Individual UpdateIndividual(Individual individual)
        {
            Individual updatedIndividual = null;
            string url = "Individual/Update";

            string json = individual.ToJSON();
            CUrlResponse response = RestClient.Post(url, configuration, json);
            if (response.HasData)
            {
                updatedIndividual = Component.FromJSON<Individual>(response.Body);
            }
            else
                if (response.IsError)
                {
                    throw new NinthBrainAPIException(response.GetErrorMessage());
                }

            return updatedIndividual;
        }
    }
}
