using System;
using System.Collections.Generic;
using System.Text;
using NinthBrainSoftware.HostedEngine.Client.Util;
using NinthBrainSoftware.HostedEngine.Client.Services;

namespace NinthBrainSoftware.HostedEngine.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class NinthBrainSuiteAPI
    {
        protected static NinthBrainSuiteService _singleton;
        protected static NinthBrainSuiteService Service
        {
            get
            {
                if (_singleton == null)
                {
                    if (_configuration == null)
                    {
                        throw new ApplicationException("Attempted to use NinthBrainSuiteService object before setting the configuration!");
                    }
                    _singleton = new NinthBrainSuiteService(_configuration);
                }
                return _singleton;
            }
        }

        protected static Configuration _configuration;
        public static Configuration Configuration
        {
            get
            {
                return _configuration;
            }
            set
            {
                _configuration = value;
            }
        }

        public static CertificationService CertificationService
        {
            get { return Service.CertificationService; }
        }

        public static IndividualCertificationService IndividualCertificationService
        {
            get { return Service.IndividualCertificationService; }
        }

        public static IndividualService IndividualService
        {
            get { return Service.IndividualService; }
        }

        public static DepartmentService DepartmentService
        {
            get { return Service.DepartmentService; }
        }

        public static JobTitleService JobTitleService
        {
            get { return Service.JobTitleService; }
        }

        public static LocaleService LocaleService
        {
            get { return Service.LocaleService; }
        }

        public static WorkShiftService WorkShiftService
        {
            get { return Service.WorkShiftService; }
        }

        /// <summary>
        /// The Application ID obtained by registering with the SCORM Engine Service
        /// </summary>
        public static string ApiKey
        {
            get
            {
                return Configuration.ApiKey;
            }
        }


        /// <summary>
        /// URL to the service, ex: http://api.ninthbrain.com
        /// </summary>
        public static string ServiceUrl
        {
            get
            {
                return Configuration.ServiceUrl;
            }
        }

    }
}
