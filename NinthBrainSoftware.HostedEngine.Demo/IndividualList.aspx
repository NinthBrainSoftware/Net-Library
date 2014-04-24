<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
    CodeBehind="IndividualList.aspx.cs" Inherits="NinthBrainSoftware.HostedEngine.Demo.IndividualList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="messagePanel" runat="server">
        <h3>
            <asp:Literal ID="message" runat="server"></asp:Literal></h3>
    </asp:Panel>
    <asp:Panel ID="listwrapper" runat="server">
        <div class="formee">
            <div class="grid-12-12">
                <asp:Button ID="btnAddNew" runat="server" Text="Add New" CssClass="left" OnClick="btnAddNew_Click" />
            </div>
        </div>
        <asp:GridView ID="gvIndividual" runat="server" DataKeyNames="NBSId" OnRowCommand="gvIndividual_RowCommand"
            OnRowDataBound="gvIndividual_RowDataBound" AutoGenerateColumns="false">
            <Columns>
                <asp:ButtonField Text="Select" CommandName="Select" ButtonType="Button" />
                <asp:BoundField HeaderText="NBS Id" DataField="NBSId" />
                <asp:TemplateField HeaderText="Employee">
                    <ItemTemplate>
                        <asp:Literal ID="ltlEmployee" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Date of Birth" DataField="DateOfBirth" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="detailwrapper" runat="server" Visible="false">
        <div class="formee">
            <asp:HiddenField ID="nbsId" runat="server" />
            <div class="grid-12-12">
                <asp:Button ID="btnBackToList" runat="server" CssClass="left" Text="Back to List"
                    OnClick="btnBackToList_Click" />
                <asp:Button ID="btnInsert" runat="server" CssClass="right" Text="Insert" OnClick="btnInsert_Click" />
                <asp:Button ID="btnUpdate" runat="server" CssClass="right" Text="Update" OnClick="btnUpdate_Click" />
            </div>
            <fieldset>
                <legend>General</legend>
                <div class="grid-4-12">
                    <label>
                        First Name <em class="formee-req">*</em></label>
                    <asp:TextBox ID="firstName" runat="server"></asp:TextBox>
                </div>
                <div class="grid-4-12">
                    <label>
                        Middle Name
                    </label>
                    <asp:TextBox ID="middleName" runat="server"></asp:TextBox>
                </div>
                <div class="grid-4-12">
                    <label>
                        Last Name <em class="formee-req">*</em></label>
                    <asp:TextBox ID="lastName" runat="server"></asp:TextBox>
                </div>
                <div class="grid-4-12">
                    <label>
                        Logon Id <em class="formee-req">*</em></label>
                    <asp:TextBox ID="logonId" runat="server"></asp:TextBox>
                </div>
                <div class="grid-4-12">
                    <label>
                        Password</label>
                    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="grid-4-12 clear">
                    <label>
                        Unique Identifier</label>
                    <asp:TextBox ID="uniqueIdentifier" runat="server"></asp:TextBox>
                </div>
                <div class="grid-4-12">
                    <label>
                        Employee Number</label>
                    <asp:TextBox ID="employeeNumber" runat="server"></asp:TextBox>
                </div>
                <div class="grid-3-12 clear">
                    <label>
                        Job Title</label>
                    <asp:DropDownList ID="jobTitle" runat="server" DataTextField="JobTitleName" DataValueField="JobTitleId">
                    </asp:DropDownList>
                </div>
                <div class="grid-3-12">
                    <label>
                        Department</label>
                    <asp:DropDownList ID="department" runat="server" DataTextField="DepartmentName" DataValueField="DepartmentId">
                    </asp:DropDownList>
                </div>
                <div class="grid-3-12">
                    <label>
                        Locale</label>
                    <asp:DropDownList ID="locale" runat="server" DataTextField="LocaleName" DataValueField="LocaleId">
                    </asp:DropDownList>
                </div>
                <div class="grid-3-12">
                    <label>
                        Work Shift</label>
                    <asp:DropDownList ID="workShift" runat="server" DataTextField="WorkShiftName" DataValueField="WorkShiftId">
                    </asp:DropDownList>
                </div>
                <div class="grid-3-12">
                    <label>
                        Date of Birth</label>
                    <asp:TextBox ID="dateOfBirth" runat="server"></asp:TextBox>
                </div>
                <div class="grid-3-12">
                    <label>
                        Hire Date</label>
                    <asp:TextBox ID="hireDate" runat="server"></asp:TextBox>
                </div>
                <div class="grid-3-12 clear">
                    <label>
                        Gender</label>
                    <asp:DropDownList ID="gender" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="grid-3-12">
                    <label>
                        Full Time</label>
                    <asp:DropDownList ID="fullTime" runat="server">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="grid-3-12">
                    <label>
                        Is Employee</label>
                    <asp:DropDownList ID="isEmployee" runat="server">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </fieldset>
            <fieldset>
                <legend>Phone Numbers</legend>
                <div class="grid-4-12">
                    <label>
                        Business Phone</label>
                    <asp:TextBox ID="businessPhoneNumber" runat="server"></asp:TextBox>
                </div>
                <div class="grid-4-12">
                    <label>
                        Home Phone</label>
                    <asp:TextBox ID="homePhoneNumber" runat="server"></asp:TextBox>
                </div>
            </fieldset>
            <fieldset>
                <legend>Addresses</legend>
                <div class="grid-6-12 clear">
                    <label>
                        Home Address Line 1</label>
                    <asp:TextBox ID="homeAddressLine1" runat="server"></asp:TextBox>
                </div>
                <div class="grid-6-12 clear">
                    <label>
                        Home Address Line 2</label>
                    <asp:TextBox ID="homeAddressLine2" runat="server"></asp:TextBox>
                </div>
                <div class="grid-3-12 clear">
                    <label>
                        Home City</label>
                    <asp:TextBox ID="homeAddressCity" runat="server"></asp:TextBox>
                </div>
                <div class="grid-1-12">
                    <label>
                        State</label>
                    <asp:DropDownList ID="homeAddressState" runat="server">
                        <asp:ListItem Value="">State</asp:ListItem>
                        <asp:ListItem Value="AL">AL</asp:ListItem>
                        <asp:ListItem Value="AK">AK</asp:ListItem>
                        <asp:ListItem Value="AZ">AZ</asp:ListItem>
                        <asp:ListItem Value="AR">AR</asp:ListItem>
                        <asp:ListItem Value="CA">CA</asp:ListItem>
                        <asp:ListItem Value="CO">CO</asp:ListItem>
                        <asp:ListItem Value="CT">CT</asp:ListItem>
                        <asp:ListItem Value="DC">DC</asp:ListItem>
                        <asp:ListItem Value="DE">DE</asp:ListItem>
                        <asp:ListItem Value="FL">FL</asp:ListItem>
                        <asp:ListItem Value="GA">GA</asp:ListItem>
                        <asp:ListItem Value="HI">HI</asp:ListItem>
                        <asp:ListItem Value="ID">ID</asp:ListItem>
                        <asp:ListItem Value="IL">IL</asp:ListItem>
                        <asp:ListItem Value="IN">IN</asp:ListItem>
                        <asp:ListItem Value="IA">IA</asp:ListItem>
                        <asp:ListItem Value="KS">KS</asp:ListItem>
                        <asp:ListItem Value="KY">KY</asp:ListItem>
                        <asp:ListItem Value="LA">LA</asp:ListItem>
                        <asp:ListItem Value="ME">ME</asp:ListItem>
                        <asp:ListItem Value="MD">MD</asp:ListItem>
                        <asp:ListItem Value="MA">MA</asp:ListItem>
                        <asp:ListItem Value="MI">MI</asp:ListItem>
                        <asp:ListItem Value="MN">MN</asp:ListItem>
                        <asp:ListItem Value="MS">MS</asp:ListItem>
                        <asp:ListItem Value="MO">MO</asp:ListItem>
                        <asp:ListItem Value="MT">MT</asp:ListItem>
                        <asp:ListItem Value="NE">NE</asp:ListItem>
                        <asp:ListItem Value="NV">NV</asp:ListItem>
                        <asp:ListItem Value="NH">NH</asp:ListItem>
                        <asp:ListItem Value="NJ">NJ</asp:ListItem>
                        <asp:ListItem Value="NM">NM</asp:ListItem>
                        <asp:ListItem Value="NY">NY</asp:ListItem>
                        <asp:ListItem Value="NC">NC</asp:ListItem>
                        <asp:ListItem Value="ND">ND</asp:ListItem>
                        <asp:ListItem Value="OH">OH</asp:ListItem>
                        <asp:ListItem Value="OK">OK</asp:ListItem>
                        <asp:ListItem Value="OR">OR</asp:ListItem>
                        <asp:ListItem Value="PA">PA</asp:ListItem>
                        <asp:ListItem Value="RI">RI</asp:ListItem>
                        <asp:ListItem Value="SC">SC</asp:ListItem>
                        <asp:ListItem Value="SD">SD</asp:ListItem>
                        <asp:ListItem Value="TN">TN</asp:ListItem>
                        <asp:ListItem Value="TX">TX</asp:ListItem>
                        <asp:ListItem Value="UT">UT</asp:ListItem>
                        <asp:ListItem Value="VT">VT</asp:ListItem>
                        <asp:ListItem Value="VA">VA</asp:ListItem>
                        <asp:ListItem Value="WA">WA</asp:ListItem>
                        <asp:ListItem Value="WV">WV</asp:ListItem>
                        <asp:ListItem Value="WI">WI</asp:ListItem>
                        <asp:ListItem Value="WY">WY</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="grid-2-12">
                    <label>
                        Home Zip Code</label>
                    <asp:TextBox ID="homeAddressZipCode" runat="server"></asp:TextBox>
                </div>
            </fieldset>
            <fieldset>
                <legend>Email Addresses</legend>
                <div class="grid-4-12">
                    <label>
                        Business Email</label>
                    <asp:TextBox ID="businessEmailAddress" runat="server"></asp:TextBox>
                </div>
                <div class="grid-4-12">
                    <label>
                        Personal Email</label>
                    <asp:TextBox ID="personalEmailAddress" runat="server"></asp:TextBox>
                </div>
            </fieldset>
        </div>
    </asp:Panel>
</asp:Content>
