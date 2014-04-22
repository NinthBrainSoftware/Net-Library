using System;
using System.Collections.Generic;
using NinthBrainSoftware.HostedEngine.Client.Components.Certifications;
using NinthBrainSoftware.HostedEngine.Client.Components;

namespace NinthBrainSoftware.HostedEngine.Client.Services
{
    /// <summary>
    /// Interface for IndividualCertification class.
    /// </summary>
    public interface IIndividualCertificationService : IBaseService
    {
        /// <summary>
        /// Get an array of individual certifications.
        /// </summary>
        /// <param name="apiKey">The API key for the application</param>
        /// <returns>Returns a list of individual certifications.</returns>
        IList<IndividualCertification> GetIndividualCertifications(string apiKey, DateTime? updatedSince);

        /// <summary>
        /// Get an array of individual certifications
        /// </summary>
        /// <param name="apiKey">The API key for the application</param>
        /// <returns>Returns a list of individual certifications.</returns>
        IList<IndividualCertification> GetIndividualCertifications(string apiKey);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="individualCertificationId"></param>
        /// <returns></returns>
        IndividualCertification GetIndividualCertification(string apiKey, int individualCertificationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="individualCertification"></param>
        /// <returns></returns>
        IndividualCertification Update(string apiKey, IndividualCertification individualCertification);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="individualCertification"></param>
        /// <returns></returns>
        IndividualCertification Insert(string apiKey, IndividualCertification individualCertification);
    }
}
