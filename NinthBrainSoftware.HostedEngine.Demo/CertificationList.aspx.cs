
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NinthBrainSoftware.HostedEngine.Client;
using System.Collections.Generic;
using System.Text;
using NinthBrainSoftware.HostedEngine.Client.Components;
using NinthBrainSoftware.HostedEngine.Client.Components.Certifications;

namespace NinthBrainSoftware.HostedEngine.Demo
{
    public partial class CertificationList : System.Web.UI.Page
    {
        NinthBrainSuite _ninthBrainSoftware = null;
        private string _apiKey = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            _apiKey = ConfigurationManager.AppSettings["HostedEngineAPIKey"];

            _ninthBrainSoftware = new NinthBrainSuite(_apiKey);

            IList<Certification> certList = _ninthBrainSoftware.GetCertifications();

            StringBuilder ct = new StringBuilder();

            ct.AppendLine("<table class=\"certificationsTableDiv\">");

            ct.AppendLine("<tr>");
            ct.AppendLine("<td> Certification ID</td>");
            ct.AppendLine("<td> Certification Name</td>");

            ct.AppendLine("</tr>");

            foreach (Certification reg in certList)
            {
                ct.AppendLine("<tr>");
                ct.AppendLine("<td>" + reg.CertificationId + "</td>");
                ct.AppendLine("<td>" + reg.CertificationName + "</td>");

                ct.AppendLine("</tr>");
            }

            ct.AppendLine("</table>");

            certificationsTableDiv.InnerHtml = ct.ToString();
        }
    }
}