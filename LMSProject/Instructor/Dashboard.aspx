<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Instructor.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="LMSProject.Instructor.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mb-4">Instructor Dashboard</h2>
    <p>Welcome, <asp:Label ID="lblUserName" runat="server" Text="" /></p>
    <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="CourseID" HeaderText="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <a href="ViewStudents.aspx?CourseID=<%# Eval("CourseID") %>" class="btn btn-primary btn-sm">View Students</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

