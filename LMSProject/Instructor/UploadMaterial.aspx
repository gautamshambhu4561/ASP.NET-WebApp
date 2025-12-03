<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Instructor.Master" AutoEventWireup="true" CodeBehind="UploadMaterial.aspx.cs" Inherits="LMSProject.Instructor.UploadMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2 class="mb-4">Upload Material</h2>
    <div class="mb-3">
        <label for="ddlCourse" class="form-label">Course</label>
        <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <label for="txtTitle" class="form-label">Material Title</label>
        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <label for="fuMaterial" class="form-label">File</label>
        <asp:FileUpload ID="fuMaterial" runat="server" CssClass="form-control" />
    </div>
    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary" OnClick="btnUpload_Click" />
    <div id="errorMessage" class="alert alert-danger d-none" runat="server"></div>
</asp:Content>
