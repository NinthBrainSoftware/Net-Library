
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
using NinthBrainSoftware.HostedEngine.Client.Components.Individuals;
using NinthBrainSoftware.HostedEngine.Client.Exceptions;

namespace NinthBrainSoftware.HostedEngine.Demo
{
    public partial class IndividualSearch : System.Web.UI.Page
    {
        NinthBrainSuite _ninthBrainSoftware = null;
        private string _apiKey = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            _apiKey = ConfigurationManager.AppSettings["HostedEngineAPIKey"];

            _ninthBrainSoftware = new NinthBrainSuite(_apiKey);

            IList<Individual> indList = _ninthBrainSoftware.GetIndividuals(null, null);

            this.gvIndividual.DataSource = indList;
            this.gvIndividual.DataBind();
        }

        protected virtual void gvIndividual_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Int32.Parse((string)e.CommandArgument);
                int nbsId = (int)this.gvIndividual.DataKeys[index].Values["NBSId"];

                PopulateIndividual(nbsId);
            }
        }

        private void PopulateIndividual(int nbsId)
        {
            try
            {
                this.detailwrapper.Visible = true;
                this.listwrapper.Visible = false;

                Individual ind;

                ind = _ninthBrainSoftware.GetIndividualByNBSId(nbsId.ToString());

                DateTime now = DateTime.Now;

                this.firstName.Text = ind.FirstName;
                this.lastName.Text = ind.LastName;
                this.uniqueIdentifier.Text = ind.UniqueNumber;
                this.logonId.Text = ind.LogonId;
                this.password.Visible = false;

                this.btnInsert.Visible = false;
                this.btnUpdate.Visible = true;

                this.message.Text = string.Format("{0} {1} was found on {2}.", ind.FirstName, ind.LastName, now.ToString());
            }
            catch (IllegalArgumentException illegalEx)
            {
                this.message.Text = GetExceptionsDetails(illegalEx, "IllegalArgumentException");
            }
            catch (NinthBrainAPIException nbEx)
            {
                this.message.Text = GetExceptionsDetails(nbEx, "NinthBrainAPIException");
            }
            catch (Exception ex)
            {
                this.message.Text = GetExceptionsDetails(ex, "Exception");
            }

        }

        protected virtual void gvIndividual_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Individual o = (Individual)e.Row.DataItem;
                Literal ltlEmployee = (Literal)e.Row.FindControl("ltlEmployee");

                ltlEmployee.Text = string.Format("{0} {1}", o.FirstName, o.LastName);
            }

        }

        protected virtual void btnAddNew_Click(object sender, EventArgs e)
        {
            this.listwrapper.Visible = false;
            this.detailwrapper.Visible = true;

            this.lastName.Text = "";
            this.lastName.Text = this.lastName.Text;
            this.uniqueIdentifier.Text = this.uniqueIdentifier.Text;
            this.logonId.Text = this.logonId.Text;
            this.password.Visible = true;

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

        }

        protected virtual void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Individual ind = new Individual();

                ind.FirstName = this.firstName.Text;
                ind.LastName = this.lastName.Text;
                ind.UniqueNumber = this.uniqueIdentifier.Text;
                ind.LogonId = this.logonId.Text;
                ind.Password = this.password.Text;
                ind.PhoneNumbers.Add(new PhoneNumber(this.businessPhoneNumber.Text, "Business1"));
                ind.PhoneNumbers.Add(new PhoneNumber(this.homePhoneNumber.Text, "Home1"));

                _ninthBrainSoftware.AddIndividual(ind);

                DateTime now = DateTime.Now;

                this.message.Text = string.Format("{0} {1} was inserted on {2}.", ind.FirstName, ind.LastName, now.ToString());
            }
            catch (IllegalArgumentException illegalEx)
            {
                this.message.Text = GetExceptionsDetails(illegalEx, "IllegalArgumentException");
            }
            catch (NinthBrainAPIException nbEx)
            {
                this.message.Text = GetExceptionsDetails(nbEx, "NinthBrainAPIException");
            }
            catch (Exception ex)
            {
                this.message.Text = GetExceptionsDetails(ex, "Exception");
            }


        }

        protected virtual void btnSearchByNbsId_Click(object sender, EventArgs e)
        {
            try
            {
                Individual ind;

                ind = _ninthBrainSoftware.GetIndividualByNBSId(this.nbsIdSearch.Text);

                DateTime now = DateTime.Now;

                this.message.Text = string.Format("{0} {1} was found on {2}.", ind.FirstName, ind.LastName, now.ToString());
            }
            catch (IllegalArgumentException illegalEx)
            {
                this.message.Text = GetExceptionsDetails(illegalEx, "IllegalArgumentException");
            }
            catch (NinthBrainAPIException nbEx)
            {
                this.message.Text = GetExceptionsDetails(nbEx, "NinthBrainAPIException");
            }
            catch (Exception ex)
            {
                this.message.Text = GetExceptionsDetails(ex, "Exception");
            }
        }

        protected virtual void btnSearchByUniqueIdentifier_Click(object sender, EventArgs e)
        {
            try
            {
                Individual ind = new Individual();

                _ninthBrainSoftware.GetIndividualByUniqueIdentifer(this.uniqueIdentifierSearch.Text);

                DateTime now = DateTime.Now;

                this.message.Text = string.Format("{0} {1} was found on {2}.", ind.FirstName, ind.LastName, now.ToString());
            }
            catch (IllegalArgumentException illegalEx)
            {
                this.message.Text = GetExceptionsDetails(illegalEx, "IllegalArgumentException");
            }
            catch (NinthBrainAPIException nbEx)
            {
                this.message.Text = GetExceptionsDetails(nbEx, "NinthBrainAPIException");
            }
            catch (Exception ex)
            {
                this.message.Text = GetExceptionsDetails(ex, "Exception");
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