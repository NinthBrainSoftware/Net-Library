using System;
using NinthBrainSoftware.HostedEngine.Client.Util;

namespace NinthBrainSoftware.HostedEngine.Client.Services
{
    /// <summary>
    /// Interface for BaseService class.
    /// </summary>
    public interface IBaseService
    {
        /// <summary>
        /// Returns the REST client object.
        /// </summary>
        IRestClient RestClient { get; }
    }
}
