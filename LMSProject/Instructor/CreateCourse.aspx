<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Instructor.Master" AutoEventWireup="true" CodeBehind="CreateCourse.aspx.cs" Inherits="LMSProject.Instructor.CreateCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mb-4">Create Course</h2>
    <div class="mb-3">
        <label for="txtTitle" class="form-label">Course Title</label>
        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <label for="txtDescription" class="form-label">Description</label>
        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
    </div>
    <asp:Button ID="btnCreateCourse" runat="server" Text="Create Course" CssClass="btn btn-primary" OnClick="btnCreateCourse_Click" />
    <div id="errorMessage" class="alert alert-danger d-none" runat="server"></div>
</asp:Content>
