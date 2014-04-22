using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Collections;
using NinthBrainSoftware.HostedEngine.Client.Services;

namespace NinthBrainSoftware.HostedEngine.Client.Util
{
    /// <summary>
    /// Configuration structure.
    /// </summary>
    public struct Config
    {
        /// <summary>
        /// REST endpoints.
        /// </summary>
        public struct Endpoints
        {
            /// <summary>
            /// API access URL.
            /// </summary>
            public const string BaseUrl = "http://localhost/betaapi/";
            /// <summary>
            /// Access an activity.
            /// </summary>
            public const string Activity = "activities/{0}";
            /// <summary>
            /// List activities.
            /// </summary>
            public const string Activities = "activities";
            /// <summary>
            /// Export contacts linked to an activity.
            /// </summary>
            public const string ExportContactsActivity = "activities/exportcontacts";
            /// <summary>
            /// Clear the list of activities.
            /// </summary>
            public const string ClearListsActivity = "activities/clearlists";
            /// <summary>
            /// Remove from list.
            /// </summary>
            public const string RemoveFromListsActivity = "activities/removefromlists";
            /// <summary>
            /// Add contacts to activities.
            /// </summary>
            public const string AddContactsActivity = "activities/addcontacts";
            /// <summary>
            /// Access a contact.
            /// </summary>
            public const string Contact = "contacts/{0}";
            /// <summary>
            /// Get all contacts.
            /// </summary>
            public const string Contacts = "contacts";
            /// <summary>
            /// Get all lists.
            /// </summary>
            public const string Lists = "lists";
            /// <summary>
            /// Access a specified list.
            /// </summary>
            public const string List = "lists/{0}";
            /// <summary>
            /// Get the list of contacts from a list.
            /// </summary>
            public const string ListContacts = "lists/{0}/contacts";
            /// <summary>
            /// Get contact lists.
            /// </summary>
            public const string ContactLists = "contacts/{0}/lists";
            /// <summary>
            /// Get a list from contact lists.
            /// </summary>
            public const string ContactList = "contacts/{0}/lists/{1}";
            /// <summary>
            /// Get campaigns.
            /// </summary>
            public const string Campaigns = "emailmarketing/campaigns";
            /// <summary>
            /// Access a campaign
            /// </summary>
            public const string Campaign = "emailmarketing/campaigns/{0}";
            /// <summary>
            /// Campaign schedules.
            /// </summary>
            public const string CampaignSchedules = "emailmarketing/campaigns/{0}/schedules";
            /// <summary>
            /// Campaign schedule.
            /// </summary>
            public const string CampaignSchedule = "emailmarketing/campaigns/{0}/schedules/{1}";
            /// <summary>
            /// Campaign test sends.
            /// </summary>
            public const string CampaignTestSends = "emailmarketing/campaigns/{0}/tests";
            /// <summary>
            /// Campaign tracking summary.
            /// </summary>
            public const string CampaignTrackingSummary = "emailmarketing/campaigns/{0}/tracking/reports/summary";
            /// <summary>
            /// Campaign tracking bounces.
            /// </summary>
            public const string CampaignTrackingBounces = "emailmarketing/campaigns/{0}/tracking/bounces";
            /// <summary>
            /// Campaign tracking clicks.
            /// </summary>
            public const string CampaignTrackingClicks = "emailmarketing/campaigns/{0}/tracking/clicks";
            /// <summary>
            /// Campaign tracking clicks for a specific link.
            /// </summary>
            public const string CampaignTrackingClicksForLink = "emailmarketing/campaigns/{0}/tracking/clicks/{1}";
            /// <summary>
            /// Campaign tracking forwards.
            /// </summary>
            public const string CampaignTrackingForwards = "emailmarketing/campaigns/{0}/tracking/forwards";
            /// <summary>
            /// Campaign tracking opens.
            /// </summary>
            public const string CampaignTrackingOpens = "emailmarketing/campaigns/{0}/tracking/opens";
            /// <summary>
            /// Campaign tracking sends.
            /// </summary>
            public const string CampaignTrackingSends = "emailmarketing/campaigns/{0}/tracking/sends";
            /// <summary>
            /// Campaign tracking unsubscribes.
            /// </summary>
            public const string CampaignTrackingUnsubscribes = "emailmarketing/campaigns/{0}/tracking/unsubscribes";
            /// <summary>
            /// Campaign tracking link.
            /// </summary>
            public const string CampaignTrackingLink = "emailmarketing/campaigns/{0}/tracking/clicks/{1}";
			/// <summary>
			/// Contact tracking activities.
			/// </summary>
			public const string ContactTrackingActivities = "contacts/{0}/tracking";
			/// <summary>
			/// Contact tracking activities by email campaign.
			/// </summary>
			public const string ContactTrackingEmailCampaignActivities = "contacts/{0}/tracking/reports/summaryByCampaign";
            /// <summary>
            /// Contact tracking summary.
            /// </summary>
            public const string ContactTrackingSummary = "contacts/{0}/tracking/reports/summary";
            /// <summary>
            /// Contact tracking bounces.
            /// </summary>
            public const string ContactTrackingBounces = "contacts/{0}/tracking/bounces";
            /// <summary>
            /// Contact tracking clicks.
            /// </summary>
            public const string ContactTrackingClicks = "contacts/{0}/tracking/clicks";
            /// <summary>
            /// Contact tracking forwards.
            /// </summary>
            public const string ContactTrackingForwards = "contacts/{0}/tracking/forwards";
            /// <summary>
            /// Contact tracking opens.
            /// </summary>
            public const string ContactTrackingOpens = "contacts/{0}/tracking/opens";
            /// <summary>
            /// Contact tracking sends.
            /// </summary>
            public const string ContactTrackingSends = "contacts/{0}/tracking/sends";
            /// <summary>
            /// Contact tracking unsubscribes.
            /// </summary>
            public const string ContactTrackingUnsubscribes = "contacts/{0}/tracking/unsubscribes";
            /// <summary>
            /// Contact tracking link.
            /// </summary>
            public const string ContactTrackingLink = "contacts/{0}/tracking/clicks/{1}";
            /// <summary>
            /// Account verified email addresses link
            /// </summary>
            public const string AccountVerifiedEmailAddressess = "account/verifiedemailaddresses";
			/// <summary>
			/// MyLibrary information
			/// </summary>
			public const string MyLibraryInfo = "library/info";
			/// <summary>
			/// MyLibrary folders
			/// </summary>
			public const string MyLibraryFolders = "library/folders";
			/// <summary>
			///  Access a specified folder
			/// </summary>
			public const string MyLibraryFolder = "library/folders/{0}";
			/// <summary>
			/// Files in Trash folder
			/// </summary>
			public const string MyLibraryTrash = "library/folders/trash/files";
			/// <summary>
			/// MyLibrray files
			/// </summary>
			public const string MyLibraryFiles = "library/files";
			/// <summary>
			/// MyLibrary file
			/// </summary>
			public const string MyLibraryFile = "library/files/{0}";
			/// <summary>
			/// MyLibrary files for a specific folder
			/// </summary>
			public const string MyLibraryFolderFiles = "library/folders/{0}/files";
			/// <summary>
			/// MyLibrary file upload status
			/// </summary>
			public const string MyLibraryFileUploadStatus = "library/files/uploadstatus/{0}";
            /// <summary>
            /// EventSpot Events Collection Endpoint
            /// </summary>
            public const string EventSpots = "eventspot/events";
            /// <summary>
            /// Individual Event Fees Endpoint
            /// </summary>
            public const string EventFees = "eventspot/events/{0}/fees/{1}";
            /// <summary>
            /// Individual Promocode Endpoint
            /// </summary>
            public const string EventPromocode = "eventspot/events/{0}/promocodes/{1}";
            /// <summary>
            /// Individual Event Registrant Endpoint
            /// </summary>
            public const string  EventRegistrant = "eventspot/events/{0}/registrants/{1}";
            /// <summary>
            /// Event Item Endpoint
            /// </summary>
            public const string EventItem = "eventspot/events/{0}/items/{1}";
            /// <summary>
            /// Item Attribute Endpoint
            /// </summary>
            public const string ItemAttribute= "eventspot/events/{0}/items/{1}/attributes/{2}";
           
        }

