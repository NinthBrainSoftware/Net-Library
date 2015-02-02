
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
using NinthBrainSoftware.HostedEngine.Client.Components.EducationTraining;
using NinthBrainSoftware.HostedEngine.Client.Components.Individuals;

namespace NinthBrainSoftware.HostedEngine.Demo
{
    public partial class IndividualCourseList : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.startDate.Text = DateTime.Now.AddDays(-30).Date.ToString();
                this.endDate.Text = DateTime.Now.Date.ToString();
                            }
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            try
            {
                IList<IndividualCourse> courseList = NinthBrainSuiteAPI.IndividualCourseService.GetIndividualCourses(0, Convert.ToDateTime(startDate.Text), Convert.ToDateTime(endDate.Text));

                this.gvCourse.DataSource = courseList;
                this.gvCourse.DataBind();
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

        protected virtual void gvCourse_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                IndividualCourse o = (IndividualCourse)e.Row.DataItem;
                Literal ltlEmployee = (Literal)e.Row.FindControl("ltlEmployee");
                
                ltlEmployee.Text = string.Format("{0} {1}", o.FirstName, o.LastName);
            }

        }

        protected virtual void btnFilter_Click(object sender, EventArgs e)
        {
            PopulateGrid();
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