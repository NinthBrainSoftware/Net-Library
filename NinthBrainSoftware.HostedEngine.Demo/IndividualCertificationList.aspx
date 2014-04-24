<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
    CodeBehind="IndividualCertificationList.aspx.cs" Inherits="NinthBrainSoftware.HostedEngine.Demo.IndividualCertificationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="messagePanel" runat="server">
        <h3>
            <asp:Literal ID="message" runat="server"></asp:Literal></h3>
    </asp:Panel>
    <asp:Panel ID="detailwrapper" runat="server" Visible="false">
        <div class="formee">
            <asp:HiddenField ID="individualCertificationId" runat="server" />
            <div class="grid-12-12">
                <asp:Button ID="btnBackToList" runat="server" CssClass="left" Text="Back to List"
                    OnClick="btnBackToList_Click" />
                <asp:Button ID="btnInsert" runat="server" CssClass="right" Text="Insert" OnClick="btnInsert_Click" />
                <asp:Button ID="btnUpdate" runat="server" CssClass="right" Text="Update" OnClick="btnUpdate_Click" />
            </div>
            <div class="grid-4-12 clear">
                <label>
                    Certification<em class="formee-req">*</em></label>
                <asp:DropDownList ID="certification" runat="server" DataTextField="CertificationName"
                    DataValueField="CertificationId">
                </asp:DropDownList>
            </div>
            <div class="grid-4-12 clear">
                <label>
                    Individual<em class="formee-req">*</em></label>
                <asp:DropDownList ID="individual" runat="server" DataTextField="LastFirstName" DataValueField="NBSId">
                </asp:DropDownList>
            </div>
            <div class="grid-4-12 clear">
                <label>
                    Activation Date<em class="formee-req">*</em></label>
                <asp:TextBox ID="activationDate" runat="server"></asp:TextBox>
            </div>
            <div class="grid-4-12 clear">
                <label>
                    Expiration Date<em class="formee-req">*</em></label>
                <asp:TextBox ID="expirationDate" runat="server"></asp:TextBox>
            </div>
            <div class="grid-4-12 clear">
                <label>
                    Certification Number<em class="formee-req">*</em></label>
                <asp:TextBox ID="certificationNumber" runat="server"></asp:TextBox>
            </div>
            <div class="grid-12-12">
                <span style="font-weight: bold; font-size: 1.4em;">State Maintained Certification Details</span>
            </div>
            <div class="grid-4-12 clear">
                <div class="formee-msg-info">
                    This information only applies to certifications that are state maintained (an individual
                    could hold multiple copies of a the same certification but for different states).
                    Currently, the only state maintained certifications in Ninth Brain Suite are Drivers
                    License and DMV Report. The fields should be populated with the two-character state/country
                    code if used, otherwise they should be blank.
                </div>
            </div>
            <div class="grid-2-12 clear">
                <label>
                    State</label>
                <asp:TextBox ID="stateCode" runat="server"></asp:TextBox>
            </div>
            <div class="grid-2-12">
                <label>
                    Country</label>
                <asp:TextBox ID="countryCode" runat="server"></asp:TextBox>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="listwrapper" runat="server">
        <div class="formee">
            <div class="grid-12-12">
                <asp:Button ID="btnAddNew" runat="server" Text="Add New" CssClass="left" OnClick="btnAddNew_Click" />
            </div>
        </div>
        <asp:GridView ID="gvCertification" runat="server" DataKeyNames="IndividualCertificationId"
            OnRowCommand="gvCertification_RowCommand" OnRowDataBound="gvCertification_RowDataBound"
            AutoGenerateColumns="false">
            <Columns>
                <asp:ButtonField Text="Select" CommandName="Select" ButtonType="Button" />
                <asp:TemplateField HeaderText="Employee">
                    <ItemTemplate>
                        <asp:Literal ID="ltlEmployee" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Certification" DataField="CertificationName" />
                <asp:BoundField HeaderText="Activation Date" DataField="ActivationDate" DataFormatString="{0:d}" />
                <asp:BoundField HeaderText="Expiration Date" DataField="ExpirationDate" DataFormatString="{0:d}" />
                <asp:BoundField HeaderText="Certification Number" DataField="CertificationNumber" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
