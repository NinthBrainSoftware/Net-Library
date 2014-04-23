<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
    CodeBehind="IndividualSearch.aspx.cs" Inherits="NinthBrainSoftware.HostedEngine.Demo.IndividualSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Literal ID="message" runat="server"></asp:Literal>
    </div>
    <asp:Panel ID="listwrapper" runat="server">
        <div>
            NBS Id:
            <asp:TextBox ID="nbsIdSearch" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnSearchByNbsId" runat="server" Text="Search" OnClick="btnSearchByNbsId_Click" />
        </div>
        <div>
            Unique Identifier
            <asp:TextBox ID="uniqueIdentifierSearch" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnSearchByUniqueIdentifier" runat="server" Text="Search" OnClick="btnSearchByUniqueIdentifier_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="detailwrapper" runat="server" Visible="false">
        <div>
            <asp:Button ID="btnBackToList" runat="server" Text="Back to List" OnClick="btnBackToList_Click" />
        </div>
        <h2>
            Add/Edit Individual</h2>
        <div>
            First Name:
            <asp:TextBox ID="firstName" runat="server"></asp:TextBox>
        </div>
        <div>
            Last Name:
            <asp:TextBox ID="lastName" runat="server"></asp:TextBox>
        </div>
        <div>
            Unique Identifier:
            <asp:TextBox ID="uniqueIdentifier" runat="server"></asp:TextBox>
        </div>
        <div>
            Logon Id:
            <asp:TextBox ID="logonId" runat="server"></asp:TextBox>
        </div>
        <div>
            Password:
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
        </div>
        <h3>
            Contact Info
        </h3>
        <div>
            Business Phone Number:
            <asp:TextBox ID="businessPhoneNumber" runat="server"></asp:TextBox>
        </div>
        <div>
            Home Phone Number:
            <asp:TextBox ID="homePhoneNumber" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        </div>
    </asp:Panel>
</asp:Content>
