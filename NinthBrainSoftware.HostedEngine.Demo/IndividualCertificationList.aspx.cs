
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
using NinthBrainSoftware.HostedEngine.Client.Exceptions;
using NinthBrainSoftware.HostedEngine.Client.Components.Certifications;
using NinthBrainSoftware.HostedEngine.Client.Components.Individuals;

namespace NinthBrainSoftware.HostedEngine.Demo
{
    public partial class IndividualCertificationList : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            IList<IndividualCertification> certList = NinthBrainSuiteAPI.IndividualCertificationService.GetIndividualCertifications();

            this.gvCertification.DataSource = certList;
            this.gvCertification.DataBind();
        }

        protected virtual void gvCertification_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Int32.Parse((string)e.CommandArgument);
                int individualCertificationId = (int)this.gvCertification.DataKeys[index].Values["IndividualCertificationId"];

                this.individualCertificationId.Value = individualCertificationId.ToString();

                PopulateIndividualCertification(individualCertificationId);
            }
        }

        private void HideMessage()
        {
            this.messagePanel.Visible = false;
        }

        private void ShowMessage(string message)
        {
            this.message.Text = message;
            this.messagePanel.Visible = true;
            this.messagePanel.CssClass = "formee-msg-success";
        }

        private void ShowErrorMessage(string message)
        {
            this.message.Text = message;
            this.messagePanel.Visible = true;
            this.messagePanel.CssClass = "formee-msg-error";
        }

        private void PopulateDropdowns()
        {
            this.certification.Items.Clear();
            IList<Certification> certList = NinthBrainSuiteAPI.CertificationService.GetCertifications();

            this.certification.DataSource = certList;
            this.certification.DataBind();

            this.certification.Items.Insert(0, new ListItem("", "0"));

            this.individual.Items.Clear();
            IList<Individual> indList = NinthBrainSuiteAPI.IndividualService.GetIndividuals(null, null);

            this.individual.DataSource = indList;
            this.individual.DataBind();

            this.individual.Items.Insert(0, new ListItem("", "0"));
        }
        private void PopulateIndividualCertification(int individualCertificationId)
        {
            try
            {
                PopulateDropdowns();

                this.detailwrapper.Visible = true;
                this.listwrapper.Visible = false;

                IndividualCertification indCert;

                indCert = NinthBrainSuiteAPI.IndividualCertificationService.GetIndividualCertification(individualCertificationId);

                DateTime now = DateTime.Now;

                this.certification.SelectedValue = indCert.CertificationId.ToString();
                this.individual.SelectedValue = indCert.NBSId.ToString();
                this.activationDate.Text = indCert.ActivationDate.ToShortDateString();
                this.expirationDate.Text = indCert.ExpirationDate.ToShortDateString();
                this.certificationNumber.Text = indCert.CertificationNumber;
                this.stateCode.Text = indCert.State;
                this.countryCode.Text = indCert.Country;

                this.btnInsert.Visible = false;
                this.btnUpdate.Visible = true;
            }
            catch (IllegalArgumentException illegalEx)
            {
                ShowErrorMessage(GetExceptionsDetails(illegalEx, "IllegalArgumentException"));
            }
            catch (NinthBrainAPIException nbEx)
            {
                ShowErrorMessage(GetExceptionsDetails(nbEx, "NinthBrainAPIException"));
            }
            catch (Exception ex)
            {
                ShowErrorMessage(GetExceptionsDetails(ex, "Exception"));
            }

        }

        protected virtual void gvCertification_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                IndividualCertification o = (IndividualCertification)e.Row.DataItem;
                Literal ltlEmployee = (Literal)e.Row.FindControl("ltlEmployee");

                ltlEmployee.Text = string.Format("{0} {1}", o.FirstName, o.LastName);
            }

        }

        protected virtual void btnAddNew_Click(object sender, EventArgs e)
        {
            this.listwrapper.Visible = false;
            this.detailwrapper.Visible = true;

            PopulateDropdowns();

            this.individualCertificationId.Value = "";
            this.activationDate.Text = "";
            this.expirationDate.Text = "";
            this.certificationNumber.Text = "";
            this.countryCode.Text = "";
            this.stateCode.Text = "";

            this.btnInsert.Visible = true;
            this.btnUpdate.Visible = false;

        }

        protected virtual void btnBackToList_Click(object sender, EventArgs e)
        {
            this.listwrapper.Visible = true;
            this.detailwrapper.Visible = false;

            PopulateGrid();
        }

        protected virtual void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                IndividualCertification indCert = new IndividualCertification();

                indCert.IndividualCertificationId = Convert.ToInt32(individualCertificationId.Value);
                indCert.CertificationId = Convert.ToInt32(this.certification.SelectedValue);
                indCert.NBSId = Convert.ToInt32(this.individual.SelectedValue);
                indCert.ActivationDate = Convert.ToDateTime(this.activationDate.Text);
                indCert.ExpirationDate = Convert.ToDateTime(this.expirationDate.Text);
                indCert.CertificationNumber = this.certificationNumber.Text;
                indCert.State = this.stateCode.Text;
                indCert.Country = this.countryCode.Text;

                NinthBrainSuiteAPI.IndividualCertificationService.Update(indCert);

                DateTime now = DateTime.Now;

                ShowMessage("The IndividualCertification was Updated.");
            }
            catch (IllegalArgumentException illegalEx)
            {
                ShowErrorMessage(GetExceptionsDetails(illegalEx, "IllegalArgumentException"));
            }
            catch (NinthBrainAPIException nbEx)
            {
                ShowErrorMessage(GetExceptionsDetails(nbEx, "NinthBrainAPIException"));
            }
            catch (Exception ex)
            {
                ShowErrorMessage(GetExceptionsDetails(ex, "Exception"));
            }

        }

        protected virtual void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                IndividualCertification indCert = new IndividualCertification();

                indCert.CertificationId = Convert.ToInt32(this.certification.SelectedValue);
                indCert.NBSId = Convert.ToInt32(this.individual.SelectedValue);
                indCert.ActivationDate = Convert.ToDateTime(this.activationDate.Text);
                indCert.ExpirationDate = Convert.ToDateTime(this.expirationDate.Text);
                indCert.CertificationNumber = this.certificationNumber.Text;
                indCert.State = this.stateCode.Text;
                indCert.Country = this.countryCode.Text;

                NinthBrainSuiteAPI.IndividualCertificationService.Insert(indCert);

                ShowMessage("The IndividualCertification was Inserted.");
            }
            catch (IllegalArgumentException illegalEx)
            {
                ShowErrorMessage(GetExceptionsDetails(illegalEx, "IllegalArgumentException"));
            }
            catch (NinthBrainAPIException nbEx)
            {
                ShowErrorMessage( GetExceptionsDetails(nbEx, "NinthBrainAPIException"));
            }
            catch (Exception ex)
            {
                ShowErrorMessage(GetExceptionsDetails(ex, "Exception"));
            }


        }

        private string GetExceptionsDetails(Exception ex, string exceptionType)
        {
            StringBuilder sbExceptions = new StringBuilder();

            sbExceptions.Append(string.Format("{0} thrown:\n", exceptionType));
            sbExceptions.Append(string.Format("Error message: {0}", ex.Message));

            return sbExceptions.ToString();
        }
    }
}