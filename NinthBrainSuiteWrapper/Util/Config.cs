using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Collections;
using NinthBrainSoftware.HostedEngine.Client.Services;

namespace NinthBrainSoftware.HostedEngine.Client.Util
{

    public class Configuration
    {
        private string apiKey;
        private string serviceUrl;

        /// <summary>
        /// Single constuctor that contains the required properties
        /// </summary>
        /// <param name="serviceUrl">URL to the service, ex: https://api.ninthbrain.com</param>
        /// <param name="apiKey">The Application ID obtained by registering with the Ninth Brain Engine Service</param>
        public Configuration(string serviceUrl, string apiKey)
        {
            this.apiKey = apiKey;
            this.serviceUrl = serviceUrl;
        }

        /// <summary>
        /// The security key (password) linked to the application ID
        /// </summary>
        public string ApiKey
        {
            get { return apiKey; }
            set { apiKey = value; }
        }

        /// <summary>
        /// URL to the service, ex: http://api.ninthbrain.com
        /// </summary>
        public string ServiceUrl
        {
            get { return serviceUrl; }
            set { serviceUrl = value; }
        }

    }

    /// <summary>
    /// Configuration structure.
    /// </summary>
    public struct Config
    {

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
