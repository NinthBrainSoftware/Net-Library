﻿
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
    
        protected void Page_Load(object sender, EventArgs e)
        {            
            IList<Certification> certList = NinthBrainSuiteAPI.CertificationService.GetCertifications();

            this.gvCertification.DataSource = certList;
            this.gvCertification.DataBind();
        }
    }
}