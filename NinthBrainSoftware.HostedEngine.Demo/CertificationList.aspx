<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
    CodeBehind="CertificationList.aspx.cs" Inherits="NinthBrainSoftware.HostedEngine.Demo.CertificationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="listwrapper" runat="server">
        <h2>
            Course Certifications</h2>
        <div>
            This is a listing of certifications that are tracked by the company in Ninth Brain
            Suite.
        </div>
        <asp:GridView ID="gvCertification" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Certification Id" DataField="CertificationId" />
                <asp:BoundField HeaderText="Certification Name" DataField="CertificationName" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
