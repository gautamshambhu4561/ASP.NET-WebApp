<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ManageCourses.aspx.cs" Inherits="LMSProject.Admin.ManageCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2 class="mb-4">Manage Courses</h2>
    <div class="mb-3">
        <label for="txtTitle" class="form-label">Course Title</label>
        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <label for="txtDescription" class="form-label">Description</label>
        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
    </div>
    <asp:DropDownList ID="ddlInstructor" runat="server" CssClass="form-control mb-3" AppendDataBoundItems="true">
        <asp:ListItem Value="0" Text="Select Instructor" />
    </asp:DropDownList>
    <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" CssClass="btn btn-primary" OnClick="btnAddCourse_Click" />
    <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered mt-3">
        <Columns>
            <asp:BoundField DataField="CourseID" HeaderText="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="InstructorName" HeaderText="Instructor" />
        </Columns>
    </asp:GridView>
    <div id="errorMessage" class="alert alert-danger d-none" runat="server"></div>
</asp:Content>