                /// <summary>
        /// Errors to be returned for various exceptions.
        /// </summary>
        public struct Errors
        {
            public const string IndividualOrId = "Only an interger or Individual are allowed for this method.";
           
            /// <summary>
            /// Objects null
            /// </summary>
            public const string ObjectNull = "Object provided is not valid.";
        }

        /// <summary>
        /// Accept header value.
        /// </summary>
        public const string HeaderAccept = "text/html, application/xhtml+xml, */*";
        /// <summary>
        /// ContentType header value.
        /// </summary>
        public const string HeaderContentType = "application/x-www-form-urlencoded";
        /// <summary>
        /// UserAgent header value.
        /// </summary>
        public const string HeaderUserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";

        /// <summary>
        /// Creates the URL for API access.
        /// </summary>
        /// <param name="urlPart">URL part.</param>
        /// <param name="prms">Additional parameters for URL formatting.</param>
        /// <param name="queryList">Query parameters to add to the URL.</param>
        /// <returns>Returns the URL with all specified query parameters.</returns>
        public static string ConstructUrl(string urlPart, object[] prms, object[] queryList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Endpoints.BaseUrl);
            if (prms == null)
            {
                sb.Append(urlPart);
            }
            else
            {
                sb.AppendFormat(urlPart, prms);
            }
            if (queryList != null)
            {
                sb.Append(BaseService.GetQueryParameters(queryList));
            }

            return sb.ToString();
        }
    }
}
