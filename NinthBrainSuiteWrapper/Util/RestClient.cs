﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Configuration;

namespace NinthBrainSoftware.HostedEngine.Client.Util
{
    /// <summary>
    /// Class implementation of REST client.
    /// </summary>
    public class RestClient : IRestClient
    {
        /// <summary>
        /// Make an Http GET request.
        /// </summary>
        /// <param name="url">Request URL.</param>
        /// <param name="accessToken">Constant Contact OAuth2 access token</param>
        /// <param name="apiKey">The API key for the application</param>
        /// <returns>The response body, http info, and error (if one exists).</returns>
        public CUrlResponse Get(string url, string apiKey)
        {
            return this.HttpRequest(url, WebRequestMethods.Http.Get, apiKey, null, null);
        }

        /// <summary>
        /// Make an Http POST request.
        /// </summary>
        /// <param name="url">Request URL.</param>
        /// <param name="accessToken">Constant Contact OAuth2 access token</param>
        /// <param name="apiKey">The API key for the application</param>
        /// <param name="data">Data to send with request.</param>
        /// <returns>The response body, http info, and error (if one exists).</returns>
        public CUrlResponse Post(string url, string apiKey, string data)
        {
			byte[] bytes = null;

			if(!string.IsNullOrEmpty(data))
			{
				// Convert the request contents to a byte array
				bytes = System.Text.Encoding.UTF8.GetBytes(data);
			}

            return this.HttpRequest(url, WebRequestMethods.Http.Post,  apiKey, bytes, null);
        }

        /// <summary>
        /// Make an Http PATCH request.
        /// </summary>
        /// <param name="url">Request URL.</param>
        /// <param name="accessToken">Constant Contact OAuth2 access token</param>
        /// <param name="apiKey">The API key for the application</param>
        /// <param name="data">Data to send with request.</param>
        /// <returns>The response body, http info, and error (if one exists).</returns>
        public CUrlResponse Patch(string url,  string apiKey, string data)
        {
            byte[] bytes = null;

            if (!string.IsNullOrEmpty(data))
            {
                // Convert the request contents to a byte array
                bytes = System.Text.Encoding.UTF8.GetBytes(data);
            }

            return this.HttpRequest(url, "PATCH", apiKey, bytes, null);
        }

		/// <summary>
		/// Make an HTTP Post Multipart request.
		/// </summary>
		/// <param name="url">Request URL.</param>
        /// <param name="accessToken">Constant Contact OAuth2 access token</param>
        /// <param name="apiKey">The API key for the application</param>
        /// <param name="data">Data to send with request.</param>
        /// <returns>The response body, http info, and error (if one exists).</returns>
		public CUrlResponse PostMultipart(string url,  string apiKey, byte[] data)
        {
            return this.HttpRequest(url, WebRequestMethods.Http.Post,  apiKey, data, true);
        }

        /// <summary>
        /// Make an Http PUT request.
        /// </summary>
        /// <param name="url">Request URL.</param>
        /// <param name="accessToken">Constant Contact OAuth2 access token</param>
        /// <param name="apiKey">The API key for the application</param>
        /// <param name="data">Data to send with request.</param>
        /// <returns>The response body, http info, and error (if one exists).</returns>
        public CUrlResponse Put(string url, string apiKey, string data)
        {
			byte[] bytes = null;

			if(!string.IsNullOrEmpty(data))
			{
				// Convert the request contents to a byte array 
				bytes = System.Text.Encoding.UTF8.GetBytes(data);
			}

            return this.HttpRequest(url, WebRequestMethods.Http.Put,  apiKey, bytes, null);
        }

        /// <summary>
        /// Make an Http DELETE request.
        /// </summary>
        /// <param name="url">Request URL.</param>
        /// <param name="accessToken">Constant Contact OAuth2 access token</param>
        /// <param name="apiKey">The API key for the application</param>
        /// <returns>The response body, http info, and error (if one exists).</returns>
        public CUrlResponse Delete(string url, string apiKey)
        {
            return this.HttpRequest(url, "DELETE", apiKey, null, null);
        }

        private CUrlResponse HttpRequest(string url, string method, string apiKey, byte[] data, bool? isMultipart)
        {
            // Initialize the response
            HttpWebResponse response = null;
            string responseText = null;
            CUrlResponse urlResponse = new CUrlResponse();

            var address = url;

            //Moved apiKey to header value
            //if (!string.IsNullOrEmpty(apiKey))
            //{
            //    address = string.Format("{0}{1}api_key={2}", url, url.Contains("?") ? "&" : "?", apiKey);
            //}

            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                                                                                             
            request.Method = method;
			request.Accept = "application/json";

			if(isMultipart.HasValue && isMultipart.Value)
			{
				request.ContentType = "multipart/form-data; boundary=" + MultipartBuilder.MULTIPART_BOUNDARY;
			}
			else
			{
				request.ContentType = "application/json";			
			}
          
            // Add token as HTTP header
            //request.Headers.Add("Authorization", "Bearer " + accessToken);
            request.Headers.Add("Authorization-Token", apiKey);
           
            if (data != null)
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            // Now try to send the request
            try
            {
                response = request.GetResponse() as HttpWebResponse;
                // Expect the unexpected
                if (request.HaveResponse == true && response == null)
                {
                    throw new WebException("Response was not returned or is null");
                }
				foreach(string header in response.Headers.AllKeys)
				{
					urlResponse.Headers.Add(header, response.GetResponseHeader(header));
				}

                urlResponse.StatusCode = response.StatusCode;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new WebException("Response with status: " + response.StatusCode + " " + response.StatusDescription);
                }
            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    response = (HttpWebResponse)e.Response;
                    urlResponse.IsError = true;
                }
            }
            finally
            {
                if (response != null)
                {
                    // Get the response content
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        responseText = reader.ReadToEnd();
                    }
                    response.Close();
                    if (urlResponse.IsError && responseText.Contains("error_message"))
                    {
                        urlResponse.Info = CUrlRequestError.FromJSON<IList<CUrlRequestError>>(responseText);
                    }
                    else
                    {
                        urlResponse.Body = responseText;
                    }
                }
            }

            return urlResponse;
        }
    }
}
