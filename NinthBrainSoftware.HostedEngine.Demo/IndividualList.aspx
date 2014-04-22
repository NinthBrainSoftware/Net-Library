<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs" Inherits="NinthBrainSoftware.HostedEngine.Demo.IndividualList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Literal ID="message" runat="server"></asp:Literal>
    </div>
    <asp:Panel ID="listwrapper" runat="server">
        <h2>
            Individual List</h2>
        <div>
            <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
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
    <asp:Panel ID="detailwrapper" runat="server">
        <h2>
            Add/Edit Individual</h2>
        <div>
            <asp:Button ID="btnBackToList" runat="server" Text="Back to List" OnClick="btnBackToList_Click" />
        </div>
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
