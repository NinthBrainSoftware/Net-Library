<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
    CodeBehind="IndividualCourseList.aspx.cs" Inherits="NinthBrainSoftware.HostedEngine.Demo.IndividualCourseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="messagePanel" runat="server">
        <h3>
            <asp:Literal ID="message" runat="server"></asp:Literal></h3>
    </asp:Panel>
    <div class="formee">
        <div class="grid-4-12 clear">
            <label>
                Start Date<em class="formee-req">*</em></label>
            <asp:TextBox ID="startDate" runat="server"></asp:TextBox>
        </div>
        <div class="grid-4-12 clear">
            <label>
                End Date<em class="formee-req">*</em></label>
            <asp:TextBox ID="endDate" runat="server"></asp:TextBox>
        </div>
        <div class="grid-4-12 clear">
            <asp:Button ID="btnFilter" runat="server" CssClass="right" Text="Update" OnClick="btnFilter_Click" />
        </div>
    </div>
    <asp:Panel ID="listwrapper" runat="server">
        <asp:GridView ID="gvCourse" runat="server" OnRowDataBound="gvCourse_RowDataBound"
            AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Employee">
                    <ItemTemplate>
                        <asp:Literal ID="ltlEmployee" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Course" DataField="CourseName" />
                <asp:BoundField HeaderText="Start Date" DataField="StartDate" DataFormatString="{0:d}" />
                <asp:BoundField HeaderText="End Date" DataField="EndDate" DataFormatString="{0:d}" />
                <asp:BoundField HeaderText="Department" DataField="Department"  />
                <asp:BoundField HeaderText="Job Title" DataField="JobTitle"  />
                <asp:BoundField HeaderText="Locale" DataField="Locale"  />
                <asp:BoundField HeaderText="Employee Number" DataField="EmployeeNumber"  />
                <asp:BoundField HeaderText="Author Instructor" DataField="AuthorInstructor"  />
                <asp:BoundField HeaderText="Credit" DataField="Credit"  />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
