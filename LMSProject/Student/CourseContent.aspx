<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="CourseContent.aspx.cs" Inherits="LMSProject.Student.CourseContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mb-4">Course Content</h2>
    <h4>Materials</h4>
    <asp:GridView ID="gvMaterials" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="MaterialID" HeaderText="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:HyperLinkField DataTextField="FilePath" HeaderText="Download" DataNavigateUrlFields="FilePath" Target="_blank" />
        </Columns>
    </asp:GridView>
    <h4>Assignments</h4>
    <asp:GridView ID="gvAssignments" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="AssignmentID" HeaderText="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="DueDate" HeaderText="Due Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <a href='SubmitAssignment.aspx?AssignmentID=<%# Eval("AssignmentID") %>' class="btn btn-primary btn-sm">Submit</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <h4>Announcements</h4>
    <asp:GridView ID="gvAnnouncements" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="AnnouncementID" HeaderText="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Content" HeaderText="Content" />
            <asp:BoundField DataField="PostedDate" HeaderText="Posted Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
        </Columns>
    </asp:GridView>
    <div id="errorMessage" class="alert alert-danger d-none" runat="server"></div>
</asp:Content>
