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
        /// <param name="apiKey">APIKey</param>
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

        //public CertificationService CertificationService
        //{
        //    get { return certificationService; }
        //}

        //#region Certification service

        ///// <summary>
        ///// Get a set of certifications.
        ///// </summary>
        ///// <returns>Returns a list of certifications.</returns>
        //public IList<Certification> GetCertifications()
        //{
        //    return CertificationService.GetCertifications(APIKey);
        //}

        //#endregion

        //#region IndividualCertification service

        ///// <summary>
        ///// Get a set of individual certifications.
        ///// </summary>
        ///// <returns>Returns a list of individual certifications.</returns>
        //public IList<IndividualCertification> GetIndividualCertifications()
        //{
        //    return IndividualCertificationService.GetIndividualCertifications(APIKey);
        //}

        ///// <summary>
        ///// Get a set of individual certifications.
        ///// </summary>
        ///// <returns>Returns a list of individual certifications.</returns>
        //public IList<IndividualCertification> GetIndividualCertifications(DateTime? updatedSince)
        //{
        //    return IndividualCertificationService.GetIndividualCertifications(APIKey, updatedSince);
        //}

        ///// <summary>
        ///// Gets a single individual certification
        ///// </summary>
        ///// <param name="individualCertificationId"></param>
        ///// <returns></returns>
        //public IndividualCertification GetIndividualCertification(int individualCertificationId)
        //{
        //    return IndividualCertificationService.GetIndividualCertification(APIKey, individualCertificationId);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="individualCertification"></param>
        ///// <returns></returns>
        //public IndividualCertification UpdateIndividualCertification(IndividualCertification individualCertification)
        //{
        //    if (individualCertification == null)
        //    {
        //        throw new IllegalArgumentException(Config.Errors.IndividualOrId);
        //    }

        //    return IndividualCertificationService.Update(APIKey, individualCertification);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="individualCertification"></param>
        ///// <returns></returns>
        //public IndividualCertification InsertIndividualCertification(IndividualCertification individualCertification)
        //{
        //    if (individualCertification == null)
        //    {
        //        throw new IllegalArgumentException(Config.Errors.IndividualOrId);
        //    }

        //    return IndividualCertificationService.Insert(APIKey, individualCertification);
        //}

        //#endregion

        //#region Individual service

        ///// <summary>
        ///// Get a set of individuals.
        ///// </summary>
        ///// <param name="modifiedSince">limit individuals retrieved to individuals modified since the supplied date</param>
        ///// <param name="status">Match the exact individual status</param>
        ///// <returns>Returns a list of individuals.</returns>
        //public IList<Individual> GetIndividuals(DateTime? modifiedSince, IndividualStatus? status)
        //{
        //    return IndividualService.GetIndividuals(APIKey, modifiedSince, status);
        //}

        ///// <summary>
        ///// Get an individual individual.
        ///// </summary>
        ///// <param name="individualId">Id of the individual to retrieve</param>
        ///// <returns>Returns a individual.</returns>
        //public Individual GetIndividualByNBSId(string nbsId)
        //{
        //    if (string.IsNullOrEmpty(nbsId))
        //    {
        //        throw new IllegalArgumentException(Config.Errors.IndividualOrId);
        //    }

        //    return IndividualService.GetIndividualByNBSId(APIKey, nbsId);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="employeeNumber"></param>
        ///// <returns></returns>
        //public Individual GetIndividualByEmployeeNumber(string employeeNumber)
        //{
        //    if (string.IsNullOrEmpty(employeeNumber))
        //    {
        //        throw new IllegalArgumentException(Config.Errors.IndividualOrId);
        //    }

        //    return IndividualService.GetIndividualByEmployeeNumber(APIKey, employeeNumber);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="uniqueIdentifier"></param>
        ///// <returns></returns>
        //public Individual GetIndividualByUniqueIdentifer(string uniqueIdentifier)
        //{
        //    if (string.IsNullOrEmpty(uniqueIdentifier))
        //    {
        //        throw new IllegalArgumentException(Config.Errors.IndividualOrId);
        //    }

        //    return IndividualService.GetIndividualByUniqueIdentifier(APIKey, uniqueIdentifier);
        //}

        ///// <summary>
        ///// Add a new individual to an account.
        ///// </summary>
        ///// <param name="individual">Individual to add.</param>
        ///// <returns>Returns the newly created individual.</returns>
        //public Individual AddIndividual(Individual individual)
        //{
        //    if (individual == null)
        //    {
        //        throw new IllegalArgumentException(Config.Errors.IndividualOrId);
        //    }

        //    return IndividualService.AddIndividual(APIKey, individual);
        //}

        ///// <summary>
        ///// Update an individual individual.
        ///// </summary>
        ///// <param name="individual">Individual to update.</param>
        ///// <param name="actionByVisitor">Set to true if action by visitor.</param>
        ///// <returns>Returns the updated individual.</returns>
        ///// <exception cref="IllegalArgumentException">IllegalArgumentException</exception>
        ////public Individual UpdateIndividual(Individual individual, bool actionByVisitor)
        ////{
        ////    if (individual == null)
        ////    {
        ////        throw new IllegalArgumentException(Config.Errors.IndividualOrId);
        ////    }

        ////    return IndividualService.UpdateIndividual( APIKey, individual);
        ////}

        //#endregion

        #endregion
    }
}
