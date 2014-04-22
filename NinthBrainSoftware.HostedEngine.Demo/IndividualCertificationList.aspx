<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs" Inherits="NinthBrainSoftware.HostedEngine.Demo.IndividualCertificationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Literal ID="message" runat="server"></asp:Literal>
    </div>
    <asp:Panel ID="detailwrapper" runat="server" Visible="false">
        <h2>
            Add/Edit Individual</h2>
        <div>
            <asp:Button ID="btnBackToList" runat="server" Text="Back to List" OnClick="btnBackToList_Click" />
        </div>
        <div>
            Certification:
            <asp:DropDownList ID="certification" runat="server" DataTextField="CertificationName"
                DataValueField="CertificationId">
            </asp:DropDownList>
        </div>
        <div>
            Individual:
            <asp:DropDownList ID="individual" runat="server" DataTextField="LastFirstName" DataValueField="NBSId">
            </asp:DropDownList>
        </div>
        <div>
            Activation Date:
            <asp:TextBox ID="activationDate" runat="server"></asp:TextBox>
        </div>
        <div>
            Expiration Date:
            <asp:TextBox ID="expirationDate" runat="server"></asp:TextBox>
        </div>
        <div>
            Certification Number:
            <asp:TextBox ID="certificationNumber" runat="server"></asp:TextBox>
        </div>
        <div>
            State Maintained Certification Details
        </div>
        <div>
            This information only applies to certifications that are state maintained (an individual
            could hold multiple copies of a the same certification but for different states).
            Currently, the only state maintained certifications in Ninth Brain Suite are Drivers
            License and DMV Report. The fields should be populated with the two-character state/country
            code if used, otherwise they should be blank.
        </div>
        <div>
            State:
            <asp:TextBox ID="stateCode" runat="server"></asp:TextBox>
        </div>
        <div>
            Country:
            <asp:TextBox ID="countryCode" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:HiddenField ID="individualCertificationId" runat="server" />
            <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="listwrapper" runat="server">
        <h2>
            Certification List</h2>
        <div>
            <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
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
