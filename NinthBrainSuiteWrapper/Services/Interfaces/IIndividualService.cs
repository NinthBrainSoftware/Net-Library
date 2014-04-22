using System;
using System.Collections.Generic;
using NinthBrainSoftware.HostedEngine.Client.Components.Individuals;
using NinthBrainSoftware.HostedEngine.Client.Components;
namespace NinthBrainSoftware.HostedEngine.Client.Services
{
    /// <summary>
    /// Interface for IndividualService class.
    /// </summary>
    public interface IIndividualService : IBaseService
    {
        /// <summary>
        /// Get an array of individuals.
        /// </summary>
        /// <param name="apiKey">The API key for the application</param>
        /// <param name="modifiedSince">limit individual to individuals modified since the supplied date</param>
        /// <param name="status">Returns list of individuals with specified status.</param>
        /// <returns>Returns a list of individuals.</returns>
        IList<Individual> GetIndividuals(string apiKey, DateTime? modifiedSince, IndividualStatus? status);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="nbsId"></param>
        /// <returns></returns>
        Individual GetIndividualByNBSId(string apiKey, string nbsId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="employeeNumber"></param>
        /// <returns></returns>
        Individual GetIndividualByEmployeeNumber(string apiKey, string employeeNumber);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        Individual GetIndividualByUniqueIdentifier(string apiKey, string uniqueIdentifier);

        /// <summary>
        /// Add a new individual to the Constant Individual account
        /// </summary>
        /// <param name="apiKey">The API key for the application</param>
        /// <param name="individual">Individual to add.</param>
        /// <returns>Returns the newly created individual.</returns>
        Individual AddIndividual(string apiKey, Individual individual);

        /// <summary>
        /// Update individual details for a specific individual.
        /// </summary>
        /// <param name="apiKey">The API key for the application</param>
        /// <param name="individual">Individual to be updated.</param>
        /// <returns>Returns the updated individual.</returns>
        Individual UpdateIndividual(string apiKey, Individual individual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="individual"></param>
        /// <returns></returns>
        //Individual TerminateIndividual(string apiKey, Individual individual);
    }
}
