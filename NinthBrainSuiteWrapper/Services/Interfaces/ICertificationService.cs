using System;
using System.Collections.Generic;
using NinthBrainSoftware.HostedEngine.Client.Components.Certifications;
using NinthBrainSoftware.HostedEngine.Client.Components;

namespace NinthBrainSoftware.HostedEngine.Client.Services
{
    /// <summary>
    /// Interface for CertificationService class.
    /// </summary>
    public interface ICertificationService : IBaseService
    {
        /// <summary>
        /// Get an array of certifications.
        /// </summary>
        /// <param name="apiKey">The API key for the application</param>
        /// <returns>Returns a list of certifications.</returns>
        IList<Certification> GetCertifications(string apiKey);

    }
}
