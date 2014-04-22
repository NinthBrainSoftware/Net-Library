#region Using

using System;
using System.Collections.Generic;
using NinthBrainSoftware.HostedEngine.Client.Components.Individuals;
using NinthBrainSoftware.HostedEngine.Client.Components.Certifications;
using NinthBrainSoftware.HostedEngine.Client.Exceptions;
using NinthBrainSoftware.HostedEngine.Client.Services;
using NinthBrainSoftware.HostedEngine.Client.Util;
using NinthBrainSoftware.HostedEngine.Client.Components;
using System.Configuration;
using System.IO;
using System.Text;

#endregion

namespace NinthBrainSoftware.HostedEngine.Client
{
    /// <summary>
    /// Main class meant to be used by users to access Constant Contact API functionality.
    /// <example>
    /// ASPX page:
    /// <code>
    /// <![CDATA[
    ///  <%@Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    ///         CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default"%>
    ///  ...
    ///     <asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
    ///     <asp:Button ID="btnJoin" runat="server" Text="Join" onclick="btnJoin_Click" />
    ///     <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    ///  ...
    /// ]]>
    /// </code>
    /// </example>
    /// <example>
    /// Code behind:
    /// <code>
    /// <![CDATA[
    /// public partial class _Default : System.Web.UI.Page
    /// {
    ///    protected void Page_Load(object sender, EventArgs e)
    ///    {
    ///         ...
    ///    }
    ///
    ///    protected void btnJoin_Click(object sender, EventArgs e)
    ///    {
    ///        try
    ///        {
    ///            Contact contact = new Contact();
    ///            // Don't care about the id value
    ///            contact.Id = 1;
    ///            contact.EmailAddresses.Add(new EmailAddress() {
    ///                 EmailAddr = tbxEmail.Text,
    ///                 ConfirmStatus = ConfirmStatus.NoConfirmationRequired,
    ///                 Status = Status.Active });
    ///            contact.Lists.Add(new ContactList() {
    ///                 Id = 1,
    ///                 Status = Status.Active });
    ///
    ///            ConstantContact cc = new ConstantContact();
    ///            cc.AddContact(contact);
    ///            lblMessage.Text = "You have been added to my mailing list!";
    ///        }
    ///        catch (Exception ex) { lblMessage.Text = ex.ToString(); }
    ///    }
    /// }
    /// ]]>
    /// </code>
    /// </example>
    /// <example>
    /// Web.config entries:
    /// <code>
    /// <![CDATA[
    /// ...
    /// <appSettings>
    ///     <add key="APIKey" value="APIKey"/>
    ///     <add key="Password" value="password"/>
    ///     <add key="Username" value="username"/>
    ///     <add key="RedirectURL" value="http://somedomain"/>
    /// </appSettings>
    /// ...
    /// ]]>
    /// </code>
    /// </example>
    /// </summary>
    public class NinthBrainSuite
    {
        #region Fields

        /// <summary>
        /// Gets or sets the api_key
        /// </summary>
        private string APIKey { get; set; }

        #endregion

        #region Properties

        ///// <summary>
        ///// Gets or sets the Contact service.
        ///// </summary>
        //protected virtual IContactService ContactService { get; set; }

        ///// <summary>
        ///// Gets or sets the List service.
        ///// </summary>
        //protected virtual IListService ListService { get; set; }

        ///// <summary>
        ///// Gets or sets the Activity service.
        ///// </summary>
        //protected virtual IActivityService ActivityService { get; set; }

        ///// <summary>
        ///// Gets or sets the Campaign Schedule service.
        ///// </summary>
        //protected virtual ICampaignScheduleService CampaignScheduleService { get; set; }

        ///// <summary>
        ///// Gets or sets the Campaign Tracking service.
        ///// </summary>
        //protected virtual ICampaignTrackingService CampaignTrackingService { get; set; }

        ///// <summary>
        ///// Gets or sets the Contact Tracking service.
        ///// </summary>
        //protected virtual IContactTrackingService ContactTrackingService { get; set; }

        ///// <summary>
        ///// Gets or sets the Email Campaign service.
        ///// </summary>
        //protected virtual IEmailCampaignService EmailCampaignService { get; set; }

        ///// <summary>
        ///// Gets or sets the Account service
        ///// </summary>
        //protected virtual IAccountService AccountService { get; set; }

        ///// <summary>
        ///// Gets or sets the MyLibrary service
        ///// </summary>
        //protected virtual IMyLibraryService MyLibraryService { get; set; }

        ///// <summary>
        ///// Gets of sets the EventSpot service
        ///// </summary>
        //protected virtual IEventSpotService EventSpotService { get; set; }

        /// <summary>
        /// Gets or sets the IndividualService service
        /// </summary>
        protected virtual IIndividualService IndividualService { get; set; }

        /// <summary>
        /// Gets or sets the CertificationService service
        /// </summary>
        protected virtual ICertificationService CertificationService { get; set; }

