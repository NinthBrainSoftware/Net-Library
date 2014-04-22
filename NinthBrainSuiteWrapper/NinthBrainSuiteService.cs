#region Using

using System;
using System.Collections.Generic;
using NinthBrainSoftware.HostedEngine.Client.Components.Individuals;
using NinthBrainSoftware.HostedEngine.Client.Components.Certifications;
using NinthBrainSoftware.HostedEngine.Client.Exceptions;
using NinthBrainSoftware.HostedEngine.Client.Services;
using NinthBrainSoftware.HostedEngine.Client.Util;
using NinthBrainSoftware.HostedEngine.Client.Components;
using System.IO;
using System.Text;

#endregion

namespace NinthBrainSoftware.HostedEngine.Client
{
    /// <summary>
    /// Main class meant to be used by users to access Ninth Brain Suite API functionality.
    /// <example>    
    /// Web.config entries:
    /// <code>
    /// <![CDATA[
    /// ...
    /// <appSettings>
    ///     <add key="NinthBrainAPIKey" value="APIKey"/>
    ///     <add key="NinthBrainServiceUrl" value="https://api.ninthbrain.com"/>
    /// </appSettings>
    /// ...
    /// ]]>
    /// </code>
    /// </example>
    /// </summary>
    public class NinthBrainSuiteService
    {
        #region Properties

        private Configuration configuration = null;
        private IndividualCertificationService individualCertificationService = null;
        private CertificationService certificationService = null;
        private IndividualService individualService = null;

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceUrl"></param>
        /// <param name="apiKey"></param>
        public NinthBrainSuiteService(string serviceUrl, string apiKey) :
            this(new Configuration(serviceUrl, apiKey))
        {
        }

        /// <summary>
        /// Creates a new ConstantContact object using provided apiKey and accessToken parameters
        /// </summary>
        /// <param name="config">Configuration</param>
        public NinthBrainSuiteService(Configuration config)
        {
            configuration = config;

            individualService = new IndividualService(configuration, this);
            certificationService = new CertificationService(configuration, this);
            individualCertificationService = new IndividualCertificationService(configuration, this);
        }

        #endregion

        #region Private methods

        #endregion

        #region Public methods

        public CertificationService CertificationService
        {
            get { return certificationService; }
        }

        public IndividualCertificationService IndividualCertificationService
        {
            get { return individualCertificationService; }
        }

        public IndividualService IndividualService
        {
            get { return individualService; }
        }
        
        #endregion
    }
}
