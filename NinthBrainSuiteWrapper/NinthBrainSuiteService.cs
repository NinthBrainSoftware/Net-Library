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
        private DepartmentService departmentService = null;
        private JobTitleService jobTitleService = null;
        private LocaleService localeService = null;
        private WorkShiftService workShiftService = null;

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
        /// Creates a new NinthBrain object using provided apiKey and accessToken parameters
        /// </summary>
        /// <param name="config">Configuration</param>
        public NinthBrainSuiteService(Configuration config)
        {
            configuration = config;

            individualService = new IndividualService(configuration, this);
            certificationService = new CertificationService(configuration, this);
            individualCertificationService = new IndividualCertificationService(configuration, this);
            departmentService = new DepartmentService(configuration, this);
            jobTitleService = new JobTitleService(configuration, this);
            localeService = new LocaleService(configuration, this);
            workShiftService = new WorkShiftService(configuration, this);
        }

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

        public DepartmentService DepartmentService
        {
            get { return departmentService; }
        }

        public JobTitleService JobTitleService
        {
            get { return jobTitleService; }
        }

        public LocaleService LocaleService
        {
            get { return localeService; }
        }

        public WorkShiftService WorkShiftService
        {
            get { return workShiftService; }
        }
        #endregion
    }
}