        /// <summary>
        /// Gets or sets the IndividualCertificationService service
        /// </summary>
        protected virtual IIndividualCertificationService IndividualCertificationService { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new ConstantContact object using provided apiKey and accessToken parameters
        /// </summary>
        /// <param name="apiKey">APIKey</param>
        public NinthBrainSuite(string apiKey)
        {
            this.InitializeFields();

            this.APIKey = apiKey;
        }

        #endregion

        #region Private methods

        private void InitializeFields()
        {
            this.IndividualService = new IndividualService();
            this.CertificationService = new CertificationService();
            this.IndividualCertificationService = new IndividualCertificationService();
        }

        #endregion

        #region Public methods

        #region Certification service

        /// <summary>
        /// Get a set of certifications.
        /// </summary>
        /// <returns>Returns a list of certifications.</returns>
        public IList<Certification> GetCertifications()
        {
            return CertificationService.GetCertifications(APIKey);
        }

        #endregion

        #region IndividualCertification service

        /// <summary>
        /// Get a set of individual certifications.
        /// </summary>
        /// <returns>Returns a list of individual certifications.</returns>
        public IList<IndividualCertification> GetIndividualCertifications()
        {
            return IndividualCertificationService.GetIndividualCertifications(APIKey);
        }

        /// <summary>
        /// Get a set of individual certifications.
        /// </summary>
        /// <returns>Returns a list of individual certifications.</returns>
        public IList<IndividualCertification> GetIndividualCertifications(DateTime? updatedSince)
        {
            return IndividualCertificationService.GetIndividualCertifications(APIKey, updatedSince);
        }

        /// <summary>
        /// Gets a single individual certification
        /// </summary>
        /// <param name="individualCertificationId"></param>
        /// <returns></returns>
        public IndividualCertification GetIndividualCertification(int individualCertificationId)
        {
            return IndividualCertificationService.GetIndividualCertification(APIKey, individualCertificationId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="individualCertification"></param>
        /// <returns></returns>
        public IndividualCertification UpdateIndividualCertification(IndividualCertification individualCertification)
        {
            if (individualCertification == null)
            {
                throw new IllegalArgumentException(Config.Errors.IndividualOrId);
            }

            return IndividualCertificationService.Update(APIKey, individualCertification); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="individualCertification"></param>
        /// <returns></returns>
        public IndividualCertification InsertIndividualCertification(IndividualCertification individualCertification)
        {
            if (individualCertification == null)
            {
                throw new IllegalArgumentException(Config.Errors.IndividualOrId);
            }

            return IndividualCertificationService.Insert(APIKey, individualCertification);
        }

        #endregion

        #region Individual service

        /// <summary>
        /// Get a set of individuals.
        /// </summary>
        /// <param name="modifiedSince">limit individuals retrieved to individuals modified since the supplied date</param>
        /// <param name="status">Match the exact individual status</param>
        /// <returns>Returns a list of individuals.</returns>
        public IList<Individual> GetIndividuals(DateTime? modifiedSince, IndividualStatus? status)
        {
            return IndividualService.GetIndividuals(APIKey, modifiedSince, status);
        }

        /// <summary>
        /// Get an individual individual.
        /// </summary>
        /// <param name="individualId">Id of the individual to retrieve</param>
        /// <returns>Returns a individual.</returns>
        public Individual GetIndividualByNBSId(string nbsId)
        {
            if (string.IsNullOrEmpty(nbsId))
            {
                throw new IllegalArgumentException(Config.Errors.IndividualOrId);
            }

            return IndividualService.GetIndividualByNBSId(APIKey, nbsId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeNumber"></param>
        /// <returns></returns>
        public Individual GetIndividualByEmployeeNumber(string employeeNumber)
        {
            if (string.IsNullOrEmpty(employeeNumber))
            {
                throw new IllegalArgumentException(Config.Errors.IndividualOrId);
            }

            return IndividualService.GetIndividualByEmployeeNumber(APIKey, employeeNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public Individual GetIndividualByUniqueIdentifer(string uniqueIdentifier)
        {
            if (string.IsNullOrEmpty(uniqueIdentifier))
            {
                throw new IllegalArgumentException(Config.Errors.IndividualOrId);
            }

            return IndividualService.GetIndividualByUniqueIdentifier(APIKey, uniqueIdentifier);
        }

        /// <summary>
        /// Add a new individual to an account.
        /// </summary>
        /// <param name="individual">Individual to add.</param>
       /// <returns>Returns the newly created individual.</returns>
        public Individual AddIndividual(Individual individual)
        {
            if (individual == null)
            {
                throw new IllegalArgumentException(Config.Errors.IndividualOrId);
            }

            return IndividualService.AddIndividual(APIKey, individual);
        }

        /// <summary>
        /// Update an individual individual.
        /// </summary>
        /// <param name="individual">Individual to update.</param>
        /// <param name="actionByVisitor">Set to true if action by visitor.</param>
        /// <returns>Returns the updated individual.</returns>
        /// <exception cref="IllegalArgumentException">IllegalArgumentException</exception>
        //public Individual UpdateIndividual(Individual individual, bool actionByVisitor)
        //{
        //    if (individual == null)
        //    {
        //        throw new IllegalArgumentException(Config.Errors.IndividualOrId);
        //    }

        //    return IndividualService.UpdateIndividual( APIKey, individual);
        //}

        #endregion

        #endregion
    }
}
