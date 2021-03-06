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
using NinthBrainSoftware.HostedEngine.Client.Components.Individuals;
using NinthBrainSoftware.HostedEngine.Client.Exceptions;
using NinthBrainSoftware.HostedEngine.Client.Components.Company;
using NinthBrainSoftware.HostedEngine.Client.Components.Certifications;

namespace NinthBrainSoftware.HostedEngine.Demo
{
    public partial class IndividualList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            IList<Individual> indList = NinthBrainSuiteAPI.IndividualService.GetIndividuals(null, null);

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

        private void PopulateDropdowns()
        {

            this.department.Items.Clear();
            IList<Department> departmentList = NinthBrainSuiteAPI.DepartmentService.GetDepartments();

            this.department.DataSource = departmentList;
            this.department.DataBind();

            this.department.Items.Insert(0, new ListItem("", "0"));

            this.locale.Items.Clear();
            IList<Locale> localeList = NinthBrainSuiteAPI.LocaleService.GetLocales();

            this.locale.DataSource = localeList;
            this.locale.DataBind();

            this.locale.Items.Insert(0, new ListItem("", "0"));

            this.jobTitle.Items.Clear();
            IList<JobTitle> jobTitleList = NinthBrainSuiteAPI.JobTitleService.GetJobTitles();

            this.jobTitle.DataSource = jobTitleList;
            this.jobTitle.DataBind();

            this.jobTitle.Items.Insert(0, new ListItem("", "0"));

            this.workShift.Items.Clear();
            IList<WorkShift> workShiftList = NinthBrainSuiteAPI.WorkShiftService.GetWorkShifts();

            this.workShift.DataSource = workShiftList;
            this.workShift.DataBind();

            this.workShift.Items.Insert(0, new ListItem("", "0"));

        }

        private Individual PopulateChanges()
        {
            Individual ind = new Individual();

            if (!string.IsNullOrEmpty(nbsId.Value))
            {
                ind = NinthBrainSuiteAPI.IndividualService.GetIndividualByNBSId(nbsId.Value);
            }

            ind.FirstName = this.firstName.Text;
            ind.MiddleName = this.middleName.Text;
            ind.LastName = this.lastName.Text;
            ind.UniqueNumber = this.uniqueIdentifier.Text;
            ind.EmployeeNumber = this.employeeNumber.Text;
            ind.LogonId = this.logonId.Text;
            ind.Password = this.password.Text;

            ind.Gender = this.gender.SelectedValue;
            ind.FullTime = Convert.ToInt32(this.fullTime.SelectedValue);
            ind.IsEmployee = Convert.ToInt32(this.isEmployee.SelectedValue);

            ind.DateOfBirth = Convert.ToDateTime(this.dateOfBirth.Text);
            ind.HireDate = Convert.ToDateTime(this.hireDate.Text);

            ind.DepartmentId = Convert.ToInt32(this.department.SelectedValue);
            ind.JobTitleId = Convert.ToInt32(this.jobTitle.SelectedValue);
            ind.LocaleId = Convert.ToInt32(this.locale.SelectedValue);
            ind.WorkShiftId = Convert.ToInt32(this.workShift.SelectedValue);

            ind.PhoneNumbers.Add(new PhoneNumber(this.businessPhoneNumber.Text, "Business1"));
            ind.PhoneNumbers.Add(new PhoneNumber(this.homePhoneNumber.Text, "Home1"));

            ind.EmailAddresses.Add(new EmailAddress(this.businessEmailAddress.Text, "Business1"));
            ind.EmailAddresses.Add(new EmailAddress(this.personalEmailAddress.Text, "Personal1"));

            ind.Addresses.Add(new Address("Home1", this.homeAddressLine1.Text, this.homeAddressLine2.Text,
                this.homeAddressCity.Text, this.homeAddressState.SelectedValue, this.homeAddressZipCode.Text));

            return ind;

        }

        private void PopulateIndividual(int nbsId)
        {
            try
            {
                this.detailwrapper.Visible = true;
                this.listwrapper.Visible = false;

                PopulateDropdowns();

                Individual ind;

                ind = NinthBrainSuiteAPI.IndividualService.GetIndividualByNBSId(nbsId.ToString());

                DateTime now = DateTime.Now;

                this.nbsId.Value = ind.NBSId.ToString();
                this.firstName.Text = ind.FirstName;
                this.middleName.Text = ind.MiddleName;
                this.lastName.Text = ind.LastName;
                this.uniqueIdentifier.Text = ind.UniqueNumber;
                this.employeeNumber.Text = ind.EmployeeNumber;
                this.logonId.Text = ind.LogonId;

                this.gender.SelectedValue = ind.Gender;
                this.fullTime.SelectedValue = ind.FullTime.ToString();
                this.isEmployee.SelectedValue = ind.IsEmployee.ToString();

                this.dateOfBirth.Text = ind.DateOfBirth.ToShortDateString();
                this.hireDate.Text = ind.HireDate.ToShortDateString();

                this.department.SelectedValue = ind.DepartmentId.ToString();
                this.jobTitle.SelectedValue = ind.JobTitleId.ToString();
                this.locale.SelectedValue = ind.LocaleId.ToString();
                this.workShift.SelectedValue = ind.WorkShiftId.ToString();

                PhoneNumber number;
                number = ind.PhoneNumbers.Find(x => x.PhoneType == "Business1");

                if (number != null)
                {
                    this.businessPhoneNumber.Text = number.Number;
                }

                number = ind.PhoneNumbers.Find(x => x.PhoneType == "Home1");

                if (number != null)
                {
                    this.homePhoneNumber.Text = number.Number;
                }

                Address address;
                address = ind.Addresses.Find(x => x.AddressType == "Home1");

                if (address != null)
                {
                    this.homeAddressLine1.Text = address.AddressLine1;
                    this.homeAddressLine2.Text = address.AddressLine2;
                    this.homeAddressCity.Text = address.City;
                    this.homeAddressState.SelectedValue = address.State;
                    this.homeAddressZipCode.Text = address.ZipCode;
                }

                EmailAddress email;
                email = ind.EmailAddresses.Find(x => x.EmailType == "Business1");

                if (email != null)
                {
                    this.businessEmailAddress.Text = email.EmailAddr;
                }

                email = ind.EmailAddresses.Find(x => x.EmailType == "Personal1");

                if (email != null)
                {
                    this.personalEmailAddress.Text = email.EmailAddr;
                }

                this.btnInsert.Visible = false;
                this.btnUpdate.Visible = true;

                ShowMessage(string.Format("{0} {1} was found on {2}.", ind.FirstName, ind.LastName, now.ToString()));
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

            PopulateDropdowns();

            this.firstName.Text = string.Empty;
            this.middleName.Text = string.Empty;
            this.lastName.Text = string.Empty;
            this.uniqueIdentifier.Text = string.Empty;
            this.employeeNumber.Text = string.Empty;
            this.logonId.Text = string.Empty;

            this.gender.ClearSelection();
            this.fullTime.ClearSelection();
            this.isEmployee.ClearSelection();

            this.dateOfBirth.Text = string.Empty;
            this.hireDate.Text = string.Empty;

            this.department.ClearSelection();
            this.jobTitle.ClearSelection();
            this.locale.ClearSelection();
            this.workShift.ClearSelection();

            this.businessPhoneNumber.Text = string.Empty;
            this.homePhoneNumber.Text = string.Empty;

            this.homeAddressLine1.Text = string.Empty;
            this.homeAddressLine2.Text = string.Empty;
            this.homeAddressCity.Text = string.Empty;
            this.homeAddressState.ClearSelection();
            this.homeAddressZipCode.Text = string.Empty;

            this.businessEmailAddress.Text = string.Empty;
            this.personalEmailAddress.Text = string.Empty;

            this.btnInsert.Visible = true;
            this.btnUpdate.Visible = false;

        }

        protected virtual void btnBackToList_Click(object sender, EventArgs e)
        {
            this.listwrapper.Visible = true;
            this.detailwrapper.Visible = false;

            HideMessage();

            PopulateGrid();
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

        protected virtual void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Individual ind;

                ind = PopulateChanges();

                NinthBrainSuiteAPI.IndividualService.UpdateIndividual(ind);

                DateTime now = DateTime.Now;

                ShowMessage(string.Format("{0} {1} was updated on {2}.", ind.FirstName, ind.LastName, now.ToString()));
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
                Individual ind;

                ind = PopulateChanges();

                NinthBrainSuiteAPI.IndividualService.AddIndividual(ind);

                DateTime now = DateTime.Now;

                ShowMessage(string.Format("{0} {1} was inserted on {2}.", ind.FirstName, ind.LastName, now.ToString()));
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

        private string GetExceptionsDetails(Exception ex, string exceptionType)
        {
            StringBuilder sbExceptions = new StringBuilder();

            sbExceptions.Append(string.Format("{0} thrown:\n", exceptionType));
            sbExceptions.Append(string.Format("Error message: {0}", ex.Message));

            return sbExceptions.ToString();
        }
    }
}